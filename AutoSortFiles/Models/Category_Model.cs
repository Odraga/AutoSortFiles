using AutoSortFiles.Models.Entities;
using System.Configuration;
using System.Data.SQLite;
using System.Xml.Linq;

namespace AutoSortFiles.Models
{
    internal class Category_Model
    {
        private readonly string connection = ConfigurationManager.ConnectionStrings["Connection_DB"].ConnectionString;
        public int InsertNewCategory(string category)
        {
            try
            {
                int result = 0;

                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "INSERT INTO CATEGORIES (CATEGORY) VALUES(@category);";
                        cmd.Parameters.AddWithValue("@category", category);

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

        public List<Category> GetCategories()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM CATEGORIES;";
                        
                        using(SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            List<Category> categories = new List<Category>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    categories.Add(new Category()
                                    {
                                        Id = reader.GetInt32(0),
                                        Name = reader.GetString(1),
                                    });
                                }
                            }

                            return categories;
                        }
                    }
                }
                
            }
            catch (Exception ex) { 
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}"); 
                return new List<Category> { }; 
            }

        }

        public Category GetIdCategoriesByName(string? name)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using(SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT ID FROM CATEGORIES WHERE CATEGORY = @category;";

                        cmd.Parameters.AddWithValue("@category", name);

                        using(SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            Category category = new Category();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    category.Id = reader.GetInt32(0);
                                }
                            }

                            return category;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new Category() { };
            }
        }

        public Category GetNameCategoriesById(int? id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT CATEGORY FROM CATEGORIES WHERE ID = @id;";

                        cmd.Parameters.AddWithValue("@id", id);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            Category category = new Category();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    category.Name = reader.GetString(0);
                                }
                            }

                            return category;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new Category() { Name=""};
            }
        }

        public List<Category> GetCategoriesForFolders()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connection))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = "SELECT * FROM CATEGORIES WHERE ID NOT IN (SELECT ID_CATEGORIES FROM FOLDERS) AND ID IN (SELECT ID_CATEGORIES FROM ARCHIVES);";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            List<Category> categories = new List<Category>();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    categories.Add(new Category()
                                    {
                                        Name = reader.GetString(1),
                                    });
                                }
                            }

                            return categories;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. . . >:D\n\nERROR: {" + ex.Message + "}");
                return new List<Category>() { };
            }
        }
    }
}
