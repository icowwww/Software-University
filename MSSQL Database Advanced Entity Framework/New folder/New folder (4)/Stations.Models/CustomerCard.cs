using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Stations.Models.Enums;

namespace Stations.Models
{
    public class CustomerCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0,120)]
        public int Age { get; set; }
        public CardType Type { get; set; }
        public ICollection<Ticket> BoughtTickets { get; set; } = new List<Ticket>();
    }
}
