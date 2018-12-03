using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class FrmResistUser : Form
    {
        bool idExist = false;
        bool checkId = false;
        bool checkPwd = false;
        bool checkName = false;

        public FrmResistUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            idExist = false;
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectUsers";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {                    
                    if (txtId.Text.Equals(sdr["id"].ToString()))
                    {
                        idExist = true;
                    }
                }

                con.Close();
            }

            if (idExist == true)
            {
                MessageBox.Show("중복된 아이디 입니다.");
                checkId = false;
                txtId.Clear();
                txtId.Focus();
            }
            else
            {
                MessageBox.Show("사용 가능한 아이디 입니다.");
                checkId = true;
            }

            Checking();
        }

        private void txtCheckPwd_TextChanged(object sender, EventArgs e)
        {
            if (txtPwd.Text != txtCheckPwd.Text)
            {
                lblShowCheck.Text = "비밀번호가 다릅니다";
                checkPwd = false;
            }
            else
            {
                lblShowCheck.Text = "비밀번호가 같습니다";
                checkPwd = true;
            }
            Checking();
        }        

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                checkName = true;
            }
            else
            {
                checkName = false;
            }

            Checking();
        }

        private void Checking()
        {
            if (checkId == true && checkPwd == true && checkName == true)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = DBConnection.Connecting())
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertUsers";
                    cmd.Parameters.AddWithValue("id", txtId.Text);
                    cmd.Parameters.AddWithValue("password", txtPwd.Text);
                    cmd.Parameters.AddWithValue("name", txtName.Text);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("회원가입을 축하드립니다");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("회원가입 실패");
            }
        }
    }
}
