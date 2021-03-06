﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lotto
{
    public partial class Form1 : Form
    {
        internal static List<Lotto> lottoList = new List<Lotto>();
        internal static List<WinMoney> winMoneyList = new List<WinMoney>();

        List<int> unInsertedNumList = new List<int>();
        List<int> unInsertedWinMoneyList = new List<int>();

        HtmlWeb web = new HtmlWeb(); // 
        HtmlAgilityPack.HtmlDocument htmlDoc;
        static public int newTurnNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "로또";
            web.OverrideEncoding = Encoding.Default;
            htmlDoc = web.Load(new Uri("https://www.dhlottery.co.kr/gameResult.do?method=byWin")); //                     

            newTurnNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//option")[0].InnerText); // 제일 최신 회차 번호 변수에 저장  

            for (int i = 1; i <= newTurnNum; i++)
            {
                cbxTurnNum.Items.Add(i);
            }

            UpdateLotto(); // 갱신되지 않은 최신회차 가져오기
            InsertLotto(); // 최신회차까지 올라온 list 내용을 
            DisplayLottoList();

            InsertWinMoney();
            UpdateWinMoney();
            DisplayWinMoneyList();
        }

        private void btnAnalyst_Click(object sender, EventArgs e) // 분석 버튼 클릭시 이벤트
        {
            FrmLogIn fli = new FrmLogIn();
            fli.Show();
        }

        private void btnReNew_Click(object sender, EventArgs e) // 갱신 버튼 클릭 이벤트
        {
            UpdateLotto(); // 갱신되지 않은 최신회차 가져오기
            InsertLotto(); // 최신회차까지 올라온 list 내용을 
            DisplayLottoList();

            UpdateWinMoney();
            InsertWinMoney();
            DisplayWinMoneyList();
        }

        private void InsertLotto() // LottoDB에 Insert 작업 하는 메소드
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                foreach (var item in lottoList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertLotto";

                    cmd.Parameters.AddWithValue("turnnumber", item.TurnNumber);
                    cmd.Parameters.AddWithValue("num1", item.Num1);
                    cmd.Parameters.AddWithValue("num2", item.Num2);
                    cmd.Parameters.AddWithValue("num3", item.Num3);
                    cmd.Parameters.AddWithValue("num4", item.Num4);
                    cmd.Parameters.AddWithValue("num5", item.Num5);
                    cmd.Parameters.AddWithValue("num6", item.Num6);
                    cmd.Parameters.AddWithValue("bonusnum", item.BonusNum);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        private void InsertWinMoney() // WinMoneyDB에 Insert 작업 하는 메소드
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                foreach (var item in winMoneyList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertWinMoney";

                    cmd.Parameters.AddWithValue("turnnumber", item.Turnnumber);
                    cmd.Parameters.AddWithValue("win1", item.Win1);
                    cmd.Parameters.AddWithValue("win2", item.Win2);
                    cmd.Parameters.AddWithValue("win3", item.Win3);
                    cmd.Parameters.AddWithValue("win4", item.Win4);
                    cmd.Parameters.AddWithValue("win5", item.Win5);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }
        }

        private void UpdateLotto() // 로또 최근까지 업데이트뒤의 회차 ~ 최신회차를 갱신해서 list에 넣어준다.
        {
            lottoList.Clear(); // 리스트 클리어
            unInsertedNumList.Clear();

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLotto";

                SqlDataReader sdr = cmd.ExecuteReader();

                web.OverrideEncoding = Encoding.Default;
                htmlDoc = web.Load(new Uri("https://www.dhlottery.co.kr/gameResult.do?method=byWin")); //          
                newTurnNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//option")[0].InnerText);   // 제일 최신 회차 번호 변수에 저장           
                
                int nowNum = 0;
                for (int i = 1; i <= newTurnNum; i++)
                {
                    unInsertedNumList.Add(i);
                }

                while (sdr.Read())
                {
                    nowNum = Int32.Parse(sdr["turnnumber"].ToString());

                    unInsertedNumList.Remove(nowNum);
                }

                con.Close();

                if (unInsertedNumList.Count == 0)
                {
                    UpdateProgressBar.Maximum = 1;
                    UpdateProgressBar.Value = unInsertedNumList.Count + 1;
                    MessageBox.Show("로또 번호 업데이트 완료");
                    lblLastUpdate.Text = "마지막 업데이트 : " + DateTime.Now;
                }
                else
                {
                    UpdateProgressBar.Maximum = unInsertedNumList.Count;
                }

                foreach (var item in unInsertedNumList)
                {
                    UpdateProgressBar.Value += 1;
                    web.OverrideEncoding = Encoding.Default;
                    htmlDoc = web.Load(new Uri("https://www.dhlottery.co.kr/gameResult.do?method=byWin&drwNo=" + item.ToString()));
                    ParsingLotto(htmlDoc);
                    if (UpdateProgressBar.Value == UpdateProgressBar.Maximum)
                    {
                        MessageBox.Show("로또 번호 업데이트 완료");
                        lblLastUpdate.Text = "마지막 업데이트 : " + DateTime.Now;
                    }
                }
            }
        }

        private void UpdateWinMoney()
        {
            winMoneyList.Clear();
            unInsertedWinMoneyList.Clear();

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectWinMoney";

                SqlDataReader sdr = cmd.ExecuteReader();

                web.OverrideEncoding = Encoding.Default;
                htmlDoc = web.Load(new Uri("https://www.dhlottery.co.kr/gameResult.do?method=byWin")); //          
                newTurnNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//option")[0].InnerText);   // 제일 최신 회차 번호 변수에 저장           
                
                int nowNum = 0;
                for (int i = 1; i <= newTurnNum; i++)
                {
                    unInsertedWinMoneyList.Add(i);
                }
                
                while (sdr.Read())
                {
                    nowNum = Int32.Parse(sdr["turnnumber"].ToString());
                    unInsertedWinMoneyList.Remove(nowNum);
                }
                
                con.Close();

                if (unInsertedWinMoneyList.Count == 0)
                {
                    UpdateProgressBar2.Maximum = 1;
                    UpdateProgressBar2.Value = unInsertedNumList.Count + 1;
                    MessageBox.Show("당첨 번호 업데이트 완료");
                    lblLastUpdate.Text = "마지막 업데이트 : " + DateTime.Now;
                }
                else
                {
                    UpdateProgressBar2.Maximum = unInsertedWinMoneyList.Count;
                }

                foreach (var item in unInsertedWinMoneyList)
                {
                    UpdateProgressBar2.Value += 1;
                    web.OverrideEncoding = Encoding.Default;
                    htmlDoc = web.Load(new Uri("https://www.dhlottery.co.kr/gameResult.do?method=byWin&drwNo=" + item.ToString()));
                    ParsingWinNum(htmlDoc);
                    if (UpdateProgressBar2.Value == UpdateProgressBar2.Maximum)
                    {
                        MessageBox.Show("당첨 번호 업데이트 완료");
                        lblLastUpdate.Text = "마지막 업데이트 : " + DateTime.Now;
                    }
                }
            }
        }

        private void ParsingLotto(HtmlAgilityPack.HtmlDocument htmlDoc) // 원하는 회차를 파싱해서 로또 객체에 저장후 List에 넣어줌
        {
            string[] temp = new string[7];
            Lotto lotto = new Lotto();

            int i = 0;
            foreach (HtmlNode item in htmlDoc.DocumentNode.SelectNodes("//body//div//section//div//div//div//div//div//div//p//span"))
            {
                temp[i] = item.InnerText;
                i++;
            }

            foreach (var item in htmlDoc.DocumentNode.SelectNodes("//body//h4//strong"))
            {
                lotto.TurnNumber = Int32.Parse(item.InnerText.Remove(item.InnerText.Length - 1, 1));
            }

            lotto.Num1 = Int32.Parse(temp[0]);
            lotto.Num2 = Int32.Parse(temp[1]);
            lotto.Num3 = Int32.Parse(temp[2]);
            lotto.Num4 = Int32.Parse(temp[3]);
            lotto.Num5 = Int32.Parse(temp[4]);
            lotto.Num6 = Int32.Parse(temp[5]);
            lotto.BonusNum = Int32.Parse(temp[6]);
            lottoList.Add(lotto);

        }

        private void ParsingWinNum(HtmlAgilityPack.HtmlDocument htmlDoc)
        {
            int i;
            long[] temp = new long[5];
            WinMoney winMoney = new WinMoney();

            i = 0;
            foreach (HtmlNode item in htmlDoc.DocumentNode.SelectNodes("//body//div/section//div//div/div//table//tbody//tr"))
            {
                temp[i] = long.Parse(item.ChildNodes[7].InnerText.Substring(0, item.ChildNodes[7].InnerText.Length - 1).Replace(",", ""));
                i++;
            }

            foreach (var item in htmlDoc.DocumentNode.SelectNodes("//body//h4//strong"))
            {
                winMoney.Turnnumber = Int32.Parse(item.InnerText.Remove(item.InnerText.Length - 1, 1));
            }

            winMoney.Win1 = temp[0];
            winMoney.Win2 = temp[1];
            winMoney.Win3 = temp[2];
            winMoney.Win4 = temp[3];
            winMoney.Win5 = temp[4];
           
            winMoneyList.Add(winMoney);
        }

        private void DisplayLottoList() // LottoDB에서 전체 내용을 가져와 List에 저장후 DataGridView에 보여준다
        {
            lottoList.Clear();
            LottoGridView.Columns.Clear();
            LottoGridView.DataSource = null;

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLotto";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Lotto lotto = new Lotto(Int32.Parse(sdr["turnnumber"].ToString()), Int32.Parse(sdr["num1"].ToString()), Int32.Parse(sdr["num2"].ToString()), Int32.Parse(sdr["num3"].ToString()), Int32.Parse(sdr["num4"].ToString()), Int32.Parse(sdr["num5"].ToString()), Int32.Parse(sdr["num6"].ToString()), Int32.Parse(sdr["bonusnum"].ToString()));

                    lottoList.Add(lotto); // 

                    if (Int32.Parse(sdr["turnnumber"].ToString()) == newTurnNum)
                    {
                        lblCurrentLottoNum.Text = lotto.TurnNumber + "회차 : " + lotto.Num1 + " " + lotto.Num2 + " " + lotto.Num3 + " " + lotto.Num4 + " " + lotto.Num5 + " " + lotto.Num6 + " 보너스 번호 : " + lotto.BonusNum + "";
                    }
                }
            }
            LottoGridView.DataSource = lottoList;

            LottoGridView.Columns[0].HeaderText = "회차";
            LottoGridView.Columns[1].HeaderText = "1구";
            LottoGridView.Columns[2].HeaderText = "2구";
            LottoGridView.Columns[3].HeaderText = "3구";
            LottoGridView.Columns[4].HeaderText = "4구";
            LottoGridView.Columns[5].HeaderText = "5구";
            LottoGridView.Columns[6].HeaderText = "6구";
            LottoGridView.Columns[7].HeaderText = "보너스구";
        }

        private void DisplayWinMoneyList()
        {
            winMoneyList.Clear();

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
                    WinMoney winMoney = new WinMoney();
                    winMoney.Turnnumber = Int32.Parse(sdr["turnnumber"].ToString());
                    winMoney.Win1 = long.Parse(sdr["win1"].ToString());
                    winMoney.Win2 = long.Parse(sdr["win2"].ToString());
                    winMoney.Win3 = long.Parse(sdr["win3"].ToString());
                    winMoney.Win4 = long.Parse(sdr["win4"].ToString());
                    winMoney.Win5 = long.Parse(sdr["win5"].ToString());

                    winMoneyList.Add(winMoney); //                     
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) // 조회 버튼 클릭시 이벤트 처리 메소드
        {
            try
            {
                if (Int32.Parse(cbxTurnNum.Text) <= newTurnNum && cbxTurnNum.Text != null)
                {
                    LottoGridView.DataSource = null;
                    LottoGridView.Columns.Clear();
                    foreach (Lotto item in lottoList)
                    {
                        if (cbxTurnNum.Text.ToString().Equals(item.TurnNumber.ToString()))
                        {
                            string[] s = { item.TurnNumber.ToString(), item.Num1.ToString(), item.Num2.ToString(), item.Num3.ToString(), item.Num4.ToString(), item.Num5.ToString(), item.Num6.ToString(), item.BonusNum.ToString() };
                            LottoGridView.Columns.Add("turnnumber", "회차");
                            LottoGridView.Columns.Add("num1", "1구");
                            LottoGridView.Columns.Add("num2", "2구");
                            LottoGridView.Columns.Add("num3", "3구");
                            LottoGridView.Columns.Add("num4", "4구");
                            LottoGridView.Columns.Add("num5", "5구");
                            LottoGridView.Columns.Add("num6", "6구");
                            LottoGridView.Columns.Add("bonusnum", "보너스구");
                            LottoGridView.Rows.Add(s);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("회차를 입력해 주세요");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("숫자를 입력해 주세요");
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            DisplayLottoList();            
        }

        private void LottoGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
