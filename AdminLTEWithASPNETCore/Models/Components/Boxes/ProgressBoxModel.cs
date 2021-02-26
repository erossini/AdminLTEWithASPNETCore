using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Boxes
{
    public class ProgressBoxModel : BoxModel
    {
        public int Percent { get; set; }
        public string PercentDescription { get; set; }
    }
}
