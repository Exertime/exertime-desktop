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
    /// Interaction logic for TimerSet.xaml
    /// </summary>
    public partial class TimerSet : UserControl
    {
       public enum Category{
            Easy,
            Favourites,
            Moderate,
            Challenging,
            Random,
            All

        }

        public int category;
        public TimerSet()
        {
            InitializeComponent();
          
        }

        public void limitnumber(object sender, TextCompositionEventArgs e)

        {

            Regex re = new Regex("[^0-9]+");

            e.Handled = re.IsMatch(e.Text);

        }

        public void Start(object sender, RoutedEventArgs e)
        {
            int v = int.Parse(Time.Text);
            if(Time.Text != null)
            {
                if (v > 3600)
                {
                    Explain.Text = "Too much";
                }
                else
                {
                    contents.Children.Clear();
                    teset2.Exercise Ex = new Exercise();
                    Ex.s = v;
                    contents.Children.Add(Ex);
                }

            }
        }

        public void Back(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            switch (category)
            {
                case 1:
                    contents.Children.Add(new UserFavorite());
                    break;
                case 2:
                    contents.Children.Add(new UserRandom());
                    break;
                case 3:
                    contents.Children.Add(new UserAll());
                    break;
                case 4:
                    contents.Children.Add(new UserEasy());
                    break;
                case 5:
                    contents.Children.Add(new UserModerate());
                    break;
                case 6:
                    contents.Children.Add(new UserChallenge());
                    break;
            }
        }
    }
}
