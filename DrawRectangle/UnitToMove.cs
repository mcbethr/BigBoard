using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DrawRectangle.RectangleShape;

namespace DrawRectangle
{
    public class UnitToMove
    {

        public MapPoint startingLocation { get; set; }
        public MapPoint endingLocation { get; set; }
        public int ID {get;set;} 

    }
}
