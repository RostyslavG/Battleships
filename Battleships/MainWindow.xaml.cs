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
using System.Media;

namespace Battleships
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Main mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow= new Main();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menuMusic.Play();
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            menuMusic.Pause();
        }

        private void Border_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void Border_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            autors.IsOpen = true;
        }

        private void CloseBT_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            autors.IsOpen = false;
        }

        private void CloseBT1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            manual.IsOpen= false;
        }

        private void Border_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            manual.IsOpen = true;
        }
    }
}
