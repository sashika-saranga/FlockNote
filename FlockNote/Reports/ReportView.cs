using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLDB;

namespace FlockNote.Reports
{
    public partial class ReportView : Form

    {
        String repType;
        String para1;
        String para2;
        String para3;


        public ReportView(String repType)
        {
            InitializeComponent();
            this.repType = repType;
        }

        public ReportView(String repType, String para1)
        {
            InitializeComponent();
            this.repType = repType;
            this.para1 = para1;
        }

        public ReportView(String repType, String para1, String para2)
        {
            InitializeComponent();
            this.repType = repType;
            this.para1 = para1;
            this.para2 = para2;
        }

        public ReportView(String repType, String para1, String para2, String para3)
        {
            InitializeComponent();
            this.repType = repType;
            this.para1 = para1;
            this.para2 = para2;
            this.para3 = para3;
        }
        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            if (repType == "Print Birth Day Report Daterange")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("from", para1);
                Para.Add("to", para2);
                DataSet dt = DBConnection.Select("SP_SelectBirthDayReportDaterange", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectBirthDayReportDaterange rpt = new Report_SelectBirthDayReportDaterange();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }

            }
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            if (repType == "Print All Member Deatils Report")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("genderPara", para1);
                DataSet dt = DBConnection.Select("SP_SelectAllMemberDetailsReport", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectAllMemberDetailsReport rpt = new Report_SelectAllMemberDetailsReport();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }

            }

            if (repType == "Print All Member Age Group Report")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("from", para1);
                Para.Add("to", para2);
                DataSet dt = DBConnection.Select("SP_SelectAllMemberAgeGroupReport", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectAllMemberAgeGroupReport rpt = new Report_SelectAllMemberAgeGroupReport();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }

            }

            if (repType == "Print All Member Baptism Report")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("baptism", para1);
                DataSet dt = DBConnection.Select("SP_SelectAllMemberBaptismDetailsReport", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectAllMemberBaptismDetailsReport rpt = new Report_SelectAllMemberBaptismDetailsReport();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }

            }

            if (repType == "Print Other Group Details")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("GroupID", para1);
                DataSet dt = DBConnection.Select("SP_SelectGroupDetailReport", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectOtherGroupDetail rpt = new Report_SelectOtherGroupDetail();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }

            }

            if (repType == "Print Cell Group Details")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("GroupID", para1);
                DataSet dt = DBConnection.Select("SP_SelectGroupDetailReport", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectCellGroupDetails rpt = new Report_SelectCellGroupDetails();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }

            }
            if (repType == "Print Expences Report")
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                Para.Add("fromdate", para1);
                Para.Add("todate", para2);
                DataSet dt = DBConnection.Select("SP_SelectExpenceDatewise", Para, 1);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    Report_SelectExpenseDatewise rpt = new Report_SelectExpenseDatewise();
                    rpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                {
                    MessageBox.Show("No data to show.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    return;
                }
            }
        }
    }
}
