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
        bool m_isDragging = false;

        private Point m_anchorPoint = new Point();

        private List<Aircraft> m_AircraftInFlight;

        public MainWindow()
        {

            InitializeComponent();
            m_AircraftInFlight = new List<Aircraft>();
            m_AircraftInFlight.Add(new Aircraft(20, 110, 100, 100, 1));
            
            m_AircraftInFlight.Add(new Aircraft(200, 100, 200, 200, 2));
            m_AircraftInFlight.Add(new Aircraft(700, 110, 100, 100, 3));
            m_AircraftInFlight.Add(new Aircraft(950, 102, 500, 500, 4));
            m_AircraftInFlight.Add(new Aircraft(120, 110, 100, 100, 5));
            m_AircraftInFlight.Add(new Aircraft(520, 120, 200, 200, 6));
            m_AircraftInFlight.Add(new Aircraft(720, 110, 100, 100, 7));
            m_AircraftInFlight.Add(new Aircraft(750, 140, 500, 500, 8));
            m_AircraftInFlight.Add(new Aircraft(170, 200, 100, 100, 5));
            m_AircraftInFlight.Add(new Aircraft(620, 120, 200, 200, 6));
            m_AircraftInFlight.Add(new Aircraft(820, 130, 100, 100, 7));
            m_AircraftInFlight.Add(new Aircraft(900, 140, 500, 500, 8));
            

            foreach (var i in m_AircraftInFlight)
            {
                DrawCircle(i.startingLocation);
            }
 
        }

        private void LayoutRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
        }

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            // if dragging, then adjust rectangle position based on mouse movement
            if (m_isDragging == true)
            {

                //RectangleShape shape = new SquareShape();
                RectangleShape shape = new RectangleShape();
                shape.CreateShape(m_anchorPoint.X, m_anchorPoint.Y, e.GetPosition(BackPlane).X, e.GetPosition(BackPlane).Y);

                Rect.SetValue(Canvas.LeftProperty, shape.Corner.X);
                Rect.SetValue(Canvas.TopProperty, shape.Corner.Y);

                Rect.Width = shape.Width;
                Rect.Height = shape.Height;



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

            //RectangleShape shape = new SquareShape();
            RectangleShape shape = new RectangleShape();

            shape.CreateShape(m_anchorPoint.X, m_anchorPoint.Y, e.GetPosition(BackPlane).X, e.GetPosition(BackPlane).Y);

            Permanant.SetValue(Canvas.LeftProperty, shape.Corner.X);
            Permanant.SetValue(Canvas.TopProperty, shape.Corner.Y);

            Permanant.Width = shape.Width;
            Permanant.Height = shape.Height;
            Permanant.Fill = new SolidColorBrush(Colors.Orange);
            Permanant.Opacity = .5;
            Permanant.StrokeThickness = 2;

            BackPlane.Children.Add(Permanant);
           

            RecallEngine RE = new RecallEngine(m_AircraftInFlight, shape);
            recallButton.IsEnabled = RE.ConfirmSelectedAircraft();

       
        }


        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetRect();
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            m_anchorPoint.X = e.GetPosition(BackPlane).X;
            m_anchorPoint.Y = e.GetPosition(BackPlane).Y;
            m_isDragging = true;
        }

        private void ResetRect()
        {
            Rect.Visibility = Visibility.Collapsed;
            m_isDragging = false;
        }

        private void DrawCircle(Point point)
        {
            Ellipse Dot = new Ellipse();
            

            Dot.SetValue(Canvas.LeftProperty, (double)point.X);
            Dot.SetValue(Canvas.TopProperty, (double)point.Y);
            Dot.Width = 4;
            Dot.Height = 4;
            Dot.Fill = new SolidColorBrush(Colors.Red);

            BackPlane.Children.Add(Dot);
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            BackPlane.Children.Clear();
        }

        private void recall_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recall Code Sent!");
        }
    }


    
}
