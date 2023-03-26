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
    public partial class Branch_Members : Form
    {
        public Branch_Members()
        {
            InitializeComponent();
        }

        ControllerBranches cb = new ControllerBranches();
        ControllerBranchMembers cbm = new ControllerBranchMembers();

        private void Branch_Members_Load(object sender, EventArgs e)
        {
            String BranchName = "";
            DataTable dtGetCat = cb.SearchBranches(BranchName);
            comboBoxSelectBranchName.DataSource = dtGetCat;
            comboBoxSelectBranchName.DisplayMember = "BranchName";
            comboBoxSelectBranchName.ValueMember = "BranchID";
            comboBoxSelectBranchName.SelectedIndex = -1;

            String BranchName1 = "";
            DataTable dtGetCat1 = cb.SearchBranches(BranchName1);
            comboBoxAssignSelectBranch.DataSource = dtGetCat1;
            comboBoxAssignSelectBranch.DisplayMember = "BranchName";
            comboBoxAssignSelectBranch.ValueMember = "BranchID";
            comboBoxAssignSelectBranch.SelectedIndex = -1;

            //String RoleName = "";
            //DataTable dtGetCat1 = cr.SearchRole(RoleName);
            //comboBoxMemberRole.DataSource = dtGetCat1;
            //comboBoxMemberRole.DisplayMember = "RoleName";
            //comboBoxMemberRole.ValueMember = "RoleID";
            //comboBoxMemberRole.SelectedIndex = -1;
        }

        private void loadMemberAssignBranch()
        {
            dataGridViewBranchMembers.Rows.Clear();
            try
            {
                String branch = comboBoxSelectBranchName.SelectedValue.ToString();
                DataTable dt = cbm.SelectAssignedBranchMember(branch);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String memberid = dt.Rows[i]["MemberID"].ToString();
                    String memberName = dt.Rows[i]["fullName"].ToString();
                    this.dataGridViewBranchMembers.Rows.Add(memberid, memberName, "Remove");
                }

                DataTable dt2 = cbm.SelectNotAssignedBranchMember(branch);
                comboBoxSelectMemberName.DataSource = dt2;
                comboBoxSelectMemberName.DisplayMember = "fullName";
                comboBoxSelectMemberName.ValueMember = "MemberID";
                comboBoxSelectMemberName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
          
        }

        private void buttonAddBranchMemberAssign_Click(object sender, EventArgs e)
        {
            String branch = comboBoxSelectBranchName.SelectedValue.ToString();
            String member = comboBoxSelectMemberName.SelectedValue.ToString();
            cbm.InsertBranchMember(branch, member);
            loadMemberAssignBranch();
        }


        private void loadBranchMemberAssignRole()
        {
            comboBoxAssignSelectMember.DataSource = null;
            try
            {
                String branch = comboBoxAssignSelectBranch.SelectedValue.ToString();
                //String group = "1";
                DataTable dt = cbm.SelectAssignedBranchMember(branch);
                comboBoxAssignSelectMember.DataSource = dt;
                comboBoxAssignSelectMember.DisplayMember = "fullName";
                comboBoxAssignSelectMember.ValueMember = "MemberID";
                comboBoxAssignSelectMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void comboBoxAssignSelectBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBranchMemberAssignRole();
        }

        private void loadBranchMemberAssignMemberRole()
        {
            comboBoxAssignSelectRole.DataSource = null;
            dataGridViewViewMemberRole.Rows.Clear();
            try
            {
                String branch = comboBoxAssignSelectBranch.SelectedValue.ToString();
                String member = comboBoxAssignSelectMember.SelectedValue.ToString();
                DataTable dt = cbm.SelectAssignedRoleMemberBranch(branch, member);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String roleid = dt.Rows[i]["RoleID"].ToString();
                    String roleName = dt.Rows[i]["RoleName"].ToString();
                    this.dataGridViewViewMemberRole.Rows.Add(roleid, roleName, "Remove");
                }
                DataTable dt2 = cbm.SelectNotAssignedRoleMemberBranch(branch, member);
                comboBoxAssignSelectRole.DataSource = dt2;
                comboBoxAssignSelectRole.DisplayMember = "RoleName";
                comboBoxAssignSelectRole.ValueMember = "RoleID";
                comboBoxAssignSelectRole.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void comboBoxAssignSelectMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadBranchMemberAssignMemberRole();
        }

        private void buttonAddAssignRole_Click(object sender, EventArgs e)
        {
            String branch = comboBoxAssignSelectBranch.SelectedValue.ToString();
            String member = comboBoxAssignSelectMember.SelectedValue.ToString();
            String role = comboBoxAssignSelectRole.SelectedValue.ToString();
            cbm.InsertBranchMemberRole(member, branch, role);
            loadBranchMemberAssignMemberRole();
        }

        private void comboBoxSelectBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMemberAssignBranch();
        }

        private void dataGridViewBranchMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                String memberid = dataGridViewBranchMembers.SelectedCells[0].Value.ToString();
                String name = dataGridViewBranchMembers.SelectedCells[1].Value.ToString();
                String branchid = comboBoxSelectBranchName.SelectedValue.ToString();
                DialogResult res = MessageBox.Show("Do you want to delete " + name + " ?", "Delete Member?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    cbm.DeleteBranchMember(memberid, branchid);
                    loadMemberAssignBranch();
                }
            }
        }

        private void dataGridViewViewMemberRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                String memberid = comboBoxAssignSelectMember.SelectedValue.ToString();
                String groupid = comboBoxAssignSelectBranch.SelectedValue.ToString();
                String roleid = dataGridViewViewMemberRole.SelectedCells[0].Value.ToString();
                String rname = dataGridViewViewMemberRole.SelectedCells[1].Value.ToString();
                DialogResult res = MessageBox.Show("Do you want to delete " + rname + " ?", "Delete Member?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    cbm.DeleteBranchMemberRole(memberid, groupid, roleid);
                    loadBranchMemberAssignMemberRole();
                }
            }
        }
    }
}
