using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using teset2;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;



namespace teset2
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>

    public partial class Window3 : Window
    {
        

        private HookKeyBoard hkb = null;
        Grid CON;
        public Window3()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window3_Loaded);
            Grid CON = this.contents;

            
        }
        private void Window3_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
           // DisabledMouseKey();
        }



        private void DisabledMouseKey()
        {
            hkb = new HookKeyBoard();
            hkb.keyeventhandler += new KeyEventHandler(keyhandler);
            hkb.InstallHook(this);
            HookKeyBoard.tagMSG Msgs;
            while (HookKeyBoard.GetMessage(out Msgs, IntPtr.Zero, 0, 0) > 0)
            {
                HookKeyBoard.TranslateMessage(ref Msgs);
                HookKeyBoard.DispatchMessage(ref Msgs);
            }
        }

        public void EnableMouseKey()
        {
            hkb.Hook_Clear();
        }

        /// <summary>
        /// an exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyhandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "a" || e.KeyData.ToString() == "A")
            {
                hkb.Hook_Clear();
            }
        }

  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button1_Click1(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.UserAll all = new UserAll();
            contents.Children.Add(all);
            Level.Visibility = Visibility.Visible;
           // Back.Visibility = Visibility.Visible;
        }
        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.UserFavorite favorite = new UserFavorite();
            favorite.exitEvent += new UserFavorite.ExitDelegate(AppearButton1);
            favorite.level += new UserFavorite.ExitDelegate(levelHid);
            favorite.value = 1;
            contents.Children.Add(favorite);
            Level.Visibility = Visibility.Visible;
          //  Back.Visibility = Visibility.Visible;
        }
        private void Random_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.UserRandom Ran = new UserRandom();
            Ran.exitEvent += new UserRandom.ExitDelegate(AppearButton1);
            Ran.level += new UserRandom.ExitDelegate(levelHid);
            Ran.value = 1;
            contents.Children.Add(Ran);
           // Back.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.Original original = new Original();
            original.exitEvent += new Original.AppearButtonDelegate(AppearButton1);
            original.type = 1;
            //original.back += new Original.AppearButtonDelegate(AppearButton2);
            contents.Children.Add(original);
            Level.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
        }

        private void AppearButton()
        {
            Level.Visibility = Visibility.Visible;
        }
        private void levelHid()
        {
            Level.Visibility = Visibility.Hidden;
        }

        private void AppearButton1()
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(() =>
            {

                Thread.Sleep(5000);
                Window1 w1 = new Window1();
                w1.WindowStartupLocation = WindowStartupLocation.Manual;


                w1.Show();
                System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
            }));
            t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
            t.IsBackground = true;
            t.Start();
        }

        //private void AppearButton2()
        //{
        //    Back.Visibility = Visibility.Visible;
        //}




    }
}
