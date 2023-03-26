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
    public partial class ReportAgeGroup : Form
    {
        public ReportAgeGroup()
        {
            InitializeComponent();
        }

        private void buttonViewMembers_Click(object sender, EventArgs e)
        {
            String from = "0";
            String to = "0";
            if (radioButtonAge0to5.Checked == true)
            {
                from = "0";
                to = "5";
            }
            if (radioButtonAge6to10.Checked == true)
            {
                from = "6";
                to = "12";
            }

            if (radioButtonAge11to18.Checked == true)
            {
                from = "13";
                to = "18";
            }

            if (radioButtonAbove18.Checked == true)
            {
                from = "19";
                to = "120";
            }

            String repType = "Print All Member Age Group Report";
            ReportView r = new ReportView(repType, from, to);
            r.Show();
            //if (radioButtonAge0to5.Checked == true)
            //{
            //    String repType = "Print All Member Age Group Report";
            //    ReportView r = new ReportView(repType);
            //    r.Show();
            //}
        }
    }
}
