using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Squaddle.Shared.Models
{
    public class RoomUser
    {
        [Required(AllowEmptyStrings = false)]
        [Display(Name ="Your Name")]
        [MinLength(2, ErrorMessage = "{0} is too short! It must be at least {1} characters long")]
        public string Name { get; set; }

        public bool IsRoomOwner { get; set; }
        
        [Required]
        [Display(Name = "Room Code")]
        [MinLength(8, ErrorMessage ="{0} entered is invalid")]
        [MaxLength(8, ErrorMessage = "{0} entered is invalid")]
        public string RoomCode { get; set; }

    }
}
