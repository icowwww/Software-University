using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KittenApp.Models.Enums
{
    public enum Breed
    {
        [Display(Name = "Street Transcended")]
        StreetTranscended,
        Shorthair,
        Munchkin,
        Siamese
    }
}
