using System;

namespace Stupeni.FSA.Blazor.Models
{
    public class BookingData
    {
        public string DepartureCity { get; set; }

        public string DestinationCity { get; set; }

        public DateTime? DepartureDate { get; set; }

        public double? MinimalPrice { get; set; }

        public double? MaximalPrice { get; set; }
    }
}
