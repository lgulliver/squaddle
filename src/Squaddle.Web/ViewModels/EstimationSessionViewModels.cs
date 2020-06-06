using Squaddle.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squaddle.Web.ViewModels
{
    public class NewEstimationSessionViewModel
    {
        public EstimationRoom Room { get; set; }
        public RoomUser RoomCreator { get; set; }

        public NewEstimationSessionViewModel()
        {
            Room = new EstimationRoom();
            RoomCreator = new RoomUser();
        }
    }
}
