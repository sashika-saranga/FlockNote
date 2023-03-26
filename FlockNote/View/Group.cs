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
    public partial class Group : Form
    {
        String userId;
        public Group()
        {
            this.userId = "0";
            InitializeComponent();
        }

        ControllerGroup cg = new ControllerGroup();

        private void Group_Load(object sender, EventArgs e)
        {
            loadSearchGroup();
            loadInsertGroup();
            loadEditGroup();
        }

        public void loadSearchGroup()
        {
            dataGridViewSearchGroup.Rows.Clear();
            String GroupName = textBoxSearchGroup.Text;
            DataTable dt = cg.SearchGroup(GroupName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String groupid = dt.Rows[i]["GroupID"].ToString();
                String groupname = dt.Rows[i]["Name"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String type = dt.Rows[i]["Type"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewSearchGroup.Rows.Add(groupid, groupname,active, type, date);
            }
         }

        public void loadInsertGroup()
        {
            dataGridViewAddGroup.Rows.Clear();
            String GroupName = textBoxAddGroup.Text;
            DataTable dt = cg.SearchGroup(GroupName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String groupid = dt.Rows[i]["GroupID"].ToString();
                String groupname = dt.Rows[i]["Name"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String type = dt.Rows[i]["Type"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewAddGroup.Rows.Add(groupid, groupname, active, type, date);
            }
        }

        public void loadEditGroup()
        {
            dataGridViewUpdateGroup.Rows.Clear();

            String GroupName = textBoxUpdateSearchGroup.Text;
            DataTable dt = cg.SearchGroup(GroupName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String groupid = dt.Rows[i]["GroupID"].ToString();
                String groupname = dt.Rows[i]["Name"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String type = dt.Rows[i]["Type"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewUpdateGroup.Rows.Add(groupid, groupname, active, type, date);
            }
        }

        private void buttonAddGroupSave_Click(object sender, EventArgs e)
        {
            loadInsertGroup();
            String GroupName = textBoxAddGroup.Text;
            String Active = checkBoxAddGroupActive.Checked.ToString();
            String Type = comboBoxGroupType.Text.ToString();
            String User = userId;
            String msg = cg.InsertGroup(GroupName, Active, Type, User);
            MessageBox.Show(msg);
            loadSearchGroup();
            loadInsertGroup();
            loadEditGroup();


            textBoxAddGroup.Clear();
            checkBoxAddGroupActive.Checked = false;
            loadInsertGroup();
        }

        private void textBoxSearchGroup_TextChanged(object sender, EventArgs e)
        {
            loadSearchGroup();
        }

        private void textBoxUpdateSearchGroup_TextChanged(object sender, EventArgs e)
        {
            loadEditGroup();
        }

        private void buttonUpdateGroupSave_Click(object sender, EventArgs e)
        {
            loadEditGroup();
            String groupId = labelUpdateGroupID.Text;
            String GroupName = textBoxUpdateGroup.Text;
            String Active = checkBoxUpdateGroup.Checked.ToString();
            String User = userId;
            String msg = cg.UpdateGroup(groupId, GroupName, Active, User);
            MessageBox.Show(msg);
            loadSearchGroup();
            loadInsertGroup();
            loadEditGroup();

            textBoxUpdateGroup.Clear();
            textBoxUpdateSearchGroup.Clear();
            checkBoxUpdateGroup.Checked = false;
            loadEditGroup();
        }

        private void dataGridViewUpdateGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelUpdateGroupID.Text = dataGridViewUpdateGroup.SelectedCells[0].Value.ToString();
            textBoxUpdateGroup.Text = dataGridViewUpdateGroup.SelectedCells[1].Value.ToString();
            checkBoxUpdateGroup.Checked = Convert.ToBoolean(dataGridViewUpdateGroup.Rows[e.RowIndex].Cells[2].Value.ToString());
            comboBoxUpdateGrouptype.Text = dataGridViewUpdateGroup.SelectedCells[3].Value.ToString();
        }

        private void buttonAddGroupCancel_Click(object sender, EventArgs e)
        {
            textBoxAddGroup.Clear();
            checkBoxAddGroupActive.Checked = false;
        }

        private void buttonUpdateGroupCancel_Click(object sender, EventArgs e)
        {
            textBoxUpdateGroup.Clear();
            textBoxUpdateSearchGroup.Clear();
            checkBoxUpdateGroup.Checked = false;
        }
    }
}
