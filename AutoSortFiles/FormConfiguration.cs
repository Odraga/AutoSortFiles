using AutoSortFiles.Models;
using AutoSortFiles.Models.Entities;

namespace AutoSortFiles
{
    public partial class FormConfiguration : Form
    {
        //Objects Models
        private Format_Model formats_model = new Format_Model();
        private Category_Model categories_model = new Category_Model();
        private Path_Send_File_Model path_send_file_model = new Path_Send_File_Model();
        private Root_Folder_Model root_folder_model = new Root_Folder_Model();
        private Archive_Model archive_model = new Archive_Model();
        private Folder_Model folder_model = new Folder_Model();


        //List of Entities
        private static List<Format> formats = new List<Format>();
        private static List<Format> formatsWithoutUse = new List<Format>();

        private static List<Category> categories = new List<Category>();
        private static List<Category> categoriesForFolders = new List<Category>();

        private static List<Path_Send_File> pathsSendFiles = new List<Path_Send_File>();
        private static List<Path_Send_File> pathsSendFilesWithoutUse = new List<Path_Send_File>();

        private static List<Root_Folder> roots_folders = new List<Root_Folder>();

        private static List<Archive> archives = new List<Archive>();

        private static List<Folder> folders = new List<Folder>();

        //Variables
        private string pathSendFileFound = string.Empty;
        private string pathRootFolder = string.Empty;


        public FormConfiguration()
        {
            InitializeComponent();

            LoadData();
        }


        /// <summary>
        ///     Load all Datas from DB to ListView
        /// </summary>
        private void LoadData()
        {
            ClearAll();

            //request for all the data
            formats = formats_model.GetFormats();
            formatsWithoutUse = formats_model.GetFormatsWitoutUse();

            categories = categories_model.GetCategories();
            categoriesForFolders = categories_model.GetCategoriesForFolders();

            pathsSendFiles = path_send_file_model.GetPathsSendFiles();
            pathsSendFilesWithoutUse = path_send_file_model.GetPathsSendFilesWithoutUse();

            roots_folders = root_folder_model.GetRoots_Folders();

            archives = archive_model.GetArchives();

            folders = folder_model.GetFolders();

            //update listview of Formats
            foreach (Format format in formats)
            {
                listViewFormats.Items.Add(format.Name);
            }

            //update comboBoxFormats
            foreach(Format format in formatsWithoutUse)
            {
                cBListFormats.Items.Add(format.Name);
            }

            //update listview of Categories
            foreach (Category category in categories)
            {
                listViewCategories.Items.Add(category.Name);
                cBListCategories.Items.Add(category.Name);
            }

            //update comboBox by categories
            foreach(Category category in categoriesForFolders)
            {
                cBListCategoriesByFolder.Items.Add(category.Name);
            }

            //update listview of Paths Send Files
            foreach(Path_Send_File path_send_file in pathsSendFiles)
            {
                listViewPathsSendFiles.Items.Add(path_send_file.Path);
            }

            //update comboBox pathsSendFilesWithoutUse
            foreach(Path_Send_File path_Send_File in pathsSendFilesWithoutUse)
            {
                cBPathsSendFiles.Items.Add(path_Send_File.Path);
            }

            //update listview of Roots Folders
            foreach (Root_Folder root_folder in roots_folders)
            {
                listViewRootsFolders.Items.Add(root_folder.Path);
            }

            //update listview of Archives
            foreach(Archive archive in archives)
            {
                ListViewItem items = new ListViewItem(archive.Category);

                items.SubItems.Add(archive.Format);

                listViewArchives.Items.Add(items);
            }

            //update listview of folders
            foreach(Folder folder in folders)
            {
                Category category = categories_model.GetNameCategoriesById(folder.IdCategories);
                Path_Send_File path_Send_File = path_send_file_model.GetNamePathSendFileById(folder.IdPathSendFiles);

                ListViewItem items = new ListViewItem(category.Name);
                items.SubItems.Add(path_Send_File.Path);

                listViewFolderFiles.Items.Add(items);
            }

        }

        private void ClearAll()
        {
            //Clear all ListView
            listViewCategories.Items.Clear();
            listViewArchives.Items.Clear();
            listViewFormats.Items.Clear();
            listViewPathsSendFiles.Items.Clear();
            listViewRootsFolders.Items.Clear();
            listViewFolderFiles.Items.Clear();

            //Clear all comboBox
            cBListFormats.Items.Clear();
            cBListCategories.Items.Clear();
            cBListCategoriesByFolder.Items.Clear();
            cBPathsSendFiles.Items.Clear();

            //Clear all textBox
            txtNewFormat.Text = string.Empty;
            txtNewCategory.Text = string.Empty;
            txtNewPathSendFile.Text = string.Empty;
            txtNewRootFolder.Text = string.Empty;
            

            //Clear all Variables
            pathSendFileFound = string.Empty;
            pathRootFolder = string.Empty;

        }

        private void btnNewFormat_Click(object sender, EventArgs e)
        {
            string format = txtNewFormat.Text;

            if (!string.IsNullOrWhiteSpace(format) ) { 
                int result = formats_model.InsertNewFormat(format);

                if (result != 0)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("No debe haber espacios en blanco en el campo de texto.");
            }

        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            string category = txtNewCategory.Text;

            if (!string.IsNullOrWhiteSpace(category))
            {
                int result = categories_model.InsertNewCategory(category);

                if (result != 0)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("No debe haber espacios en blanco en el campo de texto.");
            }
        }

        private void btnSearhPathSendFiles_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pathSendFileFound = folderBrowserDialog.SelectedPath;
                txtNewPathSendFile.Text = pathSendFileFound;
            }
            else
            {
                MessageBox.Show("No selecciono ninguna ruta.");
            }
        }

        private void btnNewPathSendFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathSendFileFound))
            {
                int result = path_send_file_model.InsertNewPathSendFile(pathSendFileFound);

                if (result != 0)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("No debe haber espacios en blanco en el campo de texto.");
            }
        }

        private void btnSearchRootFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pathRootFolder = folderBrowserDialog.SelectedPath;
                txtNewRootFolder.Text = pathRootFolder;
            }
            else
            {
                MessageBox.Show("No selecciono ninguna ruta.");
            }
        }

        private void btnNewRootFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathRootFolder))
            {
                int result = root_folder_model.InsertNewRootFolder(pathRootFolder);

                if (result != 0)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("No debe haber espacios en blanco en el campo de texto.");
            }
        }

        private void btnNewArchive_Click(object sender, EventArgs e)
        {
            try
            {
                string? formatSelect = cBListFormats.Items[cBListFormats.SelectedIndex].ToString();
                string? categorySelect = cBListCategories.Items[cBListCategories.SelectedIndex].ToString();

                if (!string.IsNullOrWhiteSpace(formatSelect) || !string.IsNullOrWhiteSpace(categorySelect))
                {

                    Format format = formats_model.GetIdFormatByName(formatSelect);
                    Category category = categories_model.GetIdCategoriesByName(categorySelect);
                    
                    if(format.Id > 0 && category.Id > 0)
                    {
                        bool exist = archive_model.GetExistingArchive(format.Id);

                        if (!exist)
                        {
                            int result = archive_model.InsertNewArchive(category.Id, format.Id);

                            if (result != 0)
                            {
                                LoadData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se le puede atribuir la categoria "+ categorySelect + " al Formato "+ formatSelect +"\nYa que este formato ha asignado anteriormente a una categoria. :O");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Occurio un error al intentar encontrar la categoria/formato.");
                    }
                }
                else
                {
                    MessageBox.Show("No debe haber espacios en blanco en el campo de texto.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe seleccionar una Categoria y un Formato");
            }
            
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string? pathSendFileSelect = cBPathsSendFiles.Items[cBPathsSendFiles.SelectedIndex].ToString();
                string? categorySelect = cBListCategoriesByFolder.Items[cBListCategoriesByFolder.SelectedIndex].ToString();

                if (!string.IsNullOrWhiteSpace(pathSendFileSelect) || !string.IsNullOrWhiteSpace(categorySelect))
                {

                    Path_Send_File pathSendFile = path_send_file_model.GetIdPathSendFileByName(pathSendFileSelect);
                    Category category = categories_model.GetIdCategoriesByName(categorySelect);

                    if (pathSendFile.Id > 0 && category.Id > 0)
                    {

                        int result = folder_model.InsertNewFolder(category.Id, pathSendFile.Id);

                        if (result != 0)
                        {
                            cBPathsSendFiles.SelectedIndex = -1;
                            LoadData();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Occurio un error al intentar encontrar la categoria/formato.");
                    }
                }
                else
                {
                    MessageBox.Show("No debe haber espacios en blanco en el campo de texto.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe seleccionar una Categoria y la ruta a donde seran enviado los archivos");
            }
        }

        private void txtNewCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewFolderPathsSendFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void listViewFormats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewRootsFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string objeto = listViewRootsFolders.SelectedItems[0].Text;

            txtNewRootFolder.Text = objeto;
        }

        
    }
}
