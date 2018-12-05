using HtmlAgilityPack;
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
    public partial class FrmAddrSearch : Form
    {
        private Uri uri;
        private List<Store> lst = new List<Store>();
        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument htmlDoc;
        private DataTable addrTab;
        public FrmAddrSearch()
        {
            InitializeComponent();
        }

        private void FrmAddrSearch_Load(object sender, EventArgs e)
        {
            ResetDB();
            this.uri = new Uri("https://www.dhlottery.co.kr/store.do?method=topStoreRank&rank=1&pageGubun=L645");
            web.OverrideEncoding = Encoding.Default;
            htmlDoc = web.Load(uri);

            int lastPageNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//div//section//div//div//div//div//div//div//a")[13].GetAttributeValue("href", null).Substring(23, 3));

            for (int i = 1; i <= lastPageNum; i++)
            {
                this.uri = new Uri("https://www.dhlottery.co.kr/store.do?method=topStoreRank&rank=1&pageGubun=L645&nowPage=" + i);
                htmlDoc = web.Load(uri);
                Parsing(htmlDoc);
            }

            this.dataGridView1.DataSource = null;
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "InsertStore";



                addrTab = new DataTable();
                addrTab.Columns.Add("순위");
                addrTab.Columns.Add("판매점 명");
                addrTab.Columns.Add("1등 당첨횟수");
                addrTab.Columns.Add("주소");

                foreach (var item in lst)
                {
                    com.Parameters.Clear();

                    com.Parameters.AddWithValue("No", item.PkNo);
                    com.Parameters.AddWithValue("ShopName", item.ShopName);
                    com.Parameters.AddWithValue("WinningCount", item.WinningCount);
                    com.Parameters.AddWithValue("Addr", item.Addr);


                    DataRow row = addrTab.NewRow();
                    row["순위"] = item.PkNo;
                    row["판매점 명"] = item.ShopName;
                    row["1등 당첨횟수"] = item.WinningCount;
                    row["주소"] = item.Addr;

                    addrTab.Rows.Add(row);
                    try
                    {
                        com.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        continue;
                    }
                }
                con.Close();
            }
            //this.dataGridView1.DataSource = lst;
            this.dataGridView1.DataSource = addrTab;
        }

        private void ResetDB()
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "DeleteStore";

                con.Close();
            }
        }

        private void Parsing(HtmlAgilityPack.HtmlDocument htmlDoc)
        {
            HtmlNodeCollection t = htmlDoc.DocumentNode.SelectNodes("//tbody/tr");
            foreach (HtmlNode item in t)
            {
                if (item.SelectNodes("td")[0].GetAttributeValue("colspan", "") == "5")
                {
                    continue;
                }
                else if (item.GetAttributeValue("class", "") == "tbbghn")
                {
                    continue;
                }
                else
                {
                    //lst.Add(new Store(item.InnerText);
                    //MessageBox.Show(item.InnerText);
                    lst.Add(new Store(Int32.Parse(item.SelectNodes("td")[0].InnerText.Trim()), item.SelectNodes("td")[1].InnerText.Trim(), Int32.Parse(item.SelectNodes("td")[2].InnerText.Trim()), item.SelectNodes("td")[3].InnerText.Trim()));
                }
                //}
                //catch (FormatException ee)
                //{
                //    MessageBox.Show(ee.Message);
                //    continue;
                //}
                //catch (NullReferenceException ee)
                //{
                //    MessageBox.Show(ee.Message);
                //    continue;
                //}

            }
        }

        private void btnStoreName_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.lst.Clear();
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "FindStoreByShopName";

                com.Parameters.AddWithValue("shopName", this.tbxStoreName.Text.Trim());
                SqlDataReader sdr = com.ExecuteReader();

                while (sdr.Read())
                {
                    this.lst.Add(new Store(Int32.Parse(sdr["No"].ToString()), sdr["ShopName"].ToString(), Int32.Parse(sdr["WinningCount"].ToString()), sdr["Addr"].ToString()));
                }

                this.dataGridView1.DataSource = lst;
                this.dataGridView1.Columns[0].HeaderText = "순위";
                this.dataGridView1.Columns[1].HeaderText = "판매점 명";
                this.dataGridView1.Columns[2].HeaderText = "1등 당첨횟수";
                this.dataGridView1.Columns[3].HeaderText = "주소";
                con.Close();
            }
        }

        private void btnAddr_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.lst.Clear();
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "FindStoreByAddr";

                com.Parameters.AddWithValue("Addr", this.tbxAddr.Text.Trim());
                SqlDataReader sdr = com.ExecuteReader();

                while (sdr.Read())
                {
                    this.lst.Add(new Store(Int32.Parse(sdr["No"].ToString()), sdr["ShopName"].ToString(), Int32.Parse(sdr["WinningCount"].ToString()), sdr["Addr"].ToString()));
                }

                this.dataGridView1.DataSource = lst;
                this.dataGridView1.Columns[0].HeaderText = "순위";
                this.dataGridView1.Columns[1].HeaderText = "판매점 명";
                this.dataGridView1.Columns[2].HeaderText = "1등 당첨횟수";
                this.dataGridView1.Columns[3].HeaderText = "주소";
                con.Close();
            }
        }

        private void btnAllData_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.lst.Clear();
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "GetentryStore";

                var sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    this.lst.Add(new Store(Int32.Parse(sdr["No"].ToString()), sdr["ShopName"].ToString(), Int32.Parse(sdr["WinningCount"].ToString()), sdr["Addr"].ToString()));
                }
                this.dataGridView1.DataSource = lst;
                this.dataGridView1.Columns[0].HeaderText = "순위";
                this.dataGridView1.Columns[1].HeaderText = "판매점 명";
                this.dataGridView1.Columns[2].HeaderText = "1등 당첨횟수";
                this.dataGridView1.Columns[3].HeaderText = "주소";
                con.Close();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string addrmap = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            this.uri = new Uri("https://www.google.com/maps/place/"+addrmap);
            webBrowser1.Url = uri;
        }
    }
}
