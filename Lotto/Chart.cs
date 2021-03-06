﻿using System;
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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        // 폼 한개만 띄우기
        private FrmColor fc;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(!(fc == null || !fc.Visible))
            {
                fc.Focus();
                return;
            }
            fc = new FrmColor();
            fc.MdiParent = this;
            fc.Show();
        }

        private FrmTest ft;
        private void toolStripButton4_Click(object sender, EventArgs e)
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

        private void Chart_Load(object sender, EventArgs e)
        {
            this.Text = "차트 분석";
        }
    }
}
