namespace AutoSortFiles
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScanFile = new System.Windows.Forms.Button();
            this.btnAutoOrderFiles = new System.Windows.Forms.Button();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lblTotalArchives = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnScanFile
            // 
            this.btnScanFile.Location = new System.Drawing.Point(12, 326);
            this.btnScanFile.Name = "btnScanFile";
            this.btnScanFile.Size = new System.Drawing.Size(150, 46);
            this.btnScanFile.TabIndex = 0;
            this.btnScanFile.Text = "Scan Files";
            this.btnScanFile.UseVisualStyleBackColor = true;
            this.btnScanFile.Click += new System.EventHandler(this.btnScanFile_Click);
            // 
            // btnAutoOrderFiles
            // 
            this.btnAutoOrderFiles.Location = new System.Drawing.Point(168, 338);
            this.btnAutoOrderFiles.Name = "btnAutoOrderFiles";
            this.btnAutoOrderFiles.Size = new System.Drawing.Size(102, 23);
            this.btnAutoOrderFiles.TabIndex = 3;
            this.btnAutoOrderFiles.Text = "Auto Order Files";
            this.btnAutoOrderFiles.UseVisualStyleBackColor = true;
            this.btnAutoOrderFiles.Click += new System.EventHandler(this.btnAutoOrderFiles_Click);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Location = new System.Drawing.Point(490, 338);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(102, 23);
            this.btnConfiguration.TabIndex = 4;
            this.btnConfiguration.Text = "Configuration";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // listViewFiles
            // 
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listViewFiles.Location = new System.Drawing.Point(12, 12);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(580, 293);
            this.listViewFiles.TabIndex = 5;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Files";
            this.columnHeader3.Width = 1024;
            // 
            // lblTotalArchives
            // 
            this.lblTotalArchives.AutoSize = true;
            this.lblTotalArchives.Location = new System.Drawing.Point(12, 308);
            this.lblTotalArchives.Name = "lblTotalArchives";
            this.lblTotalArchives.Size = new System.Drawing.Size(70, 15);
            this.lblTotalArchives.TabIndex = 6;
            this.lblTotalArchives.Text = "Total Files: 0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(604, 388);
            this.Controls.Add(this.lblTotalArchives);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.btnAutoOrderFiles);
            this.Controls.Add(this.btnScanFile);
            this.Name = "FormMain";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnScanFile;
        private Button btnAutoOrderFiles;
        private Button btnConfiguration;
        private ListView listViewFiles;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label lblTotalArchives;
    }
}