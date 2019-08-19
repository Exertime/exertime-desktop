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
using System.Text.RegularExpressions;

namespace teset2
{
    /// <summary>
    /// Interaction logic for submit.xaml
    /// </summary>
    public partial class submit : UserControl
    {
        public int value;
        public int type;


        public submit()
        {
           

            InitializeComponent();
         
        }
        public delegate void ExitDelegate();
        public event ExitDelegate exitEvent;

        public void limitnumber(object sender, TextCompositionEventArgs e)

        {

            Regex re = new Regex("[^0-9]+");

            e.Handled = re.IsMatch(e.Text);

        }

        public void statistics(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            contents.Children.Add(new UserStatistics());
            if (value == 1)
            {
                exitEvent();

            }
        }

        public void exit(object sender, RoutedEventArgs e)
        {
            if (value == 1)
            {
                exitEvent();

            }
        }
    }
}
