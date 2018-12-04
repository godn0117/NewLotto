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
    public partial class FrmLogIn : Form
    {
        string id = "";
        string pwd = "";
        bool idExist = false;

        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FrmResistUser fru = new FrmResistUser();
            fru.ShowDialog();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckidExist";
                cmd.Parameters.AddWithValue("id", txtId.Text);

                SqlDataReader sdr = cmd.ExecuteReader();

                Users user = new Users();

                while (sdr.Read())
                {
                    user.Id = sdr["id"].ToString();
                    user.Password = sdr["password"].ToString();
                    user.Name = sdr["name"].ToString();

                    idExist = true;
                }
                
                if (user.Id != null)
                {
                    if (user.Password.Equals(txtPwd.Text))
                    {
                        MessageBox.Show("로그인 성공");
                        this.Close();
                        FrmAnalysis fa = new FrmAnalysis(user);
                        fa.Show();
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 틀렸습니다");
                    }
                }
                else
                {
                    MessageBox.Show("존재하지 않는 아이디 입니다.");
                }
                con.Close();              
            }
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
