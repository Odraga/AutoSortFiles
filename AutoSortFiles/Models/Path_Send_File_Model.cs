using AutoSortFiles.Models.Entities;
using System.Configuration;
using System.Data.SQLite;
using System.Xml.Linq;

namespace AutoSortFiles.Models
{
    internal class Path_Send_File_Model
    {
        private readonly string connection = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public int InsertNewPathSendFile(string path)
        {
            try
            {
                int result = 0;

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO PATHS_SEND_FILES (PATH) VALUES(@path);";
                        cmd.Parameters.AddWithValue("@path", path);

                        result = cmd.ExecuteNonQuery();

                        return result;
                    }
                }
            }
            catch (Exception ex) { 
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}"); 
                return 0; 
            }
        }

        public List<Path_Send_File> GetPathsSendFiles()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM PATHS_SEND_FILES;";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            List<Path_Send_File> paths_send_files = new List<Path_Send_File>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    paths_send_files.Add(new Path_Send_File()
                                    {
                                        Id = reader.GetInt32(0),
                                        Path = reader.GetString(1),
                                    });
                                }
                            }

                            return paths_send_files;
                        }
                    }
                }
            }
            catch (Exception ex) { 
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}"); 
                return new List<Path_Send_File> { }; 
            }
        }

        public Path_Send_File GetIdPathSendFileByName(string? path)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT ID FROM PATHS_SEND_FILES WHERE PATH = @path;";

                        cmd.Parameters.AddWithValue("@path", path);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            Path_Send_File path_send_file = new Path_Send_File();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    path_send_file.Id = reader.GetInt32(0);
                                }
                            }

                            return path_send_file;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new Path_Send_File() { };
            }
        }

        public Path_Send_File GetNamePathSendFileById(int? id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT PATH FROM PATHS_SEND_FILES WHERE ID = @id;";

                        cmd.Parameters.AddWithValue("@id", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            Path_Send_File path_send_file = new Path_Send_File();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    path_send_file.Path = reader.GetString(0);
                                }
                            }

                            return path_send_file;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new Path_Send_File() { Path = "" };
            }
        }

        public List<Path_Send_File> GetPathsSendFilesWithoutUse()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM PATHS_SEND_FILES WHERE ID NOT IN (SELECT ID_PATHS_SEND_FILES FROM FOLDERS);";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {

                            List<Path_Send_File> paths_send_files = new List<Path_Send_File>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    paths_send_files.Add(new Path_Send_File()
                                    {
                                        Path = reader.GetString(1),
                                    });
                                }
                            }

                            return paths_send_files;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new List<Path_Send_File> { };
            }

        }
    }
}
