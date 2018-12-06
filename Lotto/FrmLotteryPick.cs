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

        long takeBackMoney = 0;
        int buyingMoney = 0;
        int calculateMoney = 0;

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
            this.Text = "내 로또 관리";
            lblCount.Text = count.ToString();

            foreach (Control item in groupBox1.Controls)
            {
                string autoChk;
                for (int i = 1; i <= 45; i++)
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
                    uNumbers.Turnnumber = int.Parse(cbxTurnNum.Text);
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
                    userNumbers.LogNum = int.Parse(sdr["logNum"].ToString());
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

                dataGridView1.Columns[0].HeaderText = "번호";
                dataGridView1.Columns[1].HeaderText = "회차";
                dataGridView1.Columns[2].HeaderText = "1구";
                dataGridView1.Columns[3].HeaderText = "2구";
                dataGridView1.Columns[4].HeaderText = "3구";
                dataGridView1.Columns[5].HeaderText = "4구";
                dataGridView1.Columns[6].HeaderText = "5구";
                dataGridView1.Columns[7].HeaderText = "6구";

               
            }
        }

        public void CompareToLottoNum()
        {
            int[] countHit;
            int[] countWin = { 0, 0, 0, 0, 0, };

            foreach (var item in userNumbersList)
            {
                buyingMoney -= 1000;
            }

            foreach (UserNumbers userLottoItem in userNumbersList)
            {
                countHit = new int[] { 0, 0, 0, 0, 0, 0, 0 };

                foreach (Lotto lottoItem in Form1.lottoList)
                {
                    if (userLottoItem.Turnnumber == lottoItem.TurnNumber)
                    {
                        int i = 0;

                        foreach (int lottoNum in lottoItem.MakeList())
                        {
                            foreach (int userLottoNum in userLottoItem.MakeList())
                            {
                                if (userLottoNum == lottoNum)
                                {
                                    countHit[i] = 1;
                                }
                            }
                            i++;
                        }
                    }
                }
                CalculateWin(countHit, countWin, userLottoItem);
            }

            string buyingMoneyForlbl = buyingMoney.ToString();
            string takeBackMoneyForlbl = takeBackMoney.ToString();
            string calculatedMoneyForlbl = (buyingMoney + takeBackMoney).ToString();

            for (int i = buyingMoneyForlbl.Length - 3; i >= 1; i = i - 3)
            {
                buyingMoneyForlbl = buyingMoneyForlbl.Insert(i, ",");
            }

            for (int i = takeBackMoneyForlbl.Length - 3; i >= 1; i = i - 3)
            {
                takeBackMoneyForlbl = takeBackMoneyForlbl.Insert(i, ",");
            }

            for (int i = calculatedMoneyForlbl.Length - 3; i >= 1; i = i - 3)
            {
                calculatedMoneyForlbl = calculatedMoneyForlbl.Insert(i, ",");
            }

            lblBuyed.Text = "투자 : " + buyingMoneyForlbl;
            lblTakeBack.Text = "회수 : " + takeBackMoneyForlbl;
            lblCalculation.Text = "손익계산 : " + calculatedMoneyForlbl; // 손익계산 label에 display
        }

        private void CalculateWin(int[] countHit, int[] countWin, UserNumbers userLottoItem)// 몇등 담첨됬는지 계산해주는 메서드
        {

            int sum = 0;
            for (int i = 0; i < countHit.Length - 1; i++)
            {
                sum += countHit[i];
            }

            int winNum = 0;



            if (sum == 6) // 1등 당첨
            {
                countWin[1 - 1] += 1;
                winNum = 1;
            }
            else if (sum == 5 && countHit[7 - 1] == 1) // 2등 당첨
            {
                countWin[2 - 1] += 1;
                winNum = 2;
            }
            else if (sum == 4) // 4등 당첨
            {
                countWin[4 - 1] += 1;
                winNum = 3;
            }
            else if (sum == 5) // 3등 당첨
            {
                countWin[3 - 1] += 1;
                winNum = 4;
            }
            else if (sum == 3) // 5등 당첨
            {
                countWin[5 - 1] += 1;
                winNum = 5;
            }

            
            if (winNum == 1)
            {
                takeBackMoney += FindWinMoney(1, userLottoItem); 
                ColorGridView(Color.Red, userLottoItem);
            }
            else if (winNum == 2)
            {
                takeBackMoney += FindWinMoney(2, userLottoItem);
                ColorGridView(Color.Blue, userLottoItem);
            }
            else if (winNum == 3)
            {
                takeBackMoney += FindWinMoney(3, userLottoItem);
                ColorGridView(Color.Green, userLottoItem);
            }
            else if (winNum == 4)
            {
                takeBackMoney += FindWinMoney(4, userLottoItem);
                ColorGridView(Color.Orange, userLottoItem);
            }
            else if (winNum == 5)
            {
                takeBackMoney += FindWinMoney(5, userLottoItem);
                ColorGridView(Color.Yellow, userLottoItem);
            }


            lblHitNum.Text = "";

            for (int i = 0; i < countWin.Length; i++)
            {
                lblHitNum.Text += (i + 1) + "등 : " + countWin[i] + "\r\n";
            }
        }

        private long FindWinMoney(int i, UserNumbers userLottoItem)
        {
            long money = 0;

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectWinMoney";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    if (userLottoItem.Turnnumber == int.Parse(sdr["turnnumber"].ToString()))
                    {
                        money = int.Parse(sdr["win" + i].ToString());
                    }
                }
            }

            return money;
        }

        private void ColorGridView(Color color, UserNumbers userLottoItem)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (int.Parse(item.Cells[0].Value.ToString()) == userLottoItem.LogNum)
                {
                    foreach (DataGridViewCell item2 in item.Cells)
                    {
                        item2.Style.BackColor = color;
                    }
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CompareToLottoNum();
        }

        FrmNumberPick fnp;
        private void button1_Click(object sender, EventArgs e)
        {
            if (fnp != null)
            {
                fnp.Focus();
                return;
            }
            fnp = new FrmNumberPick();
            fnp.Show();
        }
    }
}
