using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace WebAppForShowingWarsawTramsLocalization.Models
{
    public class WebTramLocation
    {
        public string Status { get; set; }

        public string FirstLine { get; set; }

        public double Lon { get; set; }

        public string Lines { get; set; }

        public DateTime? Time { get; set; }

        public double Lat { get; set; }

        public bool LowFloor { get; set; }

        public string Brigade { get; set; }

        public WebTramLocation()
        {

        }

        public WebTramLocation(TramLocation data)
        {
            Status = data.Status;
            FirstLine = data.FirstLine;
            Lon = data.Lon;
            Lines = data.Lines;
            Time = data.Time;
            Lat = data.Lat;
            LowFloor = data.LowFloor;
            Brigade = data.Brigade;
        }

        public TramLocation ToEntity()
        {
            return new TramLocation
            {
                Brigade = Brigade,
                FirstLine = FirstLine,
                Lat = Lat,
                Lines = Lines,
                Lon = Lon,
                LowFloor = LowFloor,
                Status = Status,
                Time = Time
            };
        }
    }
}
