using AutoSortFiles.Models;
using AutoSortFiles.Models.Entities;
using System.Diagnostics;

namespace AutoSortFiles
{
    public partial class FormMain : Form
    {
        //const string quote = @"""";


        //Here is the list of names and formats of our files
        private List<Models.Entities.Archive> namesfiles = new List<Models.Entities.Archive>();


        //Lists of Entities
        private static List<Root_Folder> rootFolders= new List<Root_Folder>();

        //Models
        private static Root_Folder_Model root_Folder_Model = new Root_Folder_Model();

        public FormMain()
        {
            InitializeComponent();

            AutoScanRootFolders();
        }

        private void AutoScanRootFolders()
        {
            rootFolders = root_Folder_Model.GetRoots_Folders();

            if (rootFolders.Count > 0)
            {
                listViewFiles.Items.Clear();

                List<string> files = new List<string>();

                foreach (var rootFolder in rootFolders)
                {

                    files = files.Concat(Directory.GetFiles(rootFolder.Path, "*", SearchOption.TopDirectoryOnly)).ToList();
                }



                int index = 1;

                foreach (var file in files)
                {
                    ListViewItem listViewItem = new ListViewItem(index.ToString());
                    listViewItem.SubItems.Add(file);

                    listViewFiles.Items.Add(listViewItem);

                    index++;
                }

                lblTotalArchives.Text = "Total Files: " + files.Count.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, dirijase a la opcion configuration y agregue nuevas RootsFolders para scanear.");
            }
        }

        private void btnScanFile_Click(object sender, EventArgs e)
        {
            AutoScanRootFolders();
        }

        private void OrderListFilesByNames(string output)
        {
            /*const int limit = 41;

            string[] separador = { "\n", "\r" };

            List<string> outputread = new List<string>();

            outputread.Clear();
            namesfiles.Clear();
            
            txtTreeFiles.Text = string.Empty;

            outputread = output.Split(separador, StringSplitOptions.None).ToList();

            int index = 0;

            foreach (string line in outputread)
            {

                if (formatPictures.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text += "[" + index + "]----------> " + name + "\r\n";

                    //namesfiles.Add(new Models.Entities.File("Pictures", name));
                }
                else if (formatDocuments.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text += "[" + index + "]----------> " + name + "\r\n";
                    //namesfiles.Add(new Models.Entities.File("Documents", name));
                }
                else if (formatVideos.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text += "[" + index + "]----------> " + name + "\r\n";
                    //namesfiles.Add(new Models.Entities.File("Videos", name));
                }
                else if (formatApps.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text += "[" + index + "]----------> " + name + "\r\n";
                    //namesfiles.Add(new Models.Entities.File("Apps", name));
                }
            }

            txtTreeFiles.Text += namesfiles.Count < 0 ? "¡No hay archivos para Mover!" : "\n\n¡Escaneo Finalizado";
            */
        }

        private void btnAutoOrderFiles_Click(object sender, EventArgs e)
        {
            

            int index = 0;

            using (Process process = new Process())
            { 
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                    
                foreach (Models.Entities.Archive file in namesfiles)
                {
                    index++;
                    process.StartInfo.Arguments = string.Empty; //@"/c move " + @"""C:\Users\gabri\Downloads\" + file.Name + @""" " + GetPath(file.Format);
                    process.Start();

                    StreamReader reader = process.StandardOutput;
                    string output = reader.ReadToEnd();

                    
                }
            }

            namesfiles.Clear();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            FormConfiguration formConfiguration = new FormConfiguration();

            formConfiguration.ShowDialog();
        }

        /*private string GetPath(string format)
        {
            
            if (format == "Documents") 
            {
                return quote + pathDocuments + quote;
            }
            else if (format == "Videos")
            {
                return quote + pathVideos + quote;
            }
            else if (format == "Pictures")
            {
                return quote + pathPictures + quote;
            }
            else if (format == "Apps")
            {
                return quote + pathApp + quote;
            }
            else
            {
                return "";
            }

        }*/


    }
}