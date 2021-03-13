using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Enums;
using AdminLTEWithASPNETCore.Models;
using AdminLTEWithASPNETCore.Models.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AdminLTEWithASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.Card = new Models.Components.Cards.CardModel()
            {
                Body = "This is an example of card",
                Links = new System.Collections.Generic.List<Models.Components.LinkModel>()
                {
                    new Models.Components.LinkModel() {
                        Target = "_blank",
                        Text = "PureSourceCode",
                        Url = "https://www.puresourcecode.com"
                    },
                    new Models.Components.LinkModel() {
                        Target = "",
                        Text = "Click here",
                        Url = "#"
                    }
                },
                Title = "Card test"
            };
            model.VisitorChart = new Models.Components.Charts.ChartModel()
            {
                ChartId = "visitor-chart",
                Height = 250,
                Labels = { "18th", "20th", "22nd", "24th", "26th", "28th", "30th" },
                ShowLegend = true,
                Datasets = new System.Collections.Generic.List<Models.Components.Charts.Dataset>()
                {
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColors = new System.Collections.Generic.List<string>() { "transparent" },
                        BorderColor = "#007bff",
                        Label = "This week",
                        PointBackgroundColor = "#007bff",
                        PointBorderColor = "#007bff",
                        Fill = false,
                        Data = new System.Collections.Generic.List<decimal>() {
                            100, 120, 170, 167, 180, 177, 160
                        }
                    },
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColors = new System.Collections.Generic.List<string>() { "transparent" },
                        BorderColor = "#ced4da",
                        Label = "Last week",
                        PointBackgroundColor = "#ced4da",
                        PointBorderColor = "#ced4da",
                        Fill = false,
                        Data = new System.Collections.Generic.List<decimal>() {
                            60, 80, 70, 67, 80, 77, 100
                        }
                    }
                }
            };
            model.SalesChart = new Models.Components.Charts.ChartModel()
            {
                ChartId = "salesChart",
                Height = 250,
                Labels = { "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" },
                ShowLegend = true,
                XAxes = new Models.Components.Charts.Axes()
                {
                    ShowAxes = true,
                    ShowGridLines = true
                },
                YAxes = new Models.Components.Charts.Axes()
                {
                    ShowAxes = true,
                    ShowGridLines = true
                },
                Datasets = new System.Collections.Generic.List<Models.Components.Charts.Dataset>()
                {
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColors = new System.Collections.Generic.List<string>() { "#007bff" },
                        BorderColor = "#007bff",
                        Label = "This year",
                        Data = new System.Collections.Generic.List<decimal>()
                        {
                            1000, 2000, 3000, 2500, 2700, 2500, 3000
                        }
                    },
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColors = new System.Collections.Generic.List<string>() { "#ced4da" },
                        BorderColor = "#ced4da",
                        Label = "Last year",
                        Data = new System.Collections.Generic.List<decimal>()
                        {
                            700, 1700, 2700, 2000, 1800, 1500, 2000
                        }
                    }
                }
            };
            model.SalesPie = new Models.Components.Charts.ChartModel()
            {
                ChartId = "pieSales",
                Labels = new System.Collections.Generic.List<string>() {
                    "Instore Sales", "Download Sales", "Mail-Order Sales"
                },
                ShowLegend = true,
                Datasets = new System.Collections.Generic.List<Models.Components.Charts.Dataset>()
                {
                    new Models.Components.Charts.Dataset()
                    {
                        BackgroundColors = new System.Collections.Generic.List<string>()
                        {
                            "#f56954", "#00a65a", "#f39c12"
                        },
                        Data = new System.Collections.Generic.List<decimal>()
                        {
                            30, 20, 10
                        }
                    }
                }
            };
            model.Timeline = new Models.Components.Timeline.TimelineModel()
            {
                Events = new System.Collections.Generic.List<Models.Components.Timeline.TimelineEvent>()
                {
                    new Models.Components.Timeline.TimelineEvent()
                    {
                         EventDate = "1 March 2021",
                         EventType = Enums.Components.Timeline.TimelineEventType.Important,
                         Items = new System.Collections.Generic.List<Models.Components.Timeline.TimelineItem>()
                         {
                             new Models.Components.Timeline.TimelineItem()
                             {
                                  Body = "This item accepts HTML tags.",
                                  HeaderText = "Click here to go <a href ='/Home'>Home</a>",
                                  ItemIcon = Enums.Components.Timeline.TimelineItemIcon.Letter,
                                  ItemType = Enums.Components.Timeline.TimelineEventType.Information,
                                  Time = "00:05"
                             },
                             new Models.Components.Timeline.TimelineItem()
                             {
                                  Body="The application starts the import process for the file",
                                  Footer = new System.Collections.Generic.List<Models.Components.Timeline.TimelineButton>()
                                  {
                                       new Models.Components.Timeline.TimelineButton()
                                       {
                                            ButtonType = ButtonType.Primary,
                                            Text = "View original file",
                                            Url = "/ExcelImport/Index"
                                       }
                                  },
                                  HeaderText = "The process is started",
                                  ItemIcon = Enums.Components.Timeline.TimelineItemIcon.Comment,
                                  ItemType = Enums.Components.Timeline.TimelineEventType.Highlight,
                                  Time = "00:07"
                             },
                             new Models.Components.Timeline.TimelineItem()
                             {
                                  Body = "The import finished but there are some issue that requires the user supervision.",
                                  Footer = new System.Collections.Generic.List<Models.Components.Timeline.TimelineButton>()
                                  {
                                       new Models.Components.Timeline.TimelineButton()
                                       {
                                            ButtonType = ButtonType.Danger,
                                            Text = "Abandon import",
                                            Url = "/ExcelImport/Index"
                                       },
                                       new Models.Components.Timeline.TimelineButton()
                                       {
                                            ButtonType = ButtonType.Warning,
                                            Text = "Restart the process",
                                            Url = "/ExcelImport/Index"
                                       }
                                  },
                                  HeaderText = "Import has some issues",
                                  ItemIcon = Enums.Components.Timeline.TimelineItemIcon.Comment,
                                  ItemType = Enums.Components.Timeline.TimelineEventType.Warning,
                                  Time = "00:15"
                             },
                             new Models.Components.Timeline.TimelineItem()
                             {
                                  HeaderText = "Waiting user activity",
                                  ItemIcon = Enums.Components.Timeline.TimelineItemIcon.UserActivity,
                                  ItemType = Enums.Components.Timeline.TimelineEventType.UndefinedStatus,
                                  Time = "00:20"
                             },
                             new Models.Components.Timeline.TimelineItem()
                             {
                                  Body = "The user checked the data and accepted the error.",
                                  HeaderText = "User accepted the errors",
                                  ItemIcon = Enums.Components.Timeline.TimelineItemIcon.UserActivity,
                                  ItemType = Enums.Components.Timeline.TimelineEventType.Successful,
                                  Time = "00:20"
                             }
                         }
                    },
                    new Models.Components.Timeline.TimelineEvent()
                    {
                         EventDate = "2 March 2021",
                         EventType = Enums.Components.Timeline.TimelineEventType.Information
                    },
                    new Models.Components.Timeline.TimelineEvent()
                    {
                         EventDate = "3 March 2021",
                         EventType = Enums.Components.Timeline.TimelineEventType.Successful
                    },
                    new Models.Components.Timeline.TimelineEvent()
                    {
                         EventDate = "4 March 2021",
                         EventType = Enums.Components.Timeline.TimelineEventType.Warning
                    },
                }
            };

            return View("Index", model);
        }

        [Authorize]
        [Breadcrumb("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Home/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                var statusFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                if (statusFeature != null)
                {
                    //log.LogWarning("handled 404 for url: {OriginalPath}", statusFeature.OriginalPath);
                }
                return View("~/Views/Home/Error404.cshtml", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    StatusCode = statusCode
                });
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, StatusCode = statusCode });
        }
    }
}