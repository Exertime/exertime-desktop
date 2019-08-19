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
    /// Interaction logic for Original.xaml
    /// </summary>
    public partial class Original : UserControl
    {
       

        public int vis;

        public Original()
        {
            InitializeComponent();
        }
        public delegate void AppearButtonDelegate();
        public event AppearButtonDelegate appearButtonEvent;

     

        private void All_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            contents.Children.Add(new UserAll());
            appearButtonEvent();


        }
        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            contents.Children.Add(new UserFavorite());
            appearButtonEvent();
        }
        private void Random_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            contents.Children.Add(new UserRandom());
           

        }

    }
}
    