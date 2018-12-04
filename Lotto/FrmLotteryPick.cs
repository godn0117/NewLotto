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
    public partial class FrmLotteryPick : Form
    {
        List<CheckBox> checkboxList = new List<CheckBox>();
        List<UserNumbers> userNumbersList = new List<UserNumbers>();
        
        int count = 0;
        int autoCount = 6;
        int[] selectedNums = new int[6];
        private Users user;

        public FrmLotteryPick()
        {
            InitializeComponent();
        }

        public FrmLotteryPick(Users user) : this()
        {
            this.user = user;
        }

        private void FrmLotteryPick_Load(object sender, EventArgs e)
        {
            lblCount.Text = count.ToString();

            foreach (Control item in groupBox1.Controls)
            {
                string autoChk;
                for (int i = 1; i < 45; i++)
                {
                    autoChk = "chk" + i.ToString();

                    if (item.Name.Equals(autoChk))
                    {
                        checkboxList.Add((CheckBox)item);
                    }
                }
            }

            for (int i = 1; i <= Form1.newTurnNum; i++)
            {
                cbxTurnNum.Items.Add(i);
            }

            DisplayUserNumbers();
        }

        private void CheckCount(object sender) // 몇개가 체크 되어있는지 확인하는 메서드
        {
            CheckBox s = (CheckBox)sender;
            if (s.Checked)
            {
                count++;
            }
            else
            {
                count--;
            }

            lblCount.Text = count.ToString();
            if (count == 6)
            {
                btnResist.Enabled = true;
            }
            else
            {
                btnResist.Enabled = false;
            }
        }

        private void RefrainChange(object sender)
        {
            CheckBox s = (CheckBox)sender;
            if (count > 6)
            {
                MessageBox.Show("6까지만 선택 가능 합니다");
                s.Checked = false;
            }

            ShowLbl();
        }

        #region CheckedEvent
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk7_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk8_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk9_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk10_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk11_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk12_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk13_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk14_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk15_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk16_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk17_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk18_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk19_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk20_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk21_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk22_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk23_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk24_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk25_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk26_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk27_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk28_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk29_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk30_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk31_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk32_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk33_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk34_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk35_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk36_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk37_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk38_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk39_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk40_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk41_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk42_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk43_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk44_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk45_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }
        #endregion

        private void btnAuto_Click(object sender, EventArgs e) // 자동 버튼 클릭 이벤트 처리
        {
            autoCount = 6 - count;

            Random rand = new Random();
            for (int i = 0; i < autoCount; i++)
            {
                string autoChk = "chk" + rand.Next(1, 45).ToString();
                foreach (Control item in groupBox1.Controls)
                {
                    if (item.Name == autoChk)
                    {
                        CheckBox c = (CheckBox)item;
                        if (c.Checked)
                        {
                            i--;
                        }
                        else
                        {
                            c.Checked = true;
                        }
                    }
                }
            }
        }

        private void ShowLbl() // 선택한 번호들을 라벨에 보여주는 메서드
        {
            selectedNums = new int[6];
            lblNumbers.Text = "";
            int i = 5;
            foreach (CheckBox item in groupBox1.Controls)
            {
                if (item.Checked)
                {
                    selectedNums[i] = int.Parse(item.Text);
                    i--;
                }
            }

            selectedNums.Reverse();

            for (int j = 0; j < selectedNums.Length; j++)
            {
                if (selectedNums[j] != 0)
                {
                    lblNumbers.Text += "   " + selectedNums[j].ToString();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) // 지우기 버튼 클릭 이벤트 처리
        {
            foreach (CheckBox item in checkboxList)
            {
                item.Checked = false;
            }
        }

        private void btnResist_Click(object sender, EventArgs e) // 등록 버튼 클릭 이벤트 처리
        {
            UserNumbers uNumbers = new UserNumbers();

            try
            {
                if (Int32.Parse(cbxTurnNum.Text) <= Form1.newTurnNum && cbxTurnNum.Text != null)
                {
                    uNumbers.Turnnumber = int.Parse(cbxTurnNum.SelectedItem.ToString());
                    uNumbers.Num1 = int.Parse(selectedNums[0].ToString());
                    uNumbers.Num2 = int.Parse(selectedNums[1].ToString());
                    uNumbers.Num3 = int.Parse(selectedNums[2].ToString());
                    uNumbers.Num4 = int.Parse(selectedNums[3].ToString());
                    uNumbers.Num5 = int.Parse(selectedNums[4].ToString());
                    uNumbers.Num6 = int.Parse(selectedNums[5].ToString());
                    uNumbers.Id = user.Id;

                    using (SqlConnection con = DBConnection.Connecting())
                    {
                        try
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "InsertUserNumbers";
                            cmd.Parameters.AddWithValue("turnnumber", uNumbers.Turnnumber);
                            cmd.Parameters.AddWithValue("num1", uNumbers.Num1);
                            cmd.Parameters.AddWithValue("num2", uNumbers.Num2);
                            cmd.Parameters.AddWithValue("num3", uNumbers.Num3);
                            cmd.Parameters.AddWithValue("num4", uNumbers.Num4);
                            cmd.Parameters.AddWithValue("num5", uNumbers.Num5);
                            cmd.Parameters.AddWithValue("num6", uNumbers.Num6);
                            cmd.Parameters.AddWithValue("id", uNumbers.Id);

                            cmd.ExecuteNonQuery();

                            con.Close();

                            DisplayUserNumbers();
                            MessageBox.Show("등록 성공");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("등록 실패");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("회차를 선택해 주세요");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("숫자를 입력해 주세요");
            }
        }

        public void DisplayUserNumbers()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            userNumbersList.Clear();

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectUserNumbersById";
                cmd.Parameters.AddWithValue("id", user.Id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    UserNumbers userNumbers = new UserNumbers();
                    userNumbers.Turnnumber = int.Parse(sdr["turnnumber"].ToString());
                    userNumbers.Num1 = int.Parse(sdr["num1"].ToString());
                    userNumbers.Num2 = int.Parse(sdr["num2"].ToString());
                    userNumbers.Num3 = int.Parse(sdr["num3"].ToString());
                    userNumbers.Num4 = int.Parse(sdr["num4"].ToString());
                    userNumbers.Num5 = int.Parse(sdr["num5"].ToString());
                    userNumbers.Num6 = int.Parse(sdr["num6"].ToString());
                    userNumbers.Id = user.Id;

                    userNumbersList.Add(userNumbers);
                }

                dataGridView1.DataSource = userNumbersList;

                dataGridView1.Columns[0].HeaderText = "회차";
                dataGridView1.Columns[1].HeaderText = "1구";
                dataGridView1.Columns[2].HeaderText = "2구";
                dataGridView1.Columns[3].HeaderText = "3구";
                dataGridView1.Columns[4].HeaderText = "4구";
                dataGridView1.Columns[5].HeaderText = "5구";
                dataGridView1.Columns[6].HeaderText = "6구";
            }
        }
    }
}
