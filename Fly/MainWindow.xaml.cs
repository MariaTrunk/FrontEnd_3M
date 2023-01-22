using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Fly
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random();
        double x = 100;
        double y = 100;
        double curX = 100;
        double curY = 100;
        //private double speedX = 200;
        // private double speedY = 300;
        private double speed = 200;
        int count = 0;  
        

        private TimeSpan prevTime;
        private Stopwatch stopwatch = Stopwatch.StartNew();
       

        public MainWindow()
        {
            InitializeComponent();
            
           
                prevTime = stopwatch.Elapsed;
                CompositionTarget.Rendering += CompositionTarget_Rendering;
            
           
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            var currentTime = stopwatch.Elapsed;
            var delta = (currentTime - prevTime).TotalSeconds;
            prevTime = currentTime;

            lblInfo.Content = delta;

            curX = curX + speed * delta;
            curY = curY + speed * delta;

            if (curX != x && curY != y)
            {
                if (curX < x)
                {
                    speed = -speed;
                    curX = x;

                }
                else if (curX > x)
                {
                    speed = -speed;
                    curX = x;

                }
                if (curY < y)
                {
                    speed = -speed;
                    curY = y;

                }
                else if (curY > y)
                {
                    speed = -speed;
                    curY = y;

                }
                
            }

            
            Canvas.SetTop(fly, curY);
            Canvas.SetLeft(fly, curX);

        }

        private void fly_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Image)
            {
                x = Convert.ToDouble(r.Next((int)MyCanvas.ActualWidth - (int)fly.Width) );
                y = Convert.ToDouble(r.Next((int)MyCanvas.ActualHeight - (int)fly.Height) );

               
                count ++;
                lblScore.Content = count;
                
                
            }
        }
    }
}
