using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLDB;
using FlockNote.Control;


namespace FlockNote.View
{
    public partial class Member_Assign : Form
    {
        public Member_Assign()
        {
            InitializeComponent();
        }

        ControllerGroup cg = new ControllerGroup();
        ControllerMemberAssign cm = new ControllerMemberAssign();

        private void Member_Assign_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonMemberAssignGroupClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClearMemberRole_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxGroupMemberAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMemberAssignGroup();
        }

        private void loadMemberAssignGroup()
        {
            dataGridViewMemberGroup.Rows.Clear();
            try
            {
                String group = comboBoxGroupMemberAssign.SelectedValue.ToString();
                DataTable dt = cm.SelectAssignedMember(group);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String memberid = dt.Rows[i]["MemberID"].ToString();
                    String memberName = dt.Rows[i]["fullName"].ToString();
                    this.dataGridViewMemberGroup.Rows.Add(memberid, memberName, "Remove");
                }

                DataTable dt2 = cm.SelectNotAssignedMember(group);
                comboBoxSelectMemberAssign.DataSource = dt2;
                comboBoxSelectMemberAssign.DisplayMember = "fullName";
                comboBoxSelectMemberAssign.ValueMember = "MemberID";
                comboBoxSelectMemberAssign.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void loadMemberAssignRole()
        {
            comboBoxAssignSelectMember.DataSource = null;
            try
            {
                String group = comboBoxAssignSelectGroup.SelectedValue.ToString();
                //String group = "1";
                DataTable dt = cm.SelectAssignedMember(group);
                comboBoxAssignSelectMember.DataSource = dt;
                comboBoxAssignSelectMember.DisplayMember = "fullName";
                comboBoxAssignSelectMember.ValueMember = "MemberID";
                comboBoxAssignSelectMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void loadMemberAssignMemberRole()
        {
            comboBoxAssignSelectRole.DataSource = null;
            dataGridViewViewMemberRole.Rows.Clear();
            try
            {
                String group = comboBoxAssignSelectGroup.SelectedValue.ToString();
                String member = comboBoxAssignSelectMember.SelectedValue.ToString();
                DataTable dt = cm.SelectAssignedRoleMemberGroup(group,member);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String roleid = dt.Rows[i]["RoleID"].ToString();
                    String roleName = dt.Rows[i]["RoleName"].ToString();
                    this.dataGridViewViewMemberRole.Rows.Add(roleid, roleName, "Remove");
                }
                DataTable dt2 = cm.SelectNotAssignedRoleMemberGroup(group, member);
                comboBoxAssignSelectRole.DataSource = dt2;
                comboBoxAssignSelectRole.DisplayMember = "RoleName";
                comboBoxAssignSelectRole.ValueMember = "RoleID";
                comboBoxAssignSelectRole.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void buttonAddGroupMemberAssign_Click(object sender, EventArgs e)
        {
            String group = comboBoxGroupMemberAssign.SelectedValue.ToString();
            String member = comboBoxSelectMemberAssign.SelectedValue.ToString();
            cm.InsertGroupMember(group, member);
            loadMemberAssignGroup();
        }

        private void comboBoxAssignSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMemberAssignRole();
        }

        private void comboBoxAssignSelectMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMemberAssignMemberRole();
        }

        private void buttonAddAssignRole_Click(object sender, EventArgs e)
        {
            String group = comboBoxAssignSelectGroup.SelectedValue.ToString();
            String member = comboBoxAssignSelectMember.SelectedValue.ToString();
            String role = comboBoxAssignSelectRole.SelectedValue.ToString();
            cm.InsertRoleMember(group, member, role);
            loadMemberAssignMemberRole();
        }

        private void dataGridViewMemberGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                String memberid = dataGridViewMemberGroup.SelectedCells[0].Value.ToString();
                String name = dataGridViewMemberGroup.SelectedCells[1].Value.ToString();
                String groupid = comboBoxGroupMemberAssign.SelectedValue.ToString();
                DialogResult res = MessageBox.Show("Do you want to delete " + name + " ?", "Delete Member?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    cm.DeleteGroupMember(memberid, groupid);
                    loadMemberAssignGroup();
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
                String groupid = comboBoxAssignSelectGroup.SelectedValue.ToString();
                String roleid = dataGridViewViewMemberRole.SelectedCells[0].Value.ToString();
                String rname = dataGridViewViewMemberRole.SelectedCells[1].Value.ToString();
                DialogResult res = MessageBox.Show("Do you want to delete " + rname + " ?", "Delete Member?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    cm.DeleteGroupMemberRole(memberid, groupid, roleid);
                    loadMemberAssignMemberRole();
                }
            }
        }

        private void comboBoxAssignGroupSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String GroupType = comboBoxAssignGroupSelectType.Text.ToString();
            DataTable dtGetCat = cg.SelectGroupByType(GroupType);
            comboBoxGroupMemberAssign.DataSource = dtGetCat;
            comboBoxGroupMemberAssign.DisplayMember = "Name";
            comboBoxGroupMemberAssign.ValueMember = "GroupID";
            comboBoxGroupMemberAssign.SelectedIndex = -1;
        }

        private void comboBoxAssignRoleSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String GroupType = comboBoxAssignRoleSelectType.Text.ToString();
            DataTable dtGetCat1 = cg.SelectGroupByType(GroupType);
            comboBoxAssignSelectGroup.DataSource = dtGetCat1;
            comboBoxAssignSelectGroup.DisplayMember = "Name";
            comboBoxAssignSelectGroup.ValueMember = "GroupID";
            comboBoxAssignSelectGroup.SelectedIndex = -1;
        }



    }
}
