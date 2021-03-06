using AdminLTEWithASPNETCore.Code.Configurations;
using AdminLTEWithASPNETCore.Code.Processes;
using AdminLTEWithASPNETCore.Data;
using AdminLTEWithASPNETCore.Models.Settings;
using AdminLTEWithASPNETCore.Resources;
using AdminLTEWithASPNETCore.Services;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PSC.Infrastructures.Hubs;
using PSC.Persistence;
using PSC.Services.AspNetCore;
using PSC.Services.Imports;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        static string XmlCommentsFileName
        {
            get
            {
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return fileName;
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddRazorPages();
            services.AddLogging();

            #region Settings
            services.Configure<SmtpCredentialsSettings>(Configuration.GetSection("SmtpCredentials"));
            services.AddScoped(cfg => cfg.GetService<IOptions<SmtpCredentialsSettings>>().Value);

            services.Configure<AuthenticationSettings>(Configuration.GetSection("Authentication"));
            services.AddScoped(cfg => cfg.GetService<IOptions<AuthenticationSettings>>().Value);
            #endregion
            #region Setting Db
            var cnnString = Configuration.GetConnectionString("PSCContextConnection");
            services.AddDbContext<ApplicationDbContext>(_ => _.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContextConnection")));
            #endregion
            #region Dependency Injection
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<ImportExcel>();
            services.AddTransient<UploadFiles>();
            services.AddScoped<ImportExcelProcessBase>();
            services.AddScoped<ImportAzureProcess>();

            services.AddPersistenceServices(Configuration);
            #endregion
            #region Authentication and IdentityServer4
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".puresourcecode.session";
                options.IdleTimeout = TimeSpan.FromHours(12);
            });

            if (Convert.ToBoolean(Configuration["Authentication:UseIdentityServer"]))
            {
                var idsrv = Configuration.GetSection("Authentication:IdentityServer").Get<IdentityserverSettings>();
                services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.Cookie.Name = ".puresourcecode.cookie";
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Events = new Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents
                    {
                        OnAccessDenied = context =>
                        {
                            Console.WriteLine("OnAccessDenied");
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed");
                            return Task.CompletedTask;
                        },
                        OnAuthorizationCodeReceived = context =>
                        {
                            Console.WriteLine("OnAuthorizationCodeReceived");
                            return Task.CompletedTask;
                        },
                        OnRedirectToIdentityProvider = context =>
                        {
                            Console.WriteLine("OnRedirectToIdentityProvider");
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated");

                            var idToken = context.SecurityToken;
                            string userIdentifier = idToken.Subject;
                            string userEmail =
                                idToken.Claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value
                                ?? idToken.Claims.SingleOrDefault(c => c.Type == "preferred_username")?.Value;

                            string firstName = idToken.Claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.GivenName)?.Value;
                            string lastName = idToken.Claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.FamilyName)?.Value;
                            string name = idToken.Claims.SingleOrDefault(c => c.Type == "name")?.Value;

                            // manage roles, modify token and claims etc.
                            return Task.CompletedTask;
                        },
                        OnTicketReceived = context =>
                        {
                            Console.WriteLine("OnTicketReceived");
                            // If your authentication logic is based on users then add your logic here
                            return Task.CompletedTask;
                        },
                        OnRemoteFailure = context =>
                        {
                            Console.WriteLine("OnRemoteFailure");
                            return Task.CompletedTask;
                        }
                    };

                    options.Authority = idsrv.IdentityServerUrl;
                    options.ClientId = idsrv.ClientId;
                    options.ClientSecret = idsrv.ClientSecret;

#if DEBUG
                    options.RequireHttpsMetadata = false;
#else
                    options.RequireHttpsMetadata = true;
#endif

                    options.ResponseType = "code";
                    options.UsePkce = true;

                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.Scope.Add("roles");
                    options.Scope.Add("offline_access");

                    options.ClaimActions.MapJsonKey("role", "role", "role");

                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    options.SignedOutRedirectUri = "/";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,
                    };
                });
            }
            else
            {
                if (CheckAuthenticationWith("Facebook"))
                {
                    services.AddAuthentication().AddFacebook(facebookOptions =>
                    {
                        facebookOptions.AppId = Configuration["Authentication:Facebook:ClientId"];
                        facebookOptions.AppSecret = Configuration["Authentication:Facebook:ClientSecret"];
                    });
                }
                if (CheckAuthenticationWith("Google"))
                {
                    services.AddAuthentication().AddGoogle(googleOptions =>
                    {
                        googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                        googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    });
                }
                if (CheckAuthenticationWith("Microsoft"))
                {
                    services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
                    {
                        microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                        microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                    });
                }
                if (CheckAuthenticationWith("Twitter"))
                {
                    services.AddAuthentication().AddTwitter(twitterOptions =>
                    {
                        twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ClientId"];
                        twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ClientSecret"];
                        twitterOptions.RetrieveUserDetails = true;
                    });
                }
            }
            #endregion
            #region Hangfire.io
            #region Configure Hangfire  
            services.AddHangfire(c => c.UseSqlServerStorage(cnnString));
            GlobalConfiguration.Configuration.UseSqlServerStorage(cnnString).WithJobExpirationTimeout(TimeSpan.FromDays(7));
            #endregion
            #endregion
            #region SignarR
            services.AddSignalR(hubOptions =>
            {
#if DEBUG
                hubOptions.EnableDetailedErrors = true;
#endif
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
            });
            #endregion
            #region API version
            services.AddApiVersioning(config =>
            {
                //config.DefaultApiVersion = new ApiVersion(1, 0);
                //config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                //config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
            options =>
            {
                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();
                // integrate xml comments
                options.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), XmlCommentsFileName));
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider,
            ApplicationDbContext db, PSCContext dbPSC)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                //app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

            #region Database creation
            // ensure the database is created
            db.Database.EnsureCreated();
            dbPSC.Database.EnsureCreated();
            if (dbPSC.Database.GetPendingMigrations().Count() > 0)
                dbPSC.Database.Migrate();
            #endregion
            #region Configure Hangfire  
            app.UseHangfireServer();

            //Basic Authentication added to access the Hangfire Dashboard  
            app.UseHangfireDashboard("/jobs", new DashboardOptions()
            {
                AppPath = null,
                DashboardTitle = StringResources.JobDashboardTitle,
                Authorization = new[] {
                    new HangfireCustomBasicAuthenticationFilter{
                        User = Configuration.GetSection("HangfireCredentials:UserName").Value,
                        Pass = Configuration.GetSection("HangfireCredentials:Password").Value
                    }
                }
            });
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                #region SignalR
                endpoints.MapHub<NotificationHub>("/notificationHub");
                #endregion

                endpoints.MapControllerRoute(
                    name: "Tables",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }

        /// <summary>
        /// Checks the authentication with.
        /// </summary>
        /// <param name="socialMediaName">Name of the social media.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckAuthenticationWith(string socialMediaName)
        {
            return !string.IsNullOrEmpty(Configuration[$"Authentication:{socialMediaName}:ClientId"]) &&
                   !string.IsNullOrEmpty(Configuration[$"Authentication:{socialMediaName}:ClientSecret"]);
        }
    }
}