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
using System.Timers;
using System.Threading;

namespace teset2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

        }

   //private void win3()
   //     {
   //         Window3 w3 = new Window3();
   //         w3.window += new Window3.Delegate(restart);
   //         w3.Show();
   //     }

        //private void restart()
        //{
        //    Thread t = new Thread(new ThreadStart(() =>
        //    {

        //        Thread.Sleep(5000);
        //        Window1 w1 = new Window1();
        //        w1.window += new Window1.Delegate(win3);
        //        w1.WindowStartupLocation = WindowStartupLocation.Manual;


        //        w1.Show();
        //        System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
        //    }));
        //    t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
        //    t.IsBackground = true;
        //    t.Start();
        //}

        private void btnlogin_Click(object sender,RoutedEventArgs e)
        {

            DataAccess.login(UserTextBox.Text, PwdTextBox.Text);
            Window2 w2 = new Window2();

            w2.Show();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }


    }
}
