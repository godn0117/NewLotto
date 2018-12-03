namespace Lotto
{
    partial class FrmAddrSearch
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbxStoreName = new System.Windows.Forms.TextBox();
            this.btnStoreName = new System.Windows.Forms.Button();
            this.tbxAddr = new System.Windows.Forms.TextBox();
            this.btnAddr = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnAllData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(465, 603);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbxStoreName
            // 
            this.tbxStoreName.Location = new System.Drawing.Point(2, 12);
            this.tbxStoreName.Name = "tbxStoreName";
            this.tbxStoreName.Size = new System.Drawing.Size(141, 21);
            this.tbxStoreName.TabIndex = 1;
            // 
            // btnStoreName
            // 
            this.btnStoreName.Location = new System.Drawing.Point(2, 49);
            this.btnStoreName.Name = "btnStoreName";
            this.btnStoreName.Size = new System.Drawing.Size(141, 32);
            this.btnStoreName.TabIndex = 2;
            this.btnStoreName.Text = "건물명찾기";
            this.btnStoreName.UseVisualStyleBackColor = true;
            this.btnStoreName.Click += new System.EventHandler(this.btnStoreName_Click);
            // 
            // tbxAddr
            // 
            this.tbxAddr.Location = new System.Drawing.Point(2, 143);
            this.tbxAddr.Name = "tbxAddr";
            this.tbxAddr.Size = new System.Drawing.Size(141, 21);
            this.tbxAddr.TabIndex = 3;
            // 
            // btnAddr
            // 
            this.btnAddr.Location = new System.Drawing.Point(2, 190);
            this.btnAddr.Name = "btnAddr";
            this.btnAddr.Size = new System.Drawing.Size(141, 32);
            this.btnAddr.TabIndex = 4;
            this.btnAddr.Text = "주소찾기";
            this.btnAddr.UseVisualStyleBackColor = true;
            this.btnAddr.Click += new System.EventHandler(this.btnAddr_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1239, 603);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.webBrowser1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnAllData);
            this.splitContainer2.Panel2.Controls.Add(this.btnStoreName);
            this.splitContainer2.Panel2.Controls.Add(this.tbxAddr);
            this.splitContainer2.Panel2.Controls.Add(this.btnAddr);
            this.splitContainer2.Panel2.Controls.Add(this.tbxStoreName);
            this.splitContainer2.Size = new System.Drawing.Size(770, 603);
            this.splitContainer2.SplitterDistance = 617;
            this.splitContainer2.TabIndex = 5;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(617, 603);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnAllData
            // 
            this.btnAllData.Location = new System.Drawing.Point(5, 282);
            this.btnAllData.Name = "btnAllData";
            this.btnAllData.Size = new System.Drawing.Size(141, 50);
            this.btnAllData.TabIndex = 5;
            this.btnAllData.Text = "판매점 목록";
            this.btnAllData.UseVisualStyleBackColor = true;
            this.btnAllData.Click += new System.EventHandler(this.btnAllData_Click);
            // 
            // FrmAddrSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 603);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmAddrSearch";
            this.Text = "FrmAddrSearch";
            this.Load += new System.EventHandler(this.FrmAddrSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbxStoreName;
        private System.Windows.Forms.Button btnStoreName;
        private System.Windows.Forms.TextBox tbxAddr;
        private System.Windows.Forms.Button btnAddr;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnAllData;
    }
}