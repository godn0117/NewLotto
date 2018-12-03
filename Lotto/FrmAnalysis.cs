using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{    
    public partial class FrmAnalysis : Form
    {
        internal Users user = new Users();
        int[] numbers = new int[45];       
        
        public FrmAnalysis()
        {
            InitializeComponent();
        }

        public FrmAnalysis(Users gotUser)
        {
            user.Id = gotUser.Id;
            user.Name = gotUser.Name;
            user.Password = gotUser.Password;

            InitializeComponent();
        }

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            toolStripLabelId.Text = "아이디 : " + user.Id;
            toolStripLabelPwd.Text = "비밀번호 : " + user.Password;
            toolStripLabelName.Text = "이름 : " + user.Name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmLotteryPick flp = new FrmLotteryPick();
            flp.MdiParent = this;
            flp.Owner = this;
            flp.Show();
        }

        //폼 한개만 띄우기
        private Chart frmChart;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!(frmChart == null || !frmChart.Visible))
            {
                frmChart.Focus();
                return;
            }
            frmChart = new Chart();
            frmChart.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmAddrSearch fas = new FrmAddrSearch();
            fas.MdiParent = this;
            fas.Show();
        }       
    }
}
