using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.UI.CommonTables
{
    public class TableUI
    {
        public string ApiUrl { get; set; }

        [JsonProperty("fields")]
        public FieldUI[] Fields { get; set; }

        /// <summary>
        /// Returns a string with the list of fields
        /// </summary>
        public string FieldString
        {
            get
            {
                string rtn = "";

                foreach (FieldUI f in Fields)
                {
                    rtn += (!string.IsNullOrEmpty(rtn) ? ", " : "") + $"{{ data: '{f.Data}'";
                    rtn += ", visible: " + f.Visible.ToString().ToLower();
                    if (!string.IsNullOrEmpty(f.Render))
                        rtn += ", render: " + f.Render;
                    rtn += " }";
                }

                return "[" + rtn + "]";
            }
        }
    }
}
