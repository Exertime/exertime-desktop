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
        private Grid CON;
        public Window3()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window3_Loaded);
            CON = this.contents;

            
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
            all.exercise += new UserAll.Delegate(exercisePage1);
            //all.value = 1;
            contents.Children.Add(all);
            Level.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }

        private void OAll()
        {
            contents.Children.Clear();
            teset2.UserAll all = new UserAll();
            all.exercise += new UserAll.Delegate(exercisePage1);
            //all.value = 1;
            contents.Children.Add(all);
            Level.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }

        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.UserFavorite favorite = new UserFavorite();
            favorite.exercise1 += new UserFavorite.Delegate(exercisePage1);
            favorite.exercise2 += new UserFavorite.Delegate(exercisePage2);
           //favorite.value = 1;
            contents.Children.Add(favorite);
            Level.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }

        private void OFAV()
        {
            contents.Children.Clear();
            teset2.UserFavorite favorite = new UserFavorite();
            favorite.exercise1 += new UserFavorite.Delegate(exercisePage1);
            favorite.exercise2 += new UserFavorite.Delegate(exercisePage2);
            //favorite.value = 1;
            contents.Children.Add(favorite);
            Level.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }
    
        private void Random_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.UserRandom Ran = new UserRandom();
            Ran.exercise1 += new UserRandom.Delegate(exercisePage1);
            Ran.exercise2 += new UserRandom.Delegate(exercisePage2);
            //Ran.value = 1;
            contents.Children.Add(Ran);
            Back.Visibility = Visibility.Visible;
        }

        private void ORAN()
        {
            contents.Children.Clear();
            teset2.UserRandom Ran = new UserRandom();
            Ran.exercise1 += new UserRandom.Delegate(exercisePage1);
            Ran.exercise2 += new UserRandom.Delegate(exercisePage2);
            //Ran.value = 1;
            contents.Children.Add(Ran);
            Back.Visibility = Visibility.Visible;
        }



        private void Back_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.Original original = new Original();
            original.all += new Original.Delegate(OAll);
            original.fav += new Original.Delegate(OFAV);
            original.ran += new Original.Delegate(ORAN);
            contents.Children.Add(original);
            Level.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
        }

        //private void AppearButton()
        //{
        //    Level.Visibility = Visibility.Visible;
        //}
        //private void levelHid()
        //{
        //    Level.Visibility = Visibility.Hidden;
        //}
        public delegate void Delegate();
        public event Delegate window;

        private void AppearButton1()
        {
            window();
            this.Close();
        }

        //private void AppearButton2()
        //{
        //    Back.Visibility = Visibility.Visible;
        //}
        private string time;
        private Exercise Ex;

        private void exercisePage1()
        {
            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage1);
            Ex = ex;
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private void exercisePage2()
        {
            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage2);
            Ex = ex;
            ex.tital.Visibility = Visibility.Visible;
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private void submitPage1()
        {
            contents.Children.Clear();
            teset2.submit sub = new submit();
            sub.Statistics.Visibility = Visibility.Visible;

            sub.Tital.Text = Ex.time;
            sub.EX.Visibility = Visibility.Visible;
            sub.exitEvent += new submit.ExitDelegate(AppearButton1);
            sub.STAT += new submit.ExitDelegate(statisticsPage);
            //if (value == 1)
            //{
            //    sub.EX.Visibility = Visibility.Visible;
            //    sub.value = 1;
            //}
            //sub.type = this.type;
            //if (type == 1)
            //{
            //    sub.repetition.Visibility = Visibility.Visible;
            //    sub.Rep.Visibility = Visibility.Visible;
            //}
            contents.Children.Add(sub);
        }

        private void submitPage2()
        {
            contents.Children.Clear();
            teset2.submit sub = new submit();

            sub.Tital.Text = Ex.time;
            sub.repetition.Visibility = Visibility.Visible;
            sub.Rep.Visibility = Visibility.Visible;
            sub.EX.Visibility = Visibility.Visible;
            sub.exitEvent += new submit.ExitDelegate(AppearButton1);
            //if (value == 1)
            //{
            //    sub.EX.Visibility = Visibility.Visible;
            //    sub.value = 1;
            //}
            //sub.type = this.type;
            //if (type == 1)
            //{
            //    sub.repetition.Visibility = Visibility.Visible;
            //    sub.Rep.Visibility = Visibility.Visible;
            //}
            contents.Children.Add(sub);
        }


        private void AppearButton()
        {
            exit.Visibility = Visibility.Visible;
        }

        private void statisticsPage()
        {
            contents.Children.Clear();
            teset2.UserStatistics statistics = new UserStatistics();
            statistics.exitEvent += new UserStatistics.ExitDelegate(AppearButton1);
          
                statistics.EX.Visibility = Visibility.Visible;
            
            contents.Children.Add(statistics);

        }

    }
}
