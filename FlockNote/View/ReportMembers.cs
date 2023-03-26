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
    public partial class ReportMembers : Form
    {
        public ReportMembers()
        {
            InitializeComponent();
        }

        private void buttonViewMembers_Click(object sender, EventArgs e)
        {
            String selection = null;
            if (radioButtonAllMembers.Checked == true)
            {
                selection="";
            }
            if (radioButtonMale.Checked == true)
            {
                selection = "Male";
            }

            if (radioButtonFemale.Checked == true)
            {
                selection = "Female";
            }

            String repType = "Print All Member Deatils Report";
            ReportView r = new ReportView(repType, selection);
            r.Show();
        }
    }
}
