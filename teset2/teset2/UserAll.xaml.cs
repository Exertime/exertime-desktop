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
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data;

namespace teset2
{

    /// <summary>
    /// Interaction logic for UserAll.xaml
    /// </summary>
    public partial class UserAll : UserControl
    {



        public delegate void Delegate();
        public event Delegate exercise1,exercise2;

        private List<exerciesList> IMG;
      

        public UserAll()
        {
            InitializeComponent();

            IMG = DataAccess.picture();

            MediaCall();
        }
        public void MediaCall()
        {


            int n = 0;
            foreach (exerciesList e in IMG)
            {

                ImageBrush ib = new ImageBrush();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                var filename = e;
                src.UriSource = new Uri(@"..\resources\" + filename, UriKind.Relative);
                src.EndInit();

                ib.ImageSource = src;
                ib.Stretch = Stretch.Fill;
                Button btn = new Button();        // Create button
                btn.Name = "btn_" + e.id.ToString();  //Put name on each button

                n += 1;    // as many as the number of data in database


                btn.Click += new RoutedEventHandler(doCall);  //for button event
                btn.Background = ib;
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Margin = new Thickness(10);
                btn.Height = 150;
                btn.Width = 250;
                wp_img.Children.Add(btn);  //Put buttons into Wrap panel

            }
        }





  
        public string id;
        public string type;
        private void doCall(object sender, RoutedEventArgs e)
        {

            Button btn = (sender as Button);
            string strId = null;

            if (btn != null)
            {
                strId = btn.Name.Substring((btn.Name.IndexOf('_') + 1), btn.Name.Length - (btn.Name.IndexOf('_') + 1));
                id = strId;
                List<exerciesList> CAP;
            
                    CAP = DataAccess.Load(Int32.Parse(id));
                    foreach (exerciesList exList in CAP)
                    {
                        var exercise = exList.calculation;
                    if(exercise == "Timed")
                    {
                      
                        exercise1();

                    }
                    else
                    {
                        
                        exercise2();
                    }
                    type = exercise;
                }

            }

        }
        public void easy()
        {
            IMG = DataAccess.FilterMode("Easy");
            MediaCall();

        }

        public void moderate()
        {
            IMG = DataAccess.FilterMode("Moderate");
            MediaCall();

        }

        public void challenge()
        {
            IMG = DataAccess.FilterMode("Challenge");
            MediaCall();

        }

        public void all()
        {
            IMG = DataAccess.picture();
            MediaCall();

        }

    }
}

