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
using System.Windows.Threading;

namespace teset2
{
    /// <summary>
    /// Interaction logic for submit.xaml
    /// </summary>
    public partial class submit : UserControl
    {
        public int value;
        public int type;
        public string text = "0";

        public submit()
        {

           InitializeComponent();
           
         
        }
        public delegate void ExitDelegate();
        public event ExitDelegate exitEvent,STAT,sub;

        public void limitnumber(object sender, TextCompositionEventArgs e)

        {

            Regex re = new Regex("[^0-9]+");

            e.Handled = re.IsMatch(e.Text);

        }

        public void statistics(object sender, RoutedEventArgs e)
        {
       
            STAT();
            sub();
        }

        private void Rep_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            text = Rep.Text;
            sub();
            exitEvent();
          


        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            int num = Int32.Parse(Rep.Text);
            num++;
            Rep.Text = num.ToString();
        }

        private void minus_click(object sender, RoutedEventArgs e)
        {
            int num = Int32.Parse(Rep.Text);
            num--;
            Rep.Text = num.ToString();
        }

        private void Submit_Click(object sender,RoutedEventArgs e)
        {
          text = Rep.Text;
            sub();
        }
    }
}
