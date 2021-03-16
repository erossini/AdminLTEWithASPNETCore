using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Services.AspNetCore.Models.Responses
{
    public class AzureCostResponse
    {
        public long ID { get; set; }
        public string ResourceName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
