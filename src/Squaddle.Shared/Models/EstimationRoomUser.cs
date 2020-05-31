using Squaddle.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squaddle.Shared.Models
{
    public class EstimationRoomUser : RoomUser
    {
        public EstimationStyleType EstimationStyleType { get; set; }

        public EstimationRoomUser()
        {
            EstimationStyleType = EstimationStyleType.DEFAULT;
        }
    }

}
