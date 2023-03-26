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
    public partial class BirthDays : Form
    {
        public BirthDays()
        {
            InitializeComponent();
        }

        private void buttonViewBday_Click(object sender, EventArgs e)
        {
            String fromdate = dateTimePickerViewBdayFrom.Value.ToString();
            String todate = dateTimePickerVieBdayTo.Value.ToString();
            String repType = "Print Birth Day Report Daterange";
            ReportView r = new ReportView(repType, fromdate, todate);
            r.Show();
        }
    }
}
