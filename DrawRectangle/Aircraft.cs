using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static DrawRectangle.RectangleShape;

namespace DrawRectangle
{
    public class Aircraft
    {

        public Point startingLocation { get; set; }

        public Point CurrentLocation { get; set; }
        public Point DestinationLocation { get; set; }
        public int ID {get;set;} 

        public Aircraft(Point starting, Point ending, int id)
        {
            this.startingLocation = starting;
            this.DestinationLocation = ending;
            ID = id;
        }

        public Aircraft(double startX,double startY,double endX,double endY, int id)
        {
            Point point = new Point();
            point.X = startX;
            point.Y = startY;
            this.startingLocation = point;

            point.X = endX;
            point.Y = endY;

            this.DestinationLocation = point;
            ID = id;
        }
    }
}
