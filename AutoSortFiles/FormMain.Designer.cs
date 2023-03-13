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
            this.txtTreeFiles = new System.Windows.Forms.TextBox();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.btnAutoOrderFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScanFile
            // 
            this.btnScanFile.Location = new System.Drawing.Point(12, 311);
            this.btnScanFile.Name = "btnScanFile";
            this.btnScanFile.Size = new System.Drawing.Size(150, 46);
            this.btnScanFile.TabIndex = 0;
            this.btnScanFile.Text = "Scan Files";
            this.btnScanFile.UseVisualStyleBackColor = true;
            this.btnScanFile.Click += new System.EventHandler(this.btnScanFile_Click);
            // 
            // txtTreeFiles
            // 
            this.txtTreeFiles.Location = new System.Drawing.Point(12, 12);
            this.txtTreeFiles.Multiline = true;
            this.txtTreeFiles.Name = "txtTreeFiles";
            this.txtTreeFiles.ReadOnly = true;
            this.txtTreeFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTreeFiles.Size = new System.Drawing.Size(580, 282);
            this.txtTreeFiles.TabIndex = 1;
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(492, 325);
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(100, 23);
            this.txtInformation.TabIndex = 2;
            // 
            // btnAutoOrderFiles
            // 
            this.btnAutoOrderFiles.Location = new System.Drawing.Point(168, 324);
            this.btnAutoOrderFiles.Name = "btnAutoOrderFiles";
            this.btnAutoOrderFiles.Size = new System.Drawing.Size(102, 23);
            this.btnAutoOrderFiles.TabIndex = 3;
            this.btnAutoOrderFiles.Text = "Auto Order Files";
            this.btnAutoOrderFiles.UseVisualStyleBackColor = true;
            this.btnAutoOrderFiles.Click += new System.EventHandler(this.btnAutoOrderFiles_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(604, 388);
            this.Controls.Add(this.btnAutoOrderFiles);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.txtTreeFiles);
            this.Controls.Add(this.btnScanFile);
            this.Name = "FormMain";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnScanFile;
        private TextBox txtTreeFiles;
        private TextBox txtInformation;
        private Button btnAutoOrderFiles;
    }
}