using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeTube.Models
{
    public class Tube
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        [Required]
        public string YoutubeId { get; set; }

        [Required]
        public int Views { get; set; } = 0;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
