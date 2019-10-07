using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
        public UserAll temp = new UserAll();

        public int id;
        private List<recentList> IMGR;
        public Original()
        {
            InitializeComponent();
           // MediaCall();
        }
        public delegate void Delegate();
        public event Delegate all,back,exercise1,exercise2;

        public void MediaCall(int id)
        {

            IMGR = DataAccess.Recent(id);
            int IDD = 0;

            int n = 0;


            foreach (recentList e in IMGR)
            {
                int i = 0;

                List<exerciesList> ex = new List<exerciesList>();
                ImageBrush ib = new ImageBrush();
                string datasource1 = "Data Source=.\\Test.db;Version=3;";
                string sql1 = "select Img, Video, Caption, Calculation, Id from tt where Caption = '" + e.name + "'";
                SQLiteConnection conn = new SQLiteConnection(datasource1);
                SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
                SQLiteDataReader rdr;

                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ex.Add(new exerciesList
                    {
                        img = rdr.GetString(0),
                        video = rdr.GetString(1),
                        caption = rdr.GetString(2),
                        calculation = rdr.GetString(3),
                        id = rdr.GetInt32(4)
                    });

                }



                foreach (exerciesList exc in ex)
                {
                    if (n == 5)
                    {
                        break;
                    }
                    BitmapImage src = new BitmapImage();
                    src.BeginInit();
                    var filename = exc.img;
                    src.UriSource = new Uri(@"..\resources\" + filename, UriKind.Relative);
                    src.EndInit();
                   
                    ib.ImageSource = src;
                    ib.Stretch = Stretch.Fill;
                    System.Windows.Controls.Button btn = new System.Windows.Controls.Button();        // Create button
                                                                                                    
                    btn.Name = "btn_" + exc.id.ToString();  //Put name on each button
                                                            //btn.Uid = e.caption;
                    n += 1;    // as many as the number of data in database

                    btn.Background = ib;
                    btn.Click += new RoutedEventHandler(doCall);  //for button event
                    btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.Margin = new Thickness(10);
                    btn.Height = 150;
                    btn.Width = 250;
                    wp_img.Children.Add(btn);  //Put buttons into Wrap panel

                    IDD = exc.id;

                }

            }






        }


        public string sid;
           public string type;
        private void doCall(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (sender as System.Windows.Controls.Button);
            string strId = null;

            if (btn != null)
            {
                strId = btn.Name.Substring((btn.Name.IndexOf('_') + 1), btn.Name.Length - (btn.Name.IndexOf('_') + 1));
                sid = strId;


                List<exerciesList> CAP;
                temp.id = sid;
             
                CAP = DataAccess.Load(Int32.Parse(sid));
                foreach (exerciesList exList in CAP)
                {
                    var exercise = exList.calculation;
                    if (exercise == "Timed")
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
            back();
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            all();
        }

    }
}
    