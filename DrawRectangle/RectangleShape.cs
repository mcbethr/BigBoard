using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrawRectangle
{
    public class RectangleShape
    {

        public struct MapPoint
        {
            public double X;
            public double Y;
        }

        private Rect m_Rect;

        private MapPoint m_Corner;

        public MapPoint Corner
        {
            get { return m_Corner; }
        }

        public Rect GraphicRectangle { get { return m_Rect; } }

        public double Height
        {
            get;set;
               
            

        }
        public double Width
        {
            get;set;


        }

        public virtual void CreateShape(double anchorX, double anchorY, double dragX, double dragY)
        {
            MapPoint mouseAnchor = new MapPoint();
            MapPoint mouseDragPoint = new MapPoint();
            mouseAnchor.X = anchorX;
            mouseAnchor.Y = anchorY;
            mouseDragPoint.X = dragX;
            mouseDragPoint.Y = dragY;
            GenerateShape(mouseAnchor, mouseDragPoint);
        } 

        protected void GenerateShape(MapPoint mouseAnchor, MapPoint mouseDragPoint)
        {
            this.Width = Math.Abs(mouseAnchor.X - mouseDragPoint.X);
            this.Height = Math.Abs(mouseAnchor.Y - mouseDragPoint.Y);
            m_Rect.Location = new Point(mouseAnchor.X, mouseAnchor.Y);
            m_Rect.Size = new Size(this.Width,this.Height);


            CreateCorner(mouseAnchor, mouseDragPoint);
        }

        protected void CreateCorner(MapPoint mouseAnchor, MapPoint mouseDragPoint)
        {
            m_Corner.X = Math.Min(mouseAnchor.X, mouseDragPoint.X);
            m_Corner.Y = Math.Min(mouseAnchor.Y, mouseDragPoint.Y);
        }

    }


    public class SquareShape : RectangleShape
    {

        public override void CreateShape(double anchorX, double anchorY, double dragX, double dragY)
        {
            MapPoint mouseAnchor = new MapPoint();
            MapPoint mouseDragPoint = new MapPoint();
            mouseAnchor.X = anchorX;
            mouseAnchor.Y = anchorY;
            mouseDragPoint.X = dragX;
            mouseDragPoint.Y = (dragX - anchorX) + anchorY;
            GenerateShape(mouseAnchor, mouseDragPoint);
        }


    }


}
