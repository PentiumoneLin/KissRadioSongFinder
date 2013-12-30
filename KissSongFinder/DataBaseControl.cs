using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.OleDb;
using System.IO;

namespace KissSongFinder
{
    class DataBaseControl
    {

        string BaseDirector = string.Empty;
        string connStr = @"Data Source=\MainDataBase.sdf;Persist Security Info=False";
        const string TableName = "MusicPlayingHistory";

        public MainDatabaseDataSet dsMain = new MainDatabaseDataSet();

        public DataBaseControl()
        {
            BaseDirector = System.Windows.Forms.Application.StartupPath;
            connStr = Path.Combine(BaseDirector, "MainDataBase.sdf");
            connStr = "Data Source=" + connStr + "";
        }

        private SqlCeConnection GetSqlConn()
        {            
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
            //using (SqlCeConnection conn = new SqlCeConnection(connStr))
            //{
            //    using (SqlCeCommand cmd = new SqlCeCommand(StrCmd, conn))
            //    {

            //        SqlCeDataAdapter odda = new SqlCeDataAdapter();
            //        odda.SelectCommand = cmd;

            //        odda.Fill(dsMain.dtMusicList);
            //    }
            //}            
        }

        public void GetAllList()
        {
            string StrCmd = "SELECT * FROM " + TableName;

            using (SqlCeConnection conn = GetSqlConn())
            {
                using (SqlCeCommand cmd = new SqlCeCommand(StrCmd, conn))
                {

                    SqlCeDataAdapter odda = new SqlCeDataAdapter();
                    odda.SelectCommand = cmd;

                    odda.Fill(dsMain.dtMusicList);
                }
            }
        }

        public bool InsertPlayingInfo(PlayingInfo info)
        {
            try
            {
                string StrCmd = string.Format("INSERT INTO {0}(PlayingTime, Artist, MusicName) VALUES('{1}', '{2}', '{3}')", TableName, info.PlayingTime.ToString("yyyy-MM-dd HH:mm:ss"), info.Artist, info.SongName);
                
                using (SqlCeConnection conn = GetSqlConn())
                {
                    conn.Open();
                    using (SqlCeCommand cmd = new SqlCeCommand(StrCmd, conn))
                    {
                        //cmd.CommandType = System.Data.CommandType.Text;
                        
                        int result = cmd.ExecuteNonQuery();



                        //SqlCeDataAdapter odda = new SqlCeDataAdapter();
                        //odda.InsertCommand = cmd;
                        //int iresult = odda.Update(dsMain.dtMusicList);
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
