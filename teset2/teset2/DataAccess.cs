using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace teset2
{
    class DataAccess
    {
        private const string db = "Exertime";

        private const string user = "root";

        private const string pass = "kit301!CMS";

        private const string server = "kit301-exertime.cis.utas.edu.au";

       // private const string con = "Server=" + server + ";Database=" + db + ";User Id=" + user + ";Password=" + pass + "";
       private const string con = "Server=kit301-exertime.cis.utas.edu.au;Database=Exertime;User Id='root';Password='kit301!CMS'";

       // private const string con = "Server=alacritas.cis.utas.edu.au;Database=kit206;User Id=kit206;Password=kit206";


        public static void login(string username,string password)
        {

         // string con = String.Format("Database={0};Data Source={1};User Id={2};Password={3};", db, server, user, pass);

            MySqlConnection conn = new MySqlConnection(con);


            try
            {
                //string sql1 = "SELECT * FROM USERS WHERE id = 2 ";
                //MessageBox.Show(sql1);


                conn.Open();
                MessageBox.Show("connect success！");
                //        MySqlCommand sqlman = new MySqlCommand(sql1, conn);
                //    if (sqlman.ExecuteNonQuery() != 0)
                //    {
                //        MessageBox.Show("插入数据成功！");
                //    }
                //}
            }
            catch (MySqlException)
            {
                MessageBox.Show("connect fail！");
            }

            finally
            {
                conn.Close();
            }

           // conn.Close();

        }

        public static List<exerciesList> picture()
        {
            List<exerciesList> exe = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Img, Video, Id, Caption from tt";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            SQLiteDataReader rdr;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    exe.Add(new exerciesList
                    {
                        img = rdr.GetString(0),
                        video = rdr.GetString(1),
                        id = rdr.GetInt32(2),
                        caption = rdr.GetString(3)

                    });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return exe;
        }

        public static List<exerciesList> FilterMode(string type)
        {
            List<exerciesList> ex = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Img, Video, Caption, Type, Id from tt where Type = ?";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Parameters.AddWithValue("Type", type);
            SQLiteDataReader rdr;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ex.Add(new exerciesList
                    {
                        img = rdr.GetString(0),
                        video = rdr.GetString(1),
                        caption = rdr.GetString(2),
                        type = rdr.GetString(3),
                        id = rdr.GetInt32(4)
                    });

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ex;

        }

        public static List<exerciesList> Load(int id)
        {
            List<exerciesList> ex = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Img, Video, Caption, Calculation from tt where Id = ?";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Parameters.AddWithValue("Id", id);
            SQLiteDataReader rdr;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ex.Add(new exerciesList
                    {
                        img = rdr.GetString(0),
                        video = rdr.GetString(1),
                        caption = rdr.GetString(2),
                        calculation = rdr.GetString(3)
                    });

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ex;
        }

        public static List<recentList> Recent()
        {
            List<recentList> rct = new List<recentList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            //string sql1 = "select distinct Name from(select * from Submission order by DATETIME DESC) a";
            string sql2 = "select distinct Name from Submission order by DATETIME DESC";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql2, conn);
            SQLiteDataReader rdr;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    rct.Add(new recentList
                    {
                        
                 
                        name = rdr.GetString(0)

                    });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rct;

        }


        public static List<userPreferenceList> setting()
        {
            List<userPreferenceList> upl = new List<userPreferenceList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Username, GivenName, Surname, PreferredName, Email, DOB, Gender, JobTitle, CalorieGoal from Setting where ID = 1";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
     
            SQLiteDataReader rdr;
          

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    upl.Add(new userPreferenceList
                    {
                        username = rdr.GetString(0),
                        givenname = rdr.GetString(1),
                        surname = rdr.GetString(2),
                        preferredname = rdr.GetString(3),
                        email = rdr.GetString(4),
                        DOB = rdr.GetString(5),
                        gender = rdr.GetString(6),
                        jobtitle = rdr.GetString(7),
                        caloriegoal = rdr.GetInt32(8)


                        

                    });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return upl;
        }



        public static void Submit(string name,int time,string rep, string type)
        {
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "INSERT INTO Submission (Name,Time,Repetitions,Type,DateTime)VALUES('"+name+"','"+time+"','"+rep+"','"+type+"',CURRENT_TIMESTAMP)";
            SQLiteConnection conn = new SQLiteConnection(datasource1);

            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }

        public static void upDate(string username, string givenname, string surname, string preferredname,string email, string dob, string gender, string jobtitle, int caloriegoal)
        {
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "UPDATE Setting SET Username = '"+username+"', GivenName = '"+givenname+"', Surname = '"+surname+"', PreferredName = '"+preferredname+"', Email = '"+email+"', DOB = '"+dob+"', Gender = '"+gender+"', JobTitle = '"+jobtitle+"', CalorieGoal = '"+caloriegoal+"' where ID = 1";
            SQLiteConnection conn = new SQLiteConnection(datasource1);

            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
