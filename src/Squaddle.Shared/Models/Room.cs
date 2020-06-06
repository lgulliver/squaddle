using Squaddle.Shared.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Squaddle.Shared.Models
{
    public class Room
    {
        [Display(Name = "Room name")]
        [Required(ErrorMessage = "{0} is a required field.", AllowEmptyStrings = false)]
        public string Name { get; set; }
        public RoomType RoomType { get; set; }
        public string RoomCode { get; set; }
    }
}
