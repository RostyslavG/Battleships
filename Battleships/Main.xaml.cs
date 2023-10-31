using Battleships.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Battleships
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        VictoryWindow v;
        private Random rnd;
        List<(int, int)> usedCoordinates;
        //private bool isDragging;
        //private Point startPoint;
        public Main()
        {
            InitializeComponent();
            rnd= new Random();
            usedCoordinates= new List<(int, int)> ();
            v  = new VictoryWindow();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ThicknessAnimation a = new ThicknessAnimation();
            a.From = new Thickness(10);
            a.To = new Thickness(1);
            a.Duration = TimeSpan.FromSeconds(1);
            (sender as Border).BeginAnimation(BorderThicknessProperty, a);
            var brd = sender as Border;
            var cellVM = brd.DataContext as CellVM;
            cellVM.Shoot();

            var batVM = DataContext as BattleshipsVM;
            while (true)
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);

                if (!usedCoordinates.Contains((x, y)))
                {
                    batVM.ShootToAs(y, x);
                    usedCoordinates.Add((x, y));
                    break;
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menuMusic.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fon.ImageSource = new BitmapImage(new Uri("C:\\Users\\Fuck the war!\\Desktop\\Battleships\\Battleships\\Images\\main4.jpg", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            menuMusic.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            v.ShowDialog();
        }
        //private void image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    image.RenderTransformOrigin = new Point(0.2, 0.2);
        //    image.RenderTransform = new RotateTransform(90);  
        //}

        //private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.RightButton == MouseButtonState.Pressed)
        //    {
        //        image.RenderTransformOrigin = new Point(0.2, 0.2);  
        //        image.RenderTransform = new RotateTransform(90);   
        //    }
        //    else
        //    {
        //        isDragging = true;
        //        startPoint = e.GetPosition(Player1Grid);
        //        image.CaptureMouse();
        //    }
        //}

        //private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    isDragging = false;
        //    image.ReleaseMouseCapture();
        //}

        //private void image_MouseMove_1(object sender, MouseEventArgs e)
        //{
        //    if (isDragging)
        //    {
        //        int column = Grid.GetColumn(image);
        //        int row = Grid.GetRow(image);
        //        Point position = e.GetPosition(Player1Grid);
        //        int newColumn = (int)(position.X / image.ActualWidth);
        //        int newRow = (int)(position.Y / image.ActualHeight);
        //        if (newColumn >= 0 && newColumn < Player1Grid.ColumnDefinitions.Count && newRow >= 0 && newRow < Player1Grid.RowDefinitions.Count)
        //        {
        //            Grid.SetColumn(image, newColumn);
        //            Grid.SetRow(image, newRow);
        //        }
        //        if (newColumn == Player1Grid.ColumnDefinitions.Count - 1)
        //        {
        //        }
        //    }
        //}
    }
}
