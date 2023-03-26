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
    public partial class Inventry_In : Form
    {
        public Inventry_In()
        {
            InitializeComponent();
        }

        ControllerMember cm = new ControllerMember();
        ControllerInventry ci = new ControllerInventry();
        ControllerMiscellaneous cmi = new ControllerMiscellaneous();
        private void radioControl()
        {
            if (radioButtonInventInPurches.Checked == true)
            {

                textBoxInventInCost.Enabled = true;
                radioButtonInventInMember.Enabled = false;
                radioButtonInventInOther.Enabled = false;
                comboBoxInventInSelectMember.Enabled = false;
                buttonInventInAddMember.Enabled = false;
                dataGridViewInventInMember.Enabled = false;
                comboBoxPayType.Enabled = true;


            }
            else if (radioButtonInventInDonation.Checked == true)
            {

                textBoxInventInCost.Enabled = false;
                radioButtonInventInMember.Enabled = true;
                radioButtonInventInOther.Enabled = true;
                comboBoxPayType.Enabled = false;

                if (radioButtonInventInMember.Checked == true)
                {
                    comboBoxInventInSelectMember.Enabled = true;
                    buttonInventInAddMember.Enabled = true;
                    dataGridViewInventInMember.Enabled = true;
                }
                else if (radioButtonInventInOther.Checked == true)
                {
                    comboBoxInventInSelectMember.Enabled = false;
                    buttonInventInAddMember.Enabled = false;
                    dataGridViewInventInMember.Enabled = false;
                }
            }
        }

        private void Inventry_In_Load(object sender, EventArgs e)
        {
            radioButtonInventInPurches.Checked = true;

            String member = "";
            DataTable dt2 = cm.SearchMember(member);
            comboBoxInventInSelectMember.DataSource = dt2;
            comboBoxInventInSelectMember.DisplayMember = "fullName";
            comboBoxInventInSelectMember.ValueMember = "MemberID";
            comboBoxInventInSelectMember.SelectedIndex = -1;

            DataTable dtGetCat1 = cmi.SelectPayType();
            comboBoxPayType.DataSource = dtGetCat1;
            comboBoxPayType.DisplayMember = "PaytypeName";
            comboBoxPayType.ValueMember = "PaytypeID";
            comboBoxPayType.SelectedIndex = -1;

            SelectAllItems();
        }

        private void radioButtonInventInPurches_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void radioButtonInventInDonation_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void radioButtonInventInMember_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void radioButtonInventInOther_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void buttonInventInAddMember_Click(object sender, EventArgs e)
        {
            String id = comboBoxInventInSelectMember.SelectedValue.ToString();
            String name = comboBoxInventInSelectMember.Text;
            dataGridViewInventInMember.Rows.Add(id, name, "Remove");
        }

        private void dataGridViewInventInMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridViewInventInMember.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void buttonInventInSave_Click(object sender, EventArgs e)
        {
            String item = comboBoxInventInSelectItem.Text;
            String qty = textBoxInventInQty.Text;
            String remark = richTextBoxInventInRemark.Text;
            String date = dateTimePickerInventInDate.Value.ToShortDateString();
            String cost ="0";
            String type;
            if (radioButtonInventInPurches.Checked == true) //if purchase
            {
                cost = textBoxInventInCost.Text;
                type = "Purchase";
                ci.InsertInventoryIn(item, qty, remark, date, type, cost);
            }
            else if (radioButtonInventInDonation.Checked == true)
            { 
                if (radioButtonInventInMember.Checked == true)
                {
                    type = "Member Donate";
                    ci.InsertInventoryIn(item, qty, remark, date, type, cost);
                    foreach (DataGridViewRow row in dataGridViewInventInMember.Rows)
                    {
                        String memberID = row.Cells[0].Value.ToString();
                        //MessageBox.Show(memberId+" "+givingID+" "+amount+" "+remark);
                        ci.InsertInventryInMembers(memberID);
                    }
                }
                else if (radioButtonInventInOther.Checked == true)
                {
                    type = "Other Donate";
                    ci.InsertInventoryIn(item, qty, remark, date, type, cost);
                }
            }
            SelectAllItems();
            cancel();
        }

        public void SelectAllItems()
        {
            comboBoxInventInSelectItem.DataSource = null;
            DataTable dt = ci.SelectAllItems("");
            comboBoxInventInSelectItem.DataSource = dt;
            comboBoxInventInSelectItem.DisplayMember = "Name";
            comboBoxInventInSelectItem.ValueMember = "ItemID";
            comboBoxInventInSelectItem.SelectedIndex = -1;
        }

        public void cancel()
        {
            comboBoxInventInSelectMember.SelectedIndex = -1;
            comboBoxPayType.SelectedIndex = -1;
            comboBoxInventInSelectItem.SelectedIndex = -1;
            radioButtonInventInMember.Checked = false;
            radioButtonInventInOther.Checked = false;
            radioButtonInventInDonation.Checked = true;
            radioButtonInventInPurches.Checked = true;
            textBoxInventInQty.Clear();
            textBoxInventInCost.Clear();
            richTextBoxInventInRemark.Clear();
            dataGridViewInventInMember.Rows.Clear();
        }

        private void buttonInventInCancel_Click(object sender, EventArgs e)
        {
            cancel();
        }
    }
}
