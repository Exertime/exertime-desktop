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
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";
        

        
        public UserAll()
        {
            InitializeComponent();
            
                //Note: This approach is not thread-safe
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);

            MySqlConnection conn = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("select * from class", conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dtGrid.DataContext = dt;
            
            


        }



    }
}

