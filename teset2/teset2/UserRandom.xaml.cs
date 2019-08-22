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
    /// Interaction logic for UserRandom.xaml
    /// </summary>
    public partial class UserRandom : UserControl
    {
        public delegate void ExitDelegate();
        public event ExitDelegate exitEvent,level;
        public int value = 0;
        public UserRandom()
        {
            InitializeComponent();
        }

         private void Button_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            //teset2.TimerSet TimerSet = new TimerSet();
            //TimerSet.Vedio.Content = "Repetition exercise";
            //TimerSet.category = 1;
            //contents.Children.Add(TimerSet);
            teset2.Exercise exercise = new Exercise();
            exercise.exitEvent += new Exercise.ExitDelegate(AppearButton);
            exercise.tital.Visibility = Visibility.Visible;
            exercise.value = value;
            exercise.type = 1;
            contents.Children.Add(exercise);
            //Window3 w3 = new Window3();
            //w3.EnableMouseKey();
            level();


        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            //teset2.TimerSet TimerSet = new TimerSet();
            //TimerSet.Vedio.Content = "Timed exercise";
            //TimerSet.category = 1;
            //contents.Children.Add(TimerSet);
            teset2.Exercise exercise = new Exercise();
            exercise.exitEvent += new Exercise.ExitDelegate(AppearButton);
            exercise.value = value;
            contents.Children.Add(exercise);
            level();

        }

        private void AppearButton()
        {
            exitEvent();
        }
    }
}
