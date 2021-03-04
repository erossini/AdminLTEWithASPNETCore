using AdminLTEWithASPNETCore.Data;
using AdminLTEWithASPNETCore.Models.Settings;
using AdminLTEWithASPNETCore.Services;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            #region Settings
            services.Configure<SmtpCredentialsSettings>(Configuration.GetSection("SmtpCredentials"));
            services.AddScoped(cfg => cfg.GetService<IOptions<SmtpCredentialsSettings>>().Value);

            services.Configure<IdentityServerSettings>(Configuration.GetSection("IdentityAuthentication"));
            services.AddScoped(cfg => cfg.GetService<IOptions<IdentityServerSettings>>().Value);
            #endregion

            #region Setting Db
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContextConnection")));
            #endregion

            #region Dependency Injection
            services.AddTransient<IEmailSender, EmailSender>();
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
                var idsrv = Configuration.GetSection("Authentication:IdentityServer").Get<IdentityServerSettings>();
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
                        OnAuthorizationCodeReceived = context => {
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
                if (!string.IsNullOrEmpty(Configuration["Authentication:Facebook:AppId"]) &&
                    !string.IsNullOrEmpty(Configuration["Authentication:Facebook:AppSecret"]))
                {
                    services.AddAuthentication().AddFacebook(facebookOptions =>
                    {
                        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    });
                }
                if (!string.IsNullOrEmpty(Configuration["Authentication:Google:ClientId"]) &&
                    !string.IsNullOrEmpty(Configuration["Authentication:Google:ClientSecret"]))
                {
                    services.AddAuthentication().AddGoogle(googleOptions =>
                    {
                        googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                        googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    });
                }
                if (!string.IsNullOrEmpty(Configuration["Authentication:Microsoft:ClientId"]) &&
                    !string.IsNullOrEmpty(Configuration["Authentication:Microsoft:ClientSecret"]))
                {
                    services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
                    {
                        microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                        microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                    });
                }
                if (!string.IsNullOrEmpty(Configuration["Authentication:Twitter:ConsumerAPIKey"]) &&
                    !string.IsNullOrEmpty(Configuration["Authentication:Twitter:ConsumerSecret"]))
                {
                    services.AddAuthentication().AddTwitter(twitterOptions =>
                    {
                        twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
                        twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                        twitterOptions.RetrieveUserDetails = true;
                    });
                }
            }
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext db)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // ensure the database is created
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}