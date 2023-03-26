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
    public partial class Add_Event : Form
    {
        public Add_Event()
        {
            InitializeComponent();
        }
        ControllerGroup cg = new ControllerGroup();
        ControllerGivings cm = new ControllerGivings();
        ControllerEvents ce = new ControllerEvents();
        private void Add_Event_Load(object sender, EventArgs e)
        {
            
            DataTable dtGetCat = cg.SelectGroupByType("Other Group");
            comboBoxSelectGroup.DataSource = dtGetCat;
            comboBoxSelectGroup.DisplayMember = "Name";
            comboBoxSelectGroup.ValueMember = "GroupID";
            comboBoxSelectGroup.SelectedIndex = -1;

            String MemberName = "";
            DataTable dtGetCat2 = cm.SearchMember(MemberName);
            comboBoxSelectMember.DataSource = dtGetCat2;
            comboBoxSelectMember.DisplayMember = "fullName";
            comboBoxSelectMember.ValueMember = "MemberID";
            comboBoxSelectMember.SelectedIndex = -1;
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            String groupid = comboBoxSelectGroup.SelectedValue.ToString();
            String groupName = comboBoxSelectGroup.Text.ToString();
            this.dataGridViewGroup.Rows.Add(groupid, groupName, "Remove");
        }

        private void dataGridViewGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridViewGroup.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridViewMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridViewMember.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            String memberid = comboBoxSelectMember.SelectedValue.ToString();
            String memberName = comboBoxSelectMember.Text.ToString();
            this.dataGridViewMember.Rows.Add(memberid, memberName, "Remove");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Save the Record?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String organizer = comboBoxEventOrgnizer.Text.ToString();
                String description = richTextBoxEventDescription.Text;
                String date = dateTimePickerEventDate.Value.ToString();
                String User = "1";
                ce.InsertEventHeader(organizer, description, date, User);

                foreach (DataGridViewRow row in dataGridViewGroup.Rows)
                {
                    String groupID = row.Cells[0].Value.ToString();
                    //MessageBox.Show(memberId+" "+givingID+" "+amount+" "+remark);
                    ce.InsertGroups(groupID);
                }

                foreach (DataGridViewRow row in dataGridViewMember.Rows)
                {
                    String memberID = row.Cells[0].Value.ToString();
                    //MessageBox.Show(memberId+" "+givingID+" "+amount+" "+remark);
                    ce.InsertMembers(memberID);
                }
            }
        }
    }
}
