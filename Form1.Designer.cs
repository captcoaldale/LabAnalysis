
namespace LabAnalysis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxClient = new System.Windows.Forms.GroupBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lbxClient = new System.Windows.Forms.ListBox();
            this.gbxClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxClient
            // 
            this.gbxClient.Controls.Add(this.lbxClient);
            this.gbxClient.Controls.Add(this.cmbClient);
            this.gbxClient.Location = new System.Drawing.Point(23, 29);
            this.gbxClient.Name = "gbxClient";
            this.gbxClient.Size = new System.Drawing.Size(593, 181);
            this.gbxClient.TabIndex = 0;
            this.gbxClient.TabStop = false;
            this.gbxClient.Text = "Client";
            // 
            // cmbClient
            // 
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(30, 28);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(264, 21);
            this.cmbClient.TabIndex = 0;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // lbxClient
            // 
            this.lbxClient.FormattingEnabled = true;
            this.lbxClient.Location = new System.Drawing.Point(30, 55);
            this.lbxClient.Name = "lbxClient";
            this.lbxClient.Size = new System.Drawing.Size(264, 43);
            this.lbxClient.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 699);
            this.Controls.Add(this.gbxClient);
            this.Name = "Form1";
            this.Text = "Lab Analysis";
            this.gbxClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.ListBox lbxClient;
    }
}

