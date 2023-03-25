using System.Data.SQLite;
using AutoSortFiles.Models.Entities;
using System.Configuration;

namespace AutoSortFiles.Models
{
    internal class Archive_Model
    {
        private readonly string connection = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;

        public int InsertNewArchive(int? idCategory, int? idFormat)
        {
            try
            {
                int result = 0;

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO ARCHIVES (ID_CATEGORIES, ID_FORMATS) VALUES(@idCategory, @idFormat);";
                        cmd.Parameters.AddWithValue("@idCategory", idCategory);
                        cmd.Parameters.AddWithValue("@idFormat", idFormat);

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

        public List<Archive> GetArchives()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT ARCH.*, FORMT.FORMAT, CTGR.CATEGORY FROM ARCHIVES ARCH, FORMATS FORMT, CATEGORIES CTGR WHERE ARCH.ID_FORMATS = FORMT.ID AND ARCH.ID_CATEGORIES = CTGR.ID;";
                    
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            List<Archive> archives = new List<Archive>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    archives.Add(new Archive()
                                    {
                                        Format = reader.GetString(3),
                                        Category = reader.GetString(4),
                                    });
                                }
                            }

                            conn.Close();

                            return archives;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new List<Archive> { };
            }
        }

        public bool GetExistingArchive(int? idFormats)
        {
            try
            {
                using(SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using(SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM ARCHIVES WHERE ID_FORMATS = @idFormats;";

                        cmd.Parameters.AddWithValue("@idFormats", idFormats);

                        using(SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            bool exist = reader.HasRows;

                            conn.Close();

                            return exist;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return false;
            }
        }
    }
}
