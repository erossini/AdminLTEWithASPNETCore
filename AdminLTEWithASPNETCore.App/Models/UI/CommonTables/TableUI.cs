using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.UI.CommonTables
{
    /// <summary>
    /// Class TableUI.
    /// </summary>
    public class TableUI
    {
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        /// <value>The API URL.</value>
        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the create URL.
        /// </summary>
        /// <value>The create URL.</value>
        [JsonProperty("createUrl")]
        public string CreateUrl { get; set; }

        /// <summary>
        /// Gets or sets the delete URL.
        /// </summary>
        /// <value>The delete URL.</value>
        [JsonProperty("editUrl")]
        public string DeleteUrl { get; set; }

        /// <summary>
        /// Gets or sets the edit URL.
        /// </summary>
        /// <value>The edit URL.</value>
        [JsonProperty("editUrl")]
        public string EditUrl { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>The fields.</value>
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

        /// <summary>
        /// Gets a value indicating whether this instance is create allow.
        /// </summary>
        /// <value><c>true</c> if this instance is create allow; otherwise, <c>false</c>.</value>
        [JsonProperty("isCreateAllow")]
        public bool IsCreateAllow => !string.IsNullOrEmpty(CreateUrl);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is delete allow.
        /// </summary>
        /// <value><c>true</c> if this instance is delete allow; otherwise, <c>false</c>.</value>
        [JsonProperty("isDeleteAllow")]
        public bool IsDeleteAllow => !string.IsNullOrEmpty(DeleteUrl);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is edit allow.
        /// </summary>
        /// <value><c>true</c> if this instance is edit allow; otherwise, <c>false</c>.</value>
        [JsonProperty("isEditAllow")]
        public bool IsEditAllow => !string.IsNullOrEmpty(EditUrl);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is view allow.
        /// </summary>
        /// <value><c>true</c> if this instance is view allow; otherwise, <c>false</c>.</value>
        [JsonProperty("isViewAllow")]
        public bool IsViewAllow => !string.IsNullOrEmpty(ViewUrl);

        /// <summary>
        /// Gets or sets the view URL.
        /// </summary>
        /// <value>The view URL.</value>
        [JsonProperty("viewUrl")]
        public string ViewUrl { get; set; }
    }
}
