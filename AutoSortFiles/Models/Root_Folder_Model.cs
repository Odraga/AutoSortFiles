using AutoSortFiles.Models.Entities;
using System.Configuration;
using System.Data.SQLite;

namespace AutoSortFiles.Models
{
    internal class Root_Folder_Model
    {
        private readonly string connection = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;

        public int InsertNewRootFolder(string path)
        {
            try
            {
                int result = 0;

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO ROOTS_FOLDERS (PATH) VALUES(@path);";

                        cmd.Parameters.AddWithValue("@path", path);

                        result = cmd.ExecuteNonQuery();

                        conn.Close();

                        return result;

                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return 0;
            }
        }

        public List<Root_Folder> GetRoots_Folders()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {

                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {

                        cmd.CommandText = "SELECT * FROM ROOTS_FOLDERS;";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            List<Root_Folder> roots_folders = new List<Root_Folder>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    roots_folders.Add(new Root_Folder()
                                    {
                                        Id = reader.GetInt32(0),
                                        Path = reader.GetString(1),
                                    });
                                }
                            }

                            conn.Close();

                            return roots_folders;
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}"); 
                return new List<Root_Folder> { }; 
            }

        }
    }
}
