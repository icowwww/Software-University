using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography;
using System.Xml;

namespace Stations.Models
{
    public class Station
    {
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(50),Required]
        public string Town { get; set; }
        public ICollection<Trip> TripsTo { get; set; } = new List<Trip>();
        public ICollection<Trip> TripsFrom { get; set; } = new List<Trip>();
    }
}
