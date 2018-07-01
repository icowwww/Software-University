using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeTube.Web.Models
{
    public class TubeUploadModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string YoutubeId { get; set; }
        public string Description { get; set; }
    }
}
