using System;
using System.Collections.Generic;
using System.Text;

namespace AmmaDeyyus.Services.Models
{
    public class GetAirportDistanceRequest
    {
        public string IATACode1 { get; set; }

        public string IATACode2 { get; set; }
    }
}