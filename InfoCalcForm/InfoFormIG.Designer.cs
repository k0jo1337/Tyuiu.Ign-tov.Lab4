namespace InfoFormI
{
    partial class InfoFormIG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoFormIG));
            panelInfoFormMain = new Panel();
            textBoxShowInfo = new TextBox();
            panelInfoFormMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelInfoFormMain
            // 
            panelInfoFormMain.Controls.Add(textBoxShowInfo);
            panelInfoFormMain.Dock = DockStyle.Fill;
            panelInfoFormMain.Location = new Point(0, 0);
            panelInfoFormMain.Name = "panelInfoFormMain";
            panelInfoFormMain.Size = new Size(743, 130);
            panelInfoFormMain.TabIndex = 0;
            // 
            // textBoxShowInfo
            // 
            textBoxShowInfo.BackColor = Color.FromArgb(64, 64, 64);
            textBoxShowInfo.BorderStyle = BorderStyle.None;
            textBoxShowInfo.Dock = DockStyle.Fill;
            textBoxShowInfo.ForeColor = SystemColors.ButtonFace;
            textBoxShowInfo.Location = new Point(0, 0);
            textBoxShowInfo.Margin = new Padding(10);
            textBoxShowInfo.Multiline = true;
            textBoxShowInfo.Name = "textBoxShowInfo";
            textBoxShowInfo.ReadOnly = true;
            textBoxShowInfo.Size = new Size(743, 130);
            textBoxShowInfo.TabIndex = 0;
            textBoxShowInfo.Text = resources.GetString("textBoxShowInfo.Text");
            // 
            // InfoFormIG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(743, 130);
            Controls.Add(panelInfoFormMain);
            Name = "InfoFormIG";
            Text = "Лабораторная работа №4";
            Load += Form1_Load;
            panelInfoFormMain.ResumeLayout(false);
            panelInfoFormMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInfoFormMain;
        private TextBox textBoxShowInfo;
    }
}
