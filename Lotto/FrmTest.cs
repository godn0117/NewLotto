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
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {            
            this.Text = "패턴 분석";
            int num = 1;
            DataTable dt = new DataTable();

            for (int i = 0; i < 7; i++)
            {
                DataColumn column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");

                //column.DefaultValue = num++;

                // Add the column to the table. 
                dt.Columns.Add(column);

                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dt.Rows[i][j] = num++;
                    if (num == 46)
                    {
                        break;
                    }
                }

            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[1].HeaderText = "";
            dataGridView1.Columns[2].HeaderText = "";
            dataGridView1.Columns[3].HeaderText = "";
            dataGridView1.Columns[4].HeaderText = "";
            dataGridView1.Columns[5].HeaderText = "";
            dataGridView1.Columns[6].HeaderText = "";

            for (int i = Form1.lottoList.Count; i > 0; i--)
            {
                this.cboTurn.Items.Add(i);
            }
            //using (SqlConnection con = DBConnection.Connecting())
            //{
            //    con.Open();

            //    SqlCommand com = new SqlCommand();
            //    com.Connection = con;
            //    com.CommandType = CommandType.StoredProcedure;
            //    com.CommandText = "SelectLotto";

            //    SqlDataReader dr = com.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        this.cboTurn.Items.Add(Int32.Parse(dr[0].ToString()));
            //    }
            //    dr.Close();
            //    con.Close();
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {//당첨번호 표시
         //예외처리 -> 수정중
            try
            {
                if (Int32.Parse(this.cboTurn.Text) <= 0)
                {
                    MessageBox.Show("0회차보다 높아야합니다.");
                    return;
                }else if(Int32.Parse(this.cboTurn.Text) > Form1.newTurnNum){
                    MessageBox.Show("최신회차보다 높습니다. 최신회차로 검색합니다.");
                    this.cboTurn.Text = Form1.newTurnNum.ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("숫자만 입력해 주세요");
                return;
            }

            //표시 초기화

            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                foreach (DataGridViewCell item2 in item.Cells)
                {
                    item2.Selected = false;
                    item2.Style.BackColor = Color.White;
                }
            }
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SelectTurn";

                com.Parameters.AddWithValue("turnnumber", Int32.Parse(this.cboTurn.Text));

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 1; i < dr.FieldCount - 1; i++)
                    {
                        int number = Int32.Parse(dr[i].ToString());
                        if (number % 7 == 0)
                        {
                            dataGridView1.Rows[(number / 7) - 1].Cells[(number % 7) + 6].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[number / 7].Cells[(number % 7) - 1].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        
        // 엔터키 기능 추가
        private void cboTurn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
