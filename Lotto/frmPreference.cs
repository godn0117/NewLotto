﻿using System;
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
    public partial class frmPreference : Form
    {
        Users user = new Users();
        private List<UserNumbers> uNlst = new List<UserNumbers>();
        private List<Lotto> lNlst = new List<Lotto>();

        public frmPreference()
        {
            InitializeComponent();
        }
        
        FrmNumberPick fnp;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        public frmPreference(Users userInfo) : this()
        {
            user.Id = userInfo.Id;
        }

        private void frmPreference_Load(object sender, EventArgs e)
        {
            this.Text = "선호번호 분석";
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
                    this.uNlst.Add(new UserNumbers(Int32.Parse(sdr["turnnumber"].ToString()), Int32.Parse(sdr["num1"].ToString()), Int32.Parse(sdr["num2"].ToString()), Int32.Parse(sdr["num3"].ToString()), Int32.Parse(sdr["num4"].ToString()), Int32.Parse(sdr["num5"].ToString()), Int32.Parse(sdr["num6"].ToString())));
                }
                this.dataGridView1.DataSource = uNlst;
                con.Close();
            }

            CompareNumber();

            Percentage();
        }



        private void CompareNumber()
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                for (int i = 0; i < uNlst.Count; i++)
                {
                    con.Open();
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SelectLottoByTurnnumber";

                    cmd.Parameters.AddWithValue("turnnumber", Int32.Parse(uNlst[i].Turnnumber.ToString()));
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        this.lNlst.Add(new Lotto(Int32.Parse(sdr["turnnumber"].ToString()),Int32.Parse(sdr["num1"].ToString()), Int32.Parse(sdr["num2"].ToString()), Int32.Parse(sdr["num3"].ToString()), Int32.Parse(sdr["num4"].ToString()), Int32.Parse(sdr["num5"].ToString()), Int32.Parse(sdr["num6"].ToString()), Int32.Parse(sdr["bonusnum"].ToString())));
                    }
                    con.Close();
                }
                this.dataGridView2.DataSource = lNlst;
            }
        }

        private void Percentage()
        {
            foreach (UserNumbers item in uNlst)
            {
                foreach (Lotto item2 in lNlst)
                {
                    if (item.Turnnumber == item2.TurnNumber)
                    {
                        foreach (var item3 in item.MakeList())
                        {
                            foreach (var item4 in item2.MakeList())
                            {
                                // 유저값과 로또값을 비교하고 확률로 나타내기
                            }
                        }
                    }
                }
            }
        }
    }
}

