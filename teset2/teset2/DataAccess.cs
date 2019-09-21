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

namespace teset2
{
    class DataAccess
    {
        //public static List<exerciesList> fill_listbox()
        //{
        //    List<exerciesList> exe = new List<exerciesList>();
        //    string datasource1 = "Data Source=.\\Test.db;Version=3;";
        //    string sql1 = "select Id, Type, Caption, Status, Kj, Calculation, Img, Video from tt";
        //    SQLiteConnection conn = new SQLiteConnection(datasource1);

        //    SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
        //    SQLiteDataReader rdr;

        //    try
        //    {
        //        conn.Open();
        //        rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            exe.Add(new exerciesList
        //            {
        //                id = rdr.GetInt32(0),
        //                type = rdr.GetString(1),
        //                caption = rdr.GetString(2),
        //                status = rdr.GetInt32(3),
        //                kj = rdr.GetFloat(4),
        //                calculation = rdr.GetString(5),
        //                img = rdr.GetString(6),
        //                video = rdr.GetString(7)
        //            });

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return exe;
        //}

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
            string sql1 = "select distinct Name from Submission order by DATETIME DESC";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
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
