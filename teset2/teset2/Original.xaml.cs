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
       

        public int type;

        public Original()
        {
            InitializeComponent();
        }
        public delegate void Delegate();
        public event Delegate all;



        private void All_Click(object sender, RoutedEventArgs e)
        {
            //contents.Children.Clear();
            //teset2.UserAll all = new UserAll();
            //contents.Children.Add(all);
            //AppearButton1();
            all();


        }
     

        //private void AppearButton1()
        //{
        //    back();
        //}

        //private void AppearButton()
        //{
        //    exitEvent();
        //}

    }
}
    