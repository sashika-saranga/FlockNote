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
    public partial class ReportCellGroups : Form
    {
        public ReportCellGroups()
        {
            InitializeComponent();
        }

        ControllerGroup cg = new ControllerGroup();

        private void ReportCellGroups_Load(object sender, EventArgs e)
        {
            String GroupType = comboBoxSelectCellGroups.Text.ToString();
            DataTable dtGetCat1 = cg.SearchCellGroup(GroupType);
            comboBoxSelectCellGroups.DataSource = dtGetCat1;
            comboBoxSelectCellGroups.DisplayMember = "Name";
            comboBoxSelectCellGroups.ValueMember = "GroupID";
            comboBoxSelectCellGroups.SelectedIndex = -1;
        }

        private void buttonViewCellGroups_Click(object sender, EventArgs e)
        {
            String groupID = comboBoxSelectCellGroups.SelectedValue.ToString();
            String repType = "Print Cell Group Details";
            ReportView r = new ReportView(repType, groupID);
            r.Show();
        }
    }
}
