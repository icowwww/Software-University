using System;
using System.Collections.Generic;
using System.Text;
using KittenApp.Models.Enums;

namespace KittenApp.Models
{
    public class Kitten
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Breed Breed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
