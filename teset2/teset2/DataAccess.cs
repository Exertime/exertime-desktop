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
using MySqlConnector;

namespace teset2
{
    class DataAccess
    {
        private const string db = "Exertime";

        private const string user = "root";

        private const string pass = "kit301!CMS";

        private const string server = "kit301-exertime.cis.utas.edu.au";

        private const string port = "3306";

        // private const string con = "Server=" + server + ";Database=" + db + ";User Id=" + user + ";Password=" + pass + "";
        // private const string con = "Data Source=kit301-exertime.cis.utas.edu.au;Database=Exertime;User Id=root;Password=kit301!CMS";

        //private const string con = "Server=alacritas.cis.utas.edu.au;Database=kit206;User Id=kit206;Password=kit206";


        public static int login(string username, string password)
        {

            int id = 0;
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select ID from USERS where Username = '" + username + "' and password = '" + password + "';";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            SQLiteDataReader rdr;
            int count = 0;

            try
            {
                conn.Open();

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    id = rdr.GetInt32(0);
                    count++;
                    return id;
                }

                if (count == 1)
                { }
                else
                {
                    MessageBox.Show("Wrong User Name or Password, please try again!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return id;


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

        public static List<recentList> Recent(int id)
        {
            List<recentList> rct = new List<recentList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            //string sql1 = "select distinct Name from(select * from Submission order by DATETIME DESC) a";
            string sql2 = "select distinct Name from Submission where Id = " + id + " order by DATETIME DESC";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql2, conn);
            SQLiteDataReader rdr;
            //MessageBox.Show(sql2);
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


        public static List<userPreferenceList> setting(int id)
        {
            List<userPreferenceList> upl = new List<userPreferenceList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Username, GivenName, Surname, PreferredName, Email, DOB, Gender, height, CalorieGoal,weight from USERS where ID = " + id + "";
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
                        height = rdr.GetString(7),
                        caloriegoal = rdr.GetInt32(8),
                        weight = rdr.GetString(9)

                    });

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return upl;
        }



        public static void Submit(int id, string name, int time, string rep, string type)
        {
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "INSERT INTO Submission (Id,Name,Time,Repetitions,Type,DateTime)VALUES(" + id + ",'" + name + "','" + time + "','" + rep + "','" + type + "',CURRENT_TIMESTAMP)";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }

        public static void upDate(int id, string username, string givenname, string surname, string preferredname, string email, string dob, string gender, string height, string weight, int caloriegoal)
        {
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "UPDATE USERS SET Username = '" + username + "', GivenName = '" + givenname + "', Surname = '" + surname + "', PreferredName = '" + preferredname + "', Email = '" + email + "', DOB = '" + dob + "', Gender = '" + gender + "', height='" + height + "',weight='" + weight + "', CalorieGoal = '" + caloriegoal + "' where ID = " + id + "";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }

        public static void reset()
        {
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "UPDATE time SET time = 0 where id = 0";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }

        public static int record(int time)
        {
            int t = 0;

            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql = "select time from time where id = 0";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Connection.Open();
            SQLiteDataReader rdr;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                t = rdr.GetInt32(0);

            }

            t += time;
       

            if (t >= 45)
            {
                string sql1 = "UPDATE time SET time = 0 where id = 0";
                
                SQLiteCommand cmd1 = new SQLiteCommand(sql1, conn);

                cmd1.ExecuteNonQuery();
            }
            else
            {
                string sql1 = "UPDATE time SET time = " + t + " where id = 0";

                
                SQLiteCommand cmd1 = new SQLiteCommand(sql1, conn);

                cmd1.ExecuteNonQuery();
            }
            return t;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            // return t;

        }



        public static int hint()
        {
            int t = 0;

            string datasource1 = "Data Source=.\\Test.db;Version=3;";

            string sql = "select time from time where id = 0";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Connection.Open();
            SQLiteDataReader rdr;
            rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                t = rdr.GetInt32(0);
             
            }


            t = 45 - t;
            return t;

        }

        public static string mainhint()
        {
            string t = null;

            string datasource1 = "Data Source=.\\Test.db;Version=3;";

            string sql = "SELECT hint FROM Hint WHERE id IN (SELECT id FROM Hint ORDER BY RANDOM() LIMIT 1)";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Connection.Open();
            SQLiteDataReader rdr;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                t = rdr.GetString(0);

            }

            return t;


        }
    }
}

