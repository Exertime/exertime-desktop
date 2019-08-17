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

namespace teset2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private HookKeyBoard hkb = null;
      

        public Window2()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window2_Loaded);
        }
        
        

        private void Window2_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            DisabledMouseKey();
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

        private void EnableMouseKey()
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
            FirstScreen.Visibility = Visibility.Hidden;
            Categories.Visibility = Visibility.Visible;
            contents.Children.Clear();
            contents.Children.Add(new UserFavorite());
        }

        private void Favourites_Click(object sender, RoutedEventArgs e)
        {
            FirstScreen.Visibility = Visibility.Hidden;
            Categories.Visibility = Visibility.Visible;
            contents.Children.Clear();
            contents.Children.Add(new UserAll());
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            FirstScreen.Visibility = Visibility.Hidden;
            Categories.Visibility = Visibility.Visible;
            contents.Children.Clear();
            contents.Children.Add(new UserRandom());
        }

        private void CAll_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            Level.Visibility = Visibility.Visible; 

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Categories.Visibility = Visibility.Hidden;
            FirstScreen.Visibility = Visibility.Visible;
            Level.Visibility = Visibility.Hidden;
            contents.Children.Clear();

        }

        private void CFavorite_Click(object sender, RoutedEventArgs e)
        {
            Level.Visibility = Visibility.Hidden;
            contents.Children.Clear();
        }

        private void CStatics_Click(object sender, RoutedEventArgs e)
        {
            Level.Visibility = Visibility.Hidden;
            contents.Children.Clear();
        }

        private void CSettings_Click(object sender, RoutedEventArgs e)
        {
            Level.Visibility = Visibility.Hidden;
            contents.Children.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Back button

            FirstScreen.Visibility = Visibility.Visible;
            GridMenu.Visibility = Visibility.Visible;

            Level.Visibility = Visibility.Hidden;
            Time.Visibility = Visibility.Hidden;
            Categories.Visibility = Visibility.Hidden;
            contents.Children.Clear();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Play exercise

            FirstScreen.Visibility = Visibility.Hidden;
            Level.Visibility = Visibility.Hidden;
            GridMenu.Visibility = Visibility.Hidden;
            Time.Visibility = Visibility.Visible;
            contents.Children.Clear();
        }
    }
}