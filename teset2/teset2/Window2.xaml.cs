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
            //Loaded += new RoutedEventHandler(Window2_Loaded);
        }
        
        

        //private void Window2_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.Topmost = true;
        //    DisabledMouseKey();
        //}



        //private void DisabledMouseKey()
        //{
        //    hkb = new HookKeyBoard();
        //    hkb.keyeventhandler += new KeyEventHandler(keyhandler);
        //    hkb.InstallHook(this);
        //    HookKeyBoard.tagMSG Msgs;
        //    while (HookKeyBoard.GetMessage(out Msgs, IntPtr.Zero, 0, 0) > 0)
        //    {
        //        HookKeyBoard.TranslateMessage(ref Msgs);
        //        HookKeyBoard.DispatchMessage(ref Msgs);
        //    }
        //}

        //private void EnableMouseKey()
        //{
        //    hkb.Hook_Clear();
        //}

        /// <summary>
        /// an exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void keyhandler(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyData.ToString() == "a" || e.KeyData.ToString() == "A")
        //    {
        //        hkb.Hook_Clear();
        //    }
        //}
    

  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button1_Click1(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Menu.SelectedIndex;

            switch(index)

            {
                case 0:
                    contents.Children.Clear();
                    contents.Children.Add(new UserFavorite());
                    break;
                case 1:
                    contents.Children.Clear();
                    contents.Children.Add(new UserRandom());
                    break;
                case 2:
                    contents.Children.Clear();
                    contents.Children.Add(new UserAll());
                    break;
                case 3:
                    contents.Children.Clear();
                    contents.Children.Add(new UserEasy());
                    break;
                case 4:
                    contents.Children.Clear();
                    contents.Children.Add(new UserModerate());
                    break;
                case 5:
                    contents.Children.Clear();
                    contents.Children.Add(new UserChallenge());
                    break;

                default:
                    break;

            }


        }
    }
}