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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        ControllerUser cu = new ControllerUser();

        public void loadUserDetails()
        {
            dataGridViewUser.Rows.Clear();
            DataTable dt = cu.SelectUserDeatails();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["id"].ToString();
                String username = dt.Rows[i]["username"].ToString();
                String password = dt.Rows[i]["password"].ToString();
                String type = dt.Rows[i]["type"].ToString();
                this.dataGridViewUser.Rows.Add(id, username, password, type);
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
             DataTable dt = cu.SelectUsers();
            comboBoxSelectUser.DataSource = dt;
            comboBoxSelectUser.DisplayMember = "username";
            comboBoxSelectUser.ValueMember = "id";
            loadUserDetails();
        }

        private void buttonUserSave_Click(object sender, EventArgs e)
        {
            if (buttonUserSave.Text == "Save")
            {
                try
                {

                    String UserName = textBoxUserName.Text;
                    String Password = textBoxPassword.Text;
                    String Type = comboBoxUserType.SelectedItem.ToString();
                    cu.InsertUsers(UserName, Password, Type);
                    MessageBox.Show("User Added Successfully");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (buttonUserSave.Text == "Edit")
            {

                try
                {
                    loadUserDetails();

                    String UserID = labelUserID.Text;
                    String Password = textBoxPassword.Text;
                    String Type = comboBoxUserType.SelectedItem.ToString();
                    cu.UpdateUser(UserID, Password, Type);
                    MessageBox.Show("User has been Updated");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            textBoxUserName.Clear();
            textBoxPassword.Clear();
            loadUserDetails();
        }

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUserSave.Text = "Edit";
            textBoxUserName.Enabled = false;
            textBoxUserName.Text = dataGridViewUser.SelectedCells[1].Value.ToString();
            textBoxPassword.Text = dataGridViewUser.SelectedCells[2].Value.ToString();
            comboBoxUserType.SelectedItem = dataGridViewUser.SelectedCells[3].Value.ToString();
            labelUserID.Text = dataGridViewUser.SelectedCells[0].Value.ToString();
        }

        private void buttonUserClear_Click(object sender, EventArgs e)
        {
            buttonUserSave.Text = "Save";
            textBoxUserName.Enabled = true;
            textBoxUserName.ResetText();
            textBoxPassword.ResetText();
        }

        private void buttonUserMoveRigrt_Click(object sender, EventArgs e)
        {
            movePermission(dataGridViewUserPermissionLeft, dataGridViewUserPermissionRight);  
        }

        private void buttonUserMoveLeft_Click(object sender, EventArgs e)
        {
            movePermission(dataGridViewUserPermissionRight, dataGridViewUserPermissionLeft);
        }

        public void movePermission(DataGridView from, DataGridView to)
        {
            for (int i = from.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = from.Rows[i];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                String txt = row.Cells[0].Value.ToString();
                String id = row.Cells[1].Value.ToString();
                if (chk != null && (bool)chk.EditedFormattedValue)
                {
                    //MessageBox.Show(txt);
                    from.Rows.RemoveAt(row.Index);
                    to.Rows.Add(txt, id);

                }
            }
        }

        private void comboBoxSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String userId = comboBoxSelectUser.SelectedValue.ToString();
                dataGridViewUserPermissionLeft.Rows.Clear();
                DataTable dt = cu.SelectAccessDenied(userId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String Permission = dt.Rows[i]["permissionName"].ToString();
                    String id = dt.Rows[i]["permissionCode"].ToString();
                    this.dataGridViewUserPermissionLeft.Rows.Add(Permission, id);
                }
            }
            catch (Exception ex)
            { }

            try
            {
                String userId = comboBoxSelectUser.SelectedValue.ToString();
                dataGridViewUserPermissionRight.Rows.Clear();
                DataTable dt = cu.SelectAccessGranted(userId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String Permission = dt.Rows[i]["permissionName"].ToString();
                    String id = dt.Rows[i]["permissionID"].ToString();
                    this.dataGridViewUserPermissionRight.Rows.Add(Permission, id);
                }
            }
            catch (Exception ex)
            { }
        }

        private void buttonUserPermissionUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewUserPermissionRight.Rows)
            {
                String permissionId = row.Cells[1].Value.ToString();
                String userId = comboBoxSelectUser.SelectedValue.ToString();
                String state = "true";
                cu.UpdateUserPermission(userId, permissionId, state);
            }
            foreach (DataGridViewRow row in dataGridViewUserPermissionLeft.Rows)
            {
                String permissionId = row.Cells[1].Value.ToString();
                String userId = comboBoxSelectUser.SelectedValue.ToString();
                String state = "false";
                cu.UpdateUserPermission(userId, permissionId, state);
            }
            MessageBox.Show("Permission Updated Successfully");
            dataGridViewUserPermissionRight.Rows.Clear();
            dataGridViewUserPermissionLeft.Rows.Clear();
        }
    }
}
