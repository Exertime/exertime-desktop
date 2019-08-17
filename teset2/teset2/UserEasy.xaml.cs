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
    /// Interaction logic for UserEasy.xaml
    /// </summary>
    public partial class UserEasy : UserControl
    {
        public UserEasy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.TimerSet TimerSet = new TimerSet();
            TimerSet.Vedio.Content = "Repetition exercise";
            TimerSet.category = 4;
            contents.Children.Add(TimerSet);
          

        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.TimerSet TimerSet = new TimerSet();
            TimerSet.Vedio.Content = "Timed exercise";
            TimerSet.category = 4;
            contents.Children.Add(TimerSet);
          
        }
    }
}
