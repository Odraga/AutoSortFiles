using AutoSortFiles.Models.Entities;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace AutoSortFiles
{
    public partial class FormMain : Form
    {
        const string quote = @"""";


        //Here is the list of names and formats of our files
        private List<Files> namesfiles = new List<Files>();

        //All Path
        private string pathDocuments = @"C:\Users\gabri\OneDrive\Documents";
        private string pathVideos = @"C:\Users\gabri\OneDrive\Vídeos";
        private string pathPictures = @"C:\Users\gabri\OneDrive\Pictures";
        private string pathApp = @"D:\Aplicaciones";

        //Formato Documentos
        private List<string> formatDocuments = new List<string>() {
                ".docx",
                ".doc",
                ".pdf",
                ".pptx",
        };

        //Formato imagenes
        private List<string> formatPictures = new List<string>(){
                ".jpg",
                ".jpeg",
                ".JPG",
                ".png",
                ".tiff",
        };

        //Formato videos
        private List<string> formatVideos = new List<string>(){
                ".mp4",
        };

        //Formato aplicaciones
        private List<string> formatApps = new List<string>(){
                ".exe",
                ".apk",
                ".iso",
                ".msi",
        };

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnScanFile_Click(object sender, EventArgs e)
        {

            using (Process process = new Process())
            {
                process.StartInfo.Arguments = @"/c dir C:\Users\gabri\Downloads";
                process.StartInfo.WindowStyle= ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                
                process.Start();

                StreamReader reader = process.StandardOutput;

                string output = reader.ReadToEnd();

                OrderListFilesByNames(output);

            }
        }

        private void OrderListFilesByNames(string output)
        {
            const int limit = 41;

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

                    namesfiles.Add(new Files("Pictures", name));
                }
                else if (formatDocuments.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text = "[" + index + "]----------> " + name + "\r\n";
                    namesfiles.Add(new Files("Documents", name));
                }
                else if (formatVideos.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text += "[" + index + "]----------> " + name + "\r\n";
                    namesfiles.Add(new Files("Videos", name));
                }
                else if (formatApps.Any(line.Contains))
                {
                    string name = line.Substring(limit + 1);

                    index++;
                    txtTreeFiles.Text += "[" + index + "]----------> " + name + "\r\n";
                    namesfiles.Add(new Files("Apps", name));
                }
            }


            txtTreeFiles.Text += namesfiles.Count < 0 ? "¡No hay archivos para Mover!" : "\n\n¡Escaneo Finalizado";
        }

        private void btnAutoOrderFiles_Click(object sender, EventArgs e)
        {
            txtTreeFiles.Text = string.Empty;

            int index = 0;

            foreach(Files file in namesfiles) {

                using (Process process = new Process())
                {
                    index++;
                    process.StartInfo.FileName = "cmd.exe";
                    
                    process.StartInfo.Arguments = @"/c move " + @"""C:\Users\gabri\Downloads\"+ file.Name + @""" " + GetPath(file.Format);
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;

                    process.Start();

                    StreamReader reader = process.StandardOutput;
                    string output = reader.ReadToEnd();

                    txtTreeFiles.Text += "[" + index + "]----------> " + file.Name+ " [MOVIDO]\r\n";
                }

            }

            namesfiles.Clear();

        }

        private string GetPath(string format)
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

        }
    }
}