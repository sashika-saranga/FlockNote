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
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        ControllerRole cr = new ControllerRole();

        public void loadSearchRole()
        {
            dataGridViewSearchRole.Rows.Clear();
            String RoleName = textBoxSearchRole.Text;
            DataTable dt = cr.SearchRole(RoleName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String roleid = dt.Rows[i]["RoleID"].ToString();
                String rolename = dt.Rows[i]["RoleName"].ToString();
                String roletype = dt.Rows[i]["RoleType"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewSearchRole.Rows.Add(roleid, rolename, roletype, active, date);
            }
        }

        public void loadInsertRole()
        {
            dataGridViewAddRole.Rows.Clear();
            String RoleName = textBoxAddRole.Text;
            DataTable dt = cr.SearchRole(RoleName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String role = dt.Rows[i]["RoleName"].ToString();
                String type = dt.Rows[i]["RoleType"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewAddRole.Rows.Add(role, type, active, date);
            }
        }

        public void loadEditRole()
        {
            dataGridViewUpdateRole.Rows.Clear();

            String RoleName = textBoxUpdateSearchRole.Text;
            DataTable dt = cr.SearchRole(RoleName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["RoleID"].ToString();
                String name = dt.Rows[i]["RoleName"].ToString();
                String type = dt.Rows[i]["RoleType"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewUpdateRole.Rows.Add(id, name, type, active, date);
            }

        }

        private void buttonRoleSave_Click(object sender, EventArgs e)
        {
            try
            {
                loadInsertRole();
                String RoleName = textBoxAddRole.Text;
                String RoleType = comboBoxAddRoleType.Text;
                String Active = checkBoxAddRoleActive.Checked.ToString();
                cr.InsertRole(RoleName, RoleType, Active);
                MessageBox.Show("Role Added");
                loadSearchRole();
                loadInsertRole();
                loadEditRole();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxAddRole.Clear();
            checkBoxAddRoleActive.Checked = false;
        }

        private void Role_Load(object sender, EventArgs e)
        {
            loadSearchRole();
            loadInsertRole();
            loadEditRole();
        }

        private void textBoxSearchRole_TextChanged(object sender, EventArgs e)
        {
            loadSearchRole();
        }

        private void buttonUpdateRoleSave_Click(object sender, EventArgs e)
        {
            try
            {
                loadEditRole();

                String roleid = labelUpdateRoleID.Text;
                String roleName = textBoxUpdateRole.Text;
                String roleType = comboBoxupdateRoleType.Text;
                String active = checkBoxUpdateRole.Checked.ToString();
                cr.EditRole(roleid, roleName, roleType, active);
                MessageBox.Show("Role has been Updated");
                loadSearchRole();
                loadInsertRole();
                loadEditRole();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxUpdateSearchRole.Clear();
            textBoxUpdateRole.Clear();
            checkBoxUpdateRole.Checked = false;
        }

        private void dataGridViewUpdateRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelUpdateRoleID.Text = dataGridViewUpdateRole.SelectedCells[0].Value.ToString();
            textBoxUpdateRole.Text = dataGridViewUpdateRole.SelectedCells[1].Value.ToString();
            comboBoxupdateRoleType.Text = dataGridViewUpdateRole.SelectedCells[2].Value.ToString();
            checkBoxUpdateRole.Checked = Convert.ToBoolean(dataGridViewUpdateRole.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void textBoxUpdateSearchRole_TextChanged(object sender, EventArgs e)
        {
            loadEditRole();
        }

        private void buttonAddRoleCancel_Click(object sender, EventArgs e)
        {
            textBoxAddRole.Clear();
            checkBoxAddRoleActive.Checked = false;

        }

        private void buttonUpdateRoleCancel_Click(object sender, EventArgs e)
        {
            textBoxUpdateSearchRole.Clear();
            textBoxUpdateRole.Clear();
            checkBoxUpdateRole.Checked = false;
        }

        
    }
}
