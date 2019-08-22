using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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


namespace EXAMPLE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<exerciesList> eeee;
 
        // private ObservableCollection<exerciesList> viewableStaff;
        //  private ObservableCollection<exerciesList> VisibleStaff { get { return viewableStaff; } set { } }
        public MainWindow()
        {
            InitializeComponent();

            ///////Option 1. Call data - It will be the main code for our application(Check exerciesList.cs and DataAccess.cs)
            eeee = DataAccess.fill_listbox();
            foreach (exerciesList e in eeee)
            {
                LV.Items.Add(e);
                
            }
    
            ///////////////////displaying picture////////////////////
            Image newImage = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(@"C:\\Users\\jmkin\\source\repos\\EXAMPLE\\EXAMPLE\resources\\download.jpg", UriKind.Absolute);
            src.EndInit();
            newImage.Source = src;
            newImage.Stretch = Stretch.Uniform;
            newImage.Height = 100;
            newImage.Source = src;
            newImage.Stretch = Stretch.Uniform;
            newImage.Height = 100;
            wp_img.Children.Add(newImage);
            /////////////////////////////////////////////////////



            ////////// Option 2. Call data
            List<exerciesList> exe = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Id, Caption, Kj, Img, Video from tt";
            SQLiteConnection conn = new SQLiteConnection(datasource1);

            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            SQLiteDataReader rdr;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
           
                while (rdr.Read())
                {
                    exe.Add(new exerciesList { id = rdr.GetInt32(0), caption = rdr.GetString(1), kj = rdr.GetFloat(2) });
                   
                }
                foreach (exerciesList temp in exe)
                {
                  
                  LB2.Items.Add(temp);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    
        ///////// Optione 3. Call data
        public List<string> exerciseList = new List<string>();
        public void populatedList()
        {
          //  DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string datasource = "Data Source=.\\Test.db;Version=3;";
            string sql = "select Id, Caption, Kj, Img, Video from tt";
            // string datasource = "Data Source= (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirection|Exertime.mdf; Integrated Security = True;";
            using (SQLiteConnection conn = new SQLiteConnection(datasource))
            {
             
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);             
                da.Fill(dt);
                LB.DataContext = da;
                conn.Close();
                
            }
            //  LB.DataContext = dt;
            
            foreach (DataRow row in dt.Rows)
            {
                  exerciseList.Add(row["Caption"].ToString());
       
            }

            foreach (string str in exerciseList)
            {
 
                LV.Items.Add(str);
              
            }
            foreach (string str in exerciseList)
            {

               LB.Items.Add(str);
            }
        }
        
                     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            populatedList();
            


        }

        //Here New code
        List<exerciesList> people = new List<exerciesList>();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
