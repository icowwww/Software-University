using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]{2}[0-9]{1,6}$")]
        public string SeatingPlace { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int? CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }
}
