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
    public partial class frmPreference : Form
    {
        public frmPreference()
        {
            InitializeComponent();
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
