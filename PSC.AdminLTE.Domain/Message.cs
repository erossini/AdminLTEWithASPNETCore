using Newtonsoft.Json;
using PSC.AdminLTE.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.AdminLTE.Domain
{
    public class Message
    {
        /// <summary>
        /// Gets or sets the identifier message.
        /// </summary>
        /// <value>The identifier message.</value>
        [Key]
        public int IdMessage { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the receiver identifier.
        /// </summary>
        /// <value>The receiver identifier.</value>
        [JsonProperty("receiverId", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiverId { get; set; }

        /// <summary>
        /// Gets or sets the sender identifier.
        /// </summary>
        /// <value>The sender identifier.</value>
        [JsonProperty("senderId", NullValueHandling = NullValueHandling.Ignore)]
        public string SenderId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("statusId", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = "Unread";

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public string Priority { get; set; } = "Normal";

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        public bool IsNew { get; set; } = true;

        /// <summary>
        /// Hows the old.
        /// </summary>
        /// <returns>System.String.</returns>
        public string HowOld()
        {
            string rtn = "Now";

            TimeSpan days = (DateTime.UtcNow - Date);

            if (days.TotalDays > 0)
            {
                if (days.TotalDays == 1) rtn = DomainResources.DayAgo;
                if (days.TotalDays > 1) rtn = $"{Convert.ToInt16(days.TotalDays)} {DomainResources.DaysAgo}";
            }
            else
            {
                if (days.TotalHours > 0)
                    rtn = $"{Convert.ToInt16(days.TotalHours)} {DomainResources.HoursAgo}";
                else
                    rtn = $"{Convert.ToInt16(days.TotalMinutes)} {DomainResources.MinutesAgo}";
            }

            return rtn;
        }
    }
}
