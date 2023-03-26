using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.Control;
using FlockNote.Reports;

namespace FlockNote.View
{
    public partial class ReportGroups : Form
    {
        public ReportGroups()
        {
            InitializeComponent();
        }
        ControllerGroup cg = new ControllerGroup();

        private void ReportGroups_Load(object sender, EventArgs e)
        {
            String GroupType = comboBoxSelectGroups.Text.ToString();
            DataTable dtGetCat1 = cg.SearchOtherGroup(GroupType);
            comboBoxSelectGroups.DataSource = dtGetCat1;
            comboBoxSelectGroups.DisplayMember = "Name";
            comboBoxSelectGroups.ValueMember = "GroupID";
            comboBoxSelectGroups.SelectedIndex = -1;
        }

        private void buttonViewGroups_Click(object sender, EventArgs e)
        {
            String groupID = comboBoxSelectGroups.SelectedValue.ToString();
            String repType = "Print Other Group Details";
            ReportView r = new ReportView(repType,groupID);
            r.Show();
        }

    }
}
