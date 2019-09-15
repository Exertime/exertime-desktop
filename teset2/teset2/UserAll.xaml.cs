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
        //private const string db = "kit206";
        //private const string user = "kit206";
        //private const string pass = "kit206";
        //private const string server = "alacritas.cis.utas.edu.au";
        public int value = 0;

        public delegate void Delegate();
        public event Delegate exercise;

        private List<exerciesList> IMG;

        public UserAll()
        {
        //    InitializeComponent();

        //        //Note: This approach is not thread-safe
        //    string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);

        //    MySqlConnection conn = new MySqlConnection(connectionString);

        //    MySqlCommand cmd = new MySqlCommand("select * from class", conn);
        //    conn.Open();
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    conn.Close();
        //    dtGrid.DataContext = dt;




        //}
        //public delegate void ExitDelegate();
        //public event ExitDelegate exitEvent;

        //private void AppearButton()
        //{
        //    exitEvent();
        //}

        InitializeComponent();

        IMG = DataAccess.picture();
            int n = 0;
            foreach (exerciesList e in IMG)
            {
              

                Image newImage = new Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                var filename = e;
                src.UriSource = new Uri(@"..\resources\" + filename, UriKind.Relative);
                src.EndInit();
                newImage.Source = src;
                newImage.Height = 200;
                newImage.Width = 200;
                newImage.Stretch = Stretch.Uniform;

                newImage.HorizontalAlignment = HorizontalAlignment.Left;
                newImage.VerticalAlignment = VerticalAlignment.Top;

                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Children.Add(newImage);  //put newImage into stack panel
                Button btn = new Button();        // Create button
                                                  /*여기부분은 int n을 이용해서 이름을 바꾸는곳인데, db에서 id를 뽈아 온다음에 밑에 있는 버튼 이벤트에서 db구문 select from tt where id 를 이용해서 동영상을 뽑아온다
                                                   * 그리고 그다음엔 Videopage()를 불러와서 다음 interface로 넘어간후 그 동영상이 재생이 된다.*/
                btn.Name = "click_" + n.ToString();  //Put name on each button
                btn.Uid = e.caption;
                n += 1;    // as many as the number of data in database

               


                btn.Content = stackPnl;   //Put image into button

                btn.Click += new RoutedEventHandler(doCall);  //for button event

                btn.Background = new SolidColorBrush(Color.FromArgb(255, 0, 80, 80));
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Margin = new Thickness(10);
                btn.Height = 150;
                wp_img.Children.Add(btn);  //Put buttons into Wrap panel

            }

            

        }

        public string exerciseName;

        private void doCall(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            
             if (btn != null)
             {
                this.exerciseName = btn.Name;
                exercise();
                //contents.Children.Clear();
                //Exercise ex = new Exercise();
                //ex.value = value;
                //contents.Children.Add(ex);
             }
            
        }

    }
}

