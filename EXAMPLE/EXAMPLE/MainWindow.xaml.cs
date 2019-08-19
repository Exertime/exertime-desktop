using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<string> exerciseList = new List<string>();
        public void populatedList()
        {          
            DataTable dt = new DataTable();
            string datasource = "Data Source=.\\Test.db;Version=3;";
            // string datasource = "Data Source= (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirection|Exertime.mdf; Integrated Security = True;";
            using (SQLiteConnection conn = new SQLiteConnection(datasource))
            {
                string sql = $"select * from tt";
  
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
    
            foreach (DataRow data in dt.Rows)
            {
          
                exerciseList.Add(data[1].ToString());
          //      exerciseList.Add(data[2].ToString());
          //      exerciseList.Add(data[3].ToString());
            }

            foreach(string str in exerciseList)
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
    }
}
