using Squaddle.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squaddle.Shared.Models
{
    public class EstimationRoom : Room
    {
        public EstimationStyleType EstimationStyleType { get; set; }

        public EstimationRoom()
        {
            RoomType = RoomType.ESTIMATION;
            EstimationStyleType = EstimationStyleType.DEFAULT;
        }
    }
}
