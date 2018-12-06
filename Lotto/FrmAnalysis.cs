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
            this.user = gotUser;

            InitializeComponent();
        }

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            this.Text = "분석 관리 기능창";

            toolStripLabelId.Text = "아이디 : " + user.Id;
            //toolStripLabelPwd.Text = "비밀번호 : " + user.Password;
            toolStripLabelName.Text = "이름 : " + user.Name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmLotteryPick flp = new FrmLotteryPick(user);
            flp.MdiParent = this;
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
            //frmChart.MdiParent = this;
            frmChart.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmAddrSearch fas = new FrmAddrSearch();
            fas.MdiParent = this;
            fas.Show();
        }private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmPreference fpf = new frmPreference(user);
            fpf.MdiParent = this;
            fpf.Show();
        }

        private FrmColor fc;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!(fc == null || !fc.Visible))
            {
                fc.Focus();
                return;
            }
            fc = new FrmColor();
            fc.MdiParent = this;
            fc.Show();
        }

        private FrmTest ft;
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (!(ft == null || !ft.Visible))
            {
                ft.Focus();
                return;
            }
            ft = new FrmTest();
            ft.MdiParent = this;
            ft.Show();
        }
    }
}
