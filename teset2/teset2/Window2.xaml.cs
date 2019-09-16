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
       // private HookKeyBoard hkb = null;

       // private string exerciesName;

        private UserAll UA;
        private UserAll temp;
        public Window2()
        {
            InitializeComponent();
            contents.Children.Clear();
            teset2.UserAll all = new UserAll();
            all.exercise += new UserAll.Delegate(exercisePage1);
            temp = all;
            contents.Children.Add(all);

        }



  

        /// <summary>
        /// an exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button1_Click1(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

      
        private void CFavorite_Click(object sender, RoutedEventArgs e)
        {
           
            contents.Children.Clear();
            teset2.UserFavorite favorite = new UserFavorite();
            favorite.exercise1 += new UserFavorite.Delegate(exercisePage1);
            favorite.exercise2 += new UserFavorite.Delegate(exercisePage2);

            contents.Children.Add(favorite);
            Level.Visibility = Visibility.Visible;
        
    }

        private void CStatics_Click(object sender, RoutedEventArgs e)
        {
           
            contents.Children.Clear();
            contents.Children.Add(new UserStatistics());
            Level.Visibility = Visibility.Hidden;
        }

        private void CSettings_Click(object sender, RoutedEventArgs e)
        {
           
            contents.Children.Clear();
            Level.Visibility = Visibility.Hidden;
            contents.Children.Add(new UserSetting());
        }

        private void CAll_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.UserAll all = new UserAll();
            all.exercise += new UserAll.Delegate(exercisePage1);
            temp = all;
            contents.Children.Add(all);

            Level.Visibility = Visibility.Visible;
        }

        private string time;
        private Exercise Ex;
       
        private void exercisePage1()
        {
            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage1);
            ex.id = temp.id;
            Ex = ex;
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private void exercisePage2()
        {
            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage2);
            ex.id = temp.id;
            Ex = ex;           
            ex.tital.Visibility = Visibility.Visible;
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private submit subtext;

        private void submitPage1()
        {
            contents.Children.Clear();
            teset2.submit sub = new submit();
            sub.Sub.Visibility = Visibility;

            sub.Tital.Text = Ex.time;
            sub.sub += new submit.ExitDelegate(Sub);
            subtext = sub;
            //sub.exitEvent += new submit.ExitDelegate(AppearButton);
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
            sub.Sub.Visibility = Visibility;
            subtext = sub;
            sub.Tital.Text = Ex.time;
            sub.repetition.Visibility = Visibility.Visible;
            sub.Rep.Visibility = Visibility.Visible;
            sub.sub += new submit.ExitDelegate(Sub);
            //sub.exitEvent += new submit.ExitDelegate(AppearButton);
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

        private void Sub()
        {
            DataAccess.Submit("UA.exerciseName", Ex.CD, subtext.text, Ex.type);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.easy();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.moderate();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.challenge();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.all();
        }


    }
}