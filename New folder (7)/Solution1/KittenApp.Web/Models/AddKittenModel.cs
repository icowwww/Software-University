using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using KittenApp.Models.Enums;

namespace KittenApp.Web.Models
{
    public class AddKittenModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Breed { get; set; }
    }
}
