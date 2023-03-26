using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.Control;

namespace FlockNote.View
{
    public partial class ReportViewLeaders : Form
    {
        public ReportViewLeaders()
        {
            InitializeComponent();
        }

        ControllerRole cr = new ControllerRole();
        private void ReportViewLeaders_Load(object sender, EventArgs e)
        {
            DataTable dt2 = cr.SelectLeaderRoles();
            comboBoxSelectLeader.DataSource = dt2;
            comboBoxSelectLeader.DisplayMember = "RoleName";
            comboBoxSelectLeader.ValueMember = "RoleID";
            comboBoxSelectLeader.SelectedIndex = -1;
        }
    }
}
