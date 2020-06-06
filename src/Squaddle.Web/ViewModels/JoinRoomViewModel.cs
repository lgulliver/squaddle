using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Squaddle.Web.ViewModels
{
    public class JoinRoomViewModel
    {
        [Display(Name = "Your name")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Room code")]
        [Required]
        public string RoomCode { get; set; }
    }
}
