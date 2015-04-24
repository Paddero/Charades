using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Ink;

namespace Charades
{
    public partial class Drawing : PhoneApplicationPage
    {
        SolidColorBrush colorPicked;
        Stroke _colorStroke;
        System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int timeLeft = 120;

        public Drawing()
        {
            InitializeComponent();
            colorPicked = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            myDispatcherTimer.Tick += new EventHandler(Each_Tick);
            myDispatcherTimer.Start();
        }

        public void Each_Tick(object o, EventArgs sender)
        {
            textBlock1.Text = "Time Left: " + timeLeft--.ToString();

            if (timeLeft == 0)
            {
                globalVar.NumOfPlayersThatDrew++;
                globalVar.isDrawingDone = true;
                myDispatcherTimer.Stop();
                MessageBox.Show("Time is up!");
                NavigationService.Navigate(
                     new Uri("/GamePage.xaml",
                         UriKind.RelativeOrAbsolute)
                     );
            }
        }

        private void drawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            drawingCanvas.CaptureMouse();
            _colorStroke = new Stroke();
            _colorStroke.StylusPoints.Add(GetStylusPoint(e.GetPosition(drawingCanvas)));
            _colorStroke.DrawingAttributes.Color = colorPicked.Color;
            drawingCanvas.Strokes.Add(_colorStroke);
        }

        private StylusPoint GetStylusPoint(Point position)
        {
            return new StylusPoint(position.X, position.Y);
        }
        private void drawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_colorStroke != null)
            {
                _colorStroke.StylusPoints.Add(GetStylusPoint(e.GetPosition(drawingCanvas)));
            }
        }

        private void drawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _colorStroke = null;
        }

        private void SelectColor(object sender, MouseButtonEventArgs e)
        {
            Ellipse selectedEllipse = sender as Ellipse;
            colorPicked = selectedEllipse.Fill as SolidColorBrush;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.Strokes.Clear() ;
            //drawingCanvas.Children.Clear();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            myDispatcherTimer.Stop();
            globalVar.NumOfPlayersThatDrew++;
            globalVar.isDrawingDone = true;
            NavigationService.Navigate(
                     new Uri("/GamePage.xaml",
                         UriKind.RelativeOrAbsolute)
                     );
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
           myDispatcherTimer.Stop(); 
           NavigationService.Navigate(
                     new Uri("/GamePage.xaml",
                         UriKind.RelativeOrAbsolute)
                     );
            
        }
    }
}