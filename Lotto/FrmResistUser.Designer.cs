namespace Lotto
{
    partial class FrmResistUser
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCheckPwd = new System.Windows.Forms.TextBox();
            this.lblCheckPwd = new System.Windows.Forms.Label();
            this.lblShowCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(74, 41);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(41, 12);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "아이디";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(74, 77);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 12);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "비밀번호";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(74, 142);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "이름";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(162, 38);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(201, 21);
            this.txtId.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(162, 73);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(201, 21);
            this.txtPwd.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(162, 139);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(201, 21);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(369, 36);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "중복 확인";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(162, 180);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "가입";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCheckPwd
            // 
            this.txtCheckPwd.Location = new System.Drawing.Point(162, 106);
            this.txtCheckPwd.Name = "txtCheckPwd";
            this.txtCheckPwd.PasswordChar = '*';
            this.txtCheckPwd.Size = new System.Drawing.Size(201, 21);
            this.txtCheckPwd.TabIndex = 10;
            this.txtCheckPwd.TextChanged += new System.EventHandler(this.txtCheckPwd_TextChanged);
            // 
            // lblCheckPwd
            // 
            this.lblCheckPwd.AutoSize = true;
            this.lblCheckPwd.Location = new System.Drawing.Point(74, 109);
            this.lblCheckPwd.Name = "lblCheckPwd";
            this.lblCheckPwd.Size = new System.Drawing.Size(81, 12);
            this.lblCheckPwd.TabIndex = 9;
            this.lblCheckPwd.Text = "비밀번호 확인";
            // 
            // lblShowCheck
            // 
            this.lblShowCheck.AutoSize = true;
            this.lblShowCheck.Location = new System.Drawing.Point(369, 109);
            this.lblShowCheck.Name = "lblShowCheck";
            this.lblShowCheck.Size = new System.Drawing.Size(0, 12);
            this.lblShowCheck.TabIndex = 11;
            // 
            // FrmResistUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 227);
            this.Controls.Add(this.lblShowCheck);
            this.Controls.Add(this.txtCheckPwd);
            this.Controls.Add(this.lblCheckPwd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblId);
            this.Name = "FrmResistUser";
            this.Text = "FrmResistUser";
            this.Load += new System.EventHandler(this.FrmResistUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCheckPwd;
        private System.Windows.Forms.Label lblCheckPwd;
        private System.Windows.Forms.Label lblShowCheck;
    }
}