using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EXAMPLE
{
    class DataAccess
    {
    


        public static List<exerciesList> fill_listbox()
        {
            List<exerciesList> exe = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Id, Type, Caption, Status, Kj, Calculation, Img, Video from tt";
            SQLiteConnection conn = new SQLiteConnection(datasource1);
            
            SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
            SQLiteDataReader rdr;
      
            try
            {
                conn.Open();     
                rdr = cmd.ExecuteReader(); 
                while (rdr.Read())
                {            
                    exe.Add(new exerciesList{ id = rdr.GetInt32(0), type = rdr.GetString(1),
                                              caption = rdr.GetString(2), status=rdr.GetInt32(3),
                                              kj = rdr.GetFloat(4), calculation = rdr.GetString(5), img = rdr.GetString(6), video = rdr.GetString(7)});
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return exe;
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
                        img = rdr.GetString(0), video=rdr.GetString(1), id=rdr.GetInt32(2), caption = rdr.GetString(3)
                    
                    });
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return exe;
        }

        public static List<exerciesList> Load(int id)
        {
            List<exerciesList> ex = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Img, Video, Caption from tt where Id = ?";
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
                        caption = rdr.GetString(2)                        
                    });

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
            return ex;
        }

        public static List<exerciesList> FilterMode(string type)
        {
            List<exerciesList> ex = new List<exerciesList>();
            string datasource1 = "Data Source=.\\Test.db;Version=3;";
            string sql1 = "select Img, Video, Caption, Type from tt where Type = ?";
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
                        type = rdr.GetString(3)

                    });

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ex;
            
        }


    }
}
