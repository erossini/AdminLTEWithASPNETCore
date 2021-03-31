using AdminLTEWithASPNETCore.Models.Components.Cards;
using AdminLTEWithASPNETCore.Models.Components.Charts;
using AdminLTEWithASPNETCore.Models.Components.Timeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Controllers
{
    public class HomeModel
    {
        public CardModel Card { get; set; }
        public ChartModel VisitorChart { get; set; }
        public ChartModel SalesChart { get; set; }
        public ChartModel SalesPie { get; set; }
        public TimelineModel Timeline { get; set; }
    }
}
