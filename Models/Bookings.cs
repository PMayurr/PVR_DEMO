using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace PVR.Models
{
    public class Bookings
    {
        public Guid Id { get; set; }
        public Users User { get; set; }
        public Movie Movie { get; set; }
        public int TicketCount { get; set; }
        public List<string> TicketList { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MovieDate { get; set; }

    }
}