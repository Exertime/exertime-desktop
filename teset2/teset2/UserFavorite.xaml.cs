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

namespace teset2
{
    /// <summary>
    /// Interaction logic for UserFavorite.xaml
    /// </summary>
    public partial class UserFavorite : UserControl
    {
        public delegate void Delegate();
        public event Delegate exercise1,exercise2;
        public int value = 0;

        public UserFavorite()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //contents.Children.Clear();
            ////teset2.TimerSet TimerSet = new TimerSet();
            ////TimerSet.Vedio.Content = "Repetition exercise";
            ////TimerSet.category = 1;
            ////contents.Children.Add(TimerSet);

            ////teset2.Exercise exercise = new Exercise();
            ////exercise.exitEvent += new Exercise.ExitDelegate(AppearButton);
            ////exercise.tital.Visibility = Visibility.Visible;
            ////exercise.value = value;
            ////exercise.type = 1;
            ////contents.Children.Add(exercise);
            ////Window3 w3 = new Window3();
            ////w3.EnableMouseKey();

            exercise2();

        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //contents.Children.Clear();
            ////teset2.TimerSet TimerSet = new TimerSet();
            ////TimerSet.Vedio.Content = "Timed exercise";
            ////TimerSet.category = 1;
            ////contents.Children.Add(TimerSet);
            //teset2.Exercise exercise = new Exercise();
            //exercise.exitEvent += new Exercise.ExitDelegate(AppearButton);
            //exercise.value = value;
            //contents.Children.Add(exercise);
            exercise1();

        }

       
    }
}
