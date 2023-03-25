using AutoSortFiles.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFiles.Models
{
    internal class Folder_Model
    {
        private readonly string connection = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public int InsertNewFolder(int? idCategories, int? idPathsSendFiles)
        {
            try
            {
                int result = 0;

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO FOLDERS (ID_CATEGORIES, ID_PATHS_SEND_FILES) VALUES(@idCategories, @idPathsSendFiles);";
                        cmd.Parameters.AddWithValue("@idCategories", idCategories);
                        cmd.Parameters.AddWithValue("@idPathsSendFiles", idPathsSendFiles);

                        result = cmd.ExecuteNonQuery();

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return 0;
            }
        }

        public List<Folder> GetFolders()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM FOLDERS;";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            List<Folder> folders = new List<Folder>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    folders.Add(new Folder()
                                    {
                                        Id = reader.GetInt32(0),
                                        IdCategories = reader.GetInt32(1),
                                        IdPathSendFiles = reader.GetInt32(2),
                                    });
                                }
                            }

                            return folders;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new List<Folder> { };
            }
        }
    }
}
