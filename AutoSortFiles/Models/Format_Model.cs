using AutoSortFiles.Models.Entities;
using System.Configuration;
using System.Data.SQLite;

namespace AutoSortFiles.Models
{
	internal class Format_Model
    {
		private readonly string connection = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;

        public int InsertNewFormat(string format)
        {
            try
			{
                int result = 0;

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO FORMATS (FORMAT) VALUES(@format);";

                        cmd.Parameters.AddWithValue("@format", format);

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

		public List<Format> GetFormats()
		{
			try
			{
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT FMTS.* FROM FORMATS FMTS;";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            List<Format> formats = new List<Format>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    formats.Add(new Format()
                                    {
                                        Name = reader.GetString(1),
                                    });
                                }
                            }

                            return formats;
                        }
                    }
                }
			}
			catch (Exception ex)
			{
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new List<Format> { };
            }

		}

        public List<Format> GetFormatsWitoutUse()
        {

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM FORMATS WHERE ID NOT IN (SELECT ID_FORMATS FROM ARCHIVES);";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            List<Format> formats = new List<Format>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    formats.Add(new Format()
                                    {
                                        Name = reader.GetString(1),
                                    });
                                }
                            }

                            return formats;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new List<Format> { };
            }
            
        }

		public Format GetIdFormatByName(string? name)
		{
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {

                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT ID FROM FORMATS WHERE FORMAT = @format;";

                        cmd.Parameters.AddWithValue("@format", name);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            Format format = new Format();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    format.Id = reader.GetInt32(0);
                                }
                            }

                            return format;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new Format() {Id=0 };
            }
        }
    }
}
