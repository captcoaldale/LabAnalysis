
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
            this.gbxTest = new System.Windows.Forms.GroupBox();
            this.dgvTotals = new System.Windows.Forms.DataGridView();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.lblTestType = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTestItems = new System.Windows.Forms.DataGridView();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.gbxSample = new System.Windows.Forms.GroupBox();
            this.dgvSample = new System.Windows.Forms.DataGridView();
            this.gbxClient.SuspendLayout();
            this.gbxTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestItems)).BeginInit();
            this.gbxSample.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSample)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxClient
            // 
            this.gbxClient.Controls.Add(this.cmbClient);
            this.gbxClient.Location = new System.Drawing.Point(23, 12);
            this.gbxClient.Name = "gbxClient";
            this.gbxClient.Size = new System.Drawing.Size(353, 80);
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
            // gbxTest
            // 
            this.gbxTest.Controls.Add(this.dgvTotals);
            this.gbxTest.Controls.Add(this.dgvParameters);
            this.gbxTest.Controls.Add(this.lblTestType);
            this.gbxTest.Controls.Add(this.lblEndDate);
            this.gbxTest.Controls.Add(this.label1);
            this.gbxTest.Controls.Add(this.dgvTestItems);
            this.gbxTest.Controls.Add(this.cmbMethod);
            this.gbxTest.Controls.Add(this.dtpEnd);
            this.gbxTest.Controls.Add(this.dtpBegin);
            this.gbxTest.Location = new System.Drawing.Point(23, 197);
            this.gbxTest.Name = "gbxTest";
            this.gbxTest.Size = new System.Drawing.Size(1539, 416);
            this.gbxTest.TabIndex = 1;
            this.gbxTest.TabStop = false;
            this.gbxTest.Text = "Test";
            this.gbxTest.Enter += new System.EventHandler(this.gbxTest_Enter);
            // 
            // dgvTotals
            // 
            this.dgvTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotals.Location = new System.Drawing.Point(1098, 70);
            this.dgvTotals.Name = "dgvTotals";
            this.dgvTotals.Size = new System.Drawing.Size(400, 280);
            this.dgvTotals.TabIndex = 8;
            // 
            // dgvParameters
            // 
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Location = new System.Drawing.Point(30, 73);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.Size = new System.Drawing.Size(403, 283);
            this.dgvParameters.TabIndex = 7;
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Location = new System.Drawing.Point(745, 39);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(58, 13);
            this.lblTestType.TabIndex = 6;
            this.lblTestType.Text = "Test Type:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(409, 38);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Begin Date:";
            // 
            // dgvTestItems
            // 
            this.dgvTestItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestItems.Location = new System.Drawing.Point(499, 70);
            this.dgvTestItems.Name = "dgvTestItems";
            this.dgvTestItems.Size = new System.Drawing.Size(610, 283);
            this.dgvTestItems.TabIndex = 3;
            this.dgvTestItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestItems_CellContentClick);
            // 
            // cmbMethod
            // 
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(827, 31);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(282, 21);
            this.cmbMethod.TabIndex = 2;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(488, 32);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(139, 20);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(214, 32);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(139, 20);
            this.dtpBegin.TabIndex = 0;
            this.dtpBegin.ValueChanged += new System.EventHandler(this.dtpBegin_ValueChanged);
            // 
            // gbxSample
            // 
            this.gbxSample.Controls.Add(this.dgvSample);
            this.gbxSample.Location = new System.Drawing.Point(389, 12);
            this.gbxSample.Name = "gbxSample";
            this.gbxSample.Size = new System.Drawing.Size(1173, 179);
            this.gbxSample.TabIndex = 2;
            this.gbxSample.TabStop = false;
            this.gbxSample.Text = "Sample";
            this.gbxSample.Enter += new System.EventHandler(this.gbxSample_Enter);
            // 
            // dgvSample
            // 
            this.dgvSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSample.Location = new System.Drawing.Point(23, 28);
            this.dgvSample.Name = "dgvSample";
            this.dgvSample.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSample.Size = new System.Drawing.Size(1109, 118);
            this.dgvSample.TabIndex = 2;
            this.dgvSample.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSample_CellContentClick_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1776, 699);
            this.Controls.Add(this.gbxSample);
            this.Controls.Add(this.gbxTest);
            this.Controls.Add(this.gbxClient);
            this.Name = "Form1";
            this.Text = "Lab Analysis";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.gbxClient.ResumeLayout(false);
            this.gbxTest.ResumeLayout(false);
            this.gbxTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestItems)).EndInit();
            this.gbxSample.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.GroupBox gbxTest;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.GroupBox gbxSample;
        private System.Windows.Forms.DataGridView dgvSample;
        private System.Windows.Forms.DataGridView dgvTestItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.DataGridView dgvTotals;
        private System.Windows.Forms.DataGridView dgvParameters;
    }
}

