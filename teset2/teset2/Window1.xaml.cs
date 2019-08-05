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
using System.Windows.Shapes;
using System.Threading;
namespace teset2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int Choice;
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();

            if (cmb.SelectedIndex == 0)
            {
                Choice = 5000;
            }
            else if (cmb.SelectedIndex == 1)
            {
                Choice = 10000;
            }
            else if (cmb.SelectedIndex == 2)
            {
                Choice = 15000;
            }
            else if (cmb.SelectedIndex == 3)
            {
                Choice = 20000;
            }
            Thread t = new Thread(new ThreadStart(() =>
        {
            Thread.Sleep(Choice);
            Window1 w1 = new Window1();
            w1.Top = 573;
            w1.Left = 980;
            w1.Show();
            System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
        }));
            t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
            t.IsBackground = true;
            t.Start();

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           // this.Close();
            Window3 w3 = new Window3();
            w3.Show();
        }
    }
}
        
    

