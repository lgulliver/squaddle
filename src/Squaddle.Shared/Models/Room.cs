using Squaddle.Shared.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Squaddle.Shared.Models
{
    public class Room
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public RoomType RoomType { get; set; }
    }
}
