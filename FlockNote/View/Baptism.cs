using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLDB;
using FlockNote.Model;
using FlockNote.Reports;

namespace FlockNote.View
{
    public partial class Baptism : Form
    {
        public Baptism()
        {
            InitializeComponent();
        }

        private void buttonViewBaptism_Click(object sender, EventArgs e)
        {
            String baptism = null;
            if (radioButtonBaptized.Checked == true)
            {
                baptism = "1";
            }
            if (radioButtonNonBaptized.Checked == true)
            {
                baptism = "0";
            }


            String repType = "Print All Member Baptism Report";
            ReportView r = new ReportView(repType, baptism);
            r.Show();
        }
    }
}
