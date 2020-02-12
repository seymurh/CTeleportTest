using System;
using System.Collections.Generic;
using System.Text;

namespace AmmaDeyyus.Services.Models
{
    public class AirportRequest : RequestBase
    {
        public string IATACode { get; set; }
    }
}