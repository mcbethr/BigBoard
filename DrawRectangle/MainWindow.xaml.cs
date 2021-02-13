using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DrawRectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _isDragging = false;

        private Point _anchorPoint = new Point();



        public MainWindow()
        {

            InitializeComponent();

        }

        private void LayoutRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
        }

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            // if dragging, then adjust rectangle position based on mouse movement
            if (_isDragging == true)
            {

                SquareShape RS = new SquareShape();
                RS.CreateShape(_anchorPoint.X, _anchorPoint.Y, e.GetPosition(BackPlane).X, e.GetPosition(BackPlane).Y);


                //double x = e.GetPosition(BackPlane).X;
                //double y = e.GetPosition(BackPlane).Y;

                Rect.SetValue(Canvas.LeftProperty, RS.Corner.X);
                Rect.SetValue(Canvas.TopProperty, RS.Corner.Y);

                Rect.Width = RS.Width;
                Rect.Height = RS.Height;


                //Rect.Width = Math.Abs(x - _anchorPoint.X);
                //Rect.Height = Math.Abs(y - _anchorPoint.Y);

                if (Rect.Visibility != Visibility.Visible)
                {
                    Rect.Visibility = Visibility.Visible;
                }


            }
        }

    
        private void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetRect();
            Rectangle Permanant = new Rectangle();

            SquareShape RS = new SquareShape();

            RS.CreateShape(_anchorPoint.X, _anchorPoint.Y, e.GetPosition(BackPlane).X, e.GetPosition(BackPlane).Y);

            Permanant.SetValue(Canvas.LeftProperty, RS.Corner.X);
            Permanant.SetValue(Canvas.TopProperty, RS.Corner.Y);

            Permanant.Width = RS.Width;
            Permanant.Height = RS.Height;
            Permanant.Fill = new SolidColorBrush(Colors.Orange);
            Permanant.Opacity = .5;


            Permanant.StrokeThickness = 2;
            BackPlane.Children.Add(Permanant);

            SelectAircraft SA = new SelectAircraft(RS);

            DrawCircle();

            /*
            ResetRect();
            Rectangle Permanant = new Rectangle();
            double x = e.GetPosition(BackPlane).X;
            double y = e.GetPosition(BackPlane).Y;

            Permanant.SetValue(Canvas.LeftProperty, Math.Min(x, _anchorPoint.X));
            Permanant.SetValue(Canvas.TopProperty, Math.Min(y, _anchorPoint.Y));


            Permanant.Width = Math.Abs(x - _anchorPoint.X);
            Permanant.Height = Math.Abs(y - _anchorPoint.Y);
            Permanant.Fill = new SolidColorBrush(Colors.Orange);
            Permanant.Opacity = .5;


            Permanant.StrokeThickness = 2;
            BackPlane.Children.Add(Permanant); 
            */
        }


        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetRect();
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _anchorPoint.X = e.GetPosition(BackPlane).X;
            _anchorPoint.Y = e.GetPosition(BackPlane).Y;
            _isDragging = true;
        }

        private void ResetRect()
        {
            Rect.Visibility = Visibility.Collapsed;
            _isDragging = false;
        }

        private void DrawCircle()
        {
            Ellipse Dot = new Ellipse();
            

            Dot.SetValue(Canvas.LeftProperty, (double)10);
            Dot.SetValue(Canvas.TopProperty, (double)10);
            Dot.Width = 4;
            Dot.Height = 4;
            Dot.Fill = new SolidColorBrush(Colors.Red);

            BackPlane.Children.Add(Dot);
        }

    }


    
}
