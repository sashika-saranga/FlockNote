using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.Reports;
using SQLDB;

namespace FlockNote.View
{
    public partial class ReportExpenses : Form
    {
        public ReportExpenses()
        {
            InitializeComponent();
        }

        private void buttonViewExpenses_Click(object sender, EventArgs e)
        {
            String fromdate = dateTimePickerExpenseFrom.Value.ToString();
            String todate = dateTimePickerExpenseTo.Value.ToString();
            String repType = "Print Expences Report";
            ReportView r = new ReportView(repType, fromdate, todate);
            r.Show();
        }
    }
}
