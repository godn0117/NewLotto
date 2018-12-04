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
    public partial class frmPreference : Form
    {
        public frmPreference()
        {
            InitializeComponent();
        }

        private void frmPreference_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectUserNumbers";


            }
        }
    }
}
