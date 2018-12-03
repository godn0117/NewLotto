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

            int lastPageNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//section//article//article//div//div//ul//li//span//a")[11].Attributes[0].Value.Substring(23, 3));

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


                foreach (var item in lst)
                {
                    com.Parameters.Clear();

                    com.Parameters.AddWithValue("No", item.PkNo);
                    com.Parameters.AddWithValue("ShopName", item.ShopName);
                    com.Parameters.AddWithValue("WinningCount", item.WinningCount);
                    com.Parameters.AddWithValue("Addr", item.Addr);

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
            this.dataGridView1.DataSource = lst;

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
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
