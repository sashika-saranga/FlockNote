using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.Control;
using System.Globalization;
using System.IO;

namespace FlockNote.View
{
    public partial class Member_Registration : Form
    {
        String userID;

        public Member_Registration()
        {
            this.userID = "1";
            InitializeComponent();
        }

        ControllerMember cm = new ControllerMember();

        private void buttonAddMemberSubmit_Click(object sender, EventArgs e)
        {
            String user = userID;
            String title = comboBoxMemberAddTitle.Text;
            String fname = textBoxMemberAddFirstName.Text;
            String lname = textBoxMemberAddLastName.Text;
            String address = richTextBoxMemberAddAddress.Text;
            String city = textBoxMemberAddCity.Text;
            String mobile = textBoxMemberAddMobile.Text;
            String phone = textBoxMemberAddHomePhone.Text;
            String gender = comboBoxMemberAddGender.Text;
            String baptized = Convert.ToString(checkBoxMemberAddBaptized.Checked);
            String bapdate = "12/31/9999";
            if (checkBoxMemberAddBaptized.Checked)
                bapdate = dateTimePickerMemberAddBaptizedDate.Value.ToString();
            String email = textBoxMemberAddEmail.Text;
            String dob = dateTimePickerMemberAddDOB.Value.ToString();
            String marriedstatus = comboBoxMemberAddMaridStatus.Text;
            String marrieddate = "12/31/9999";
            if (comboBoxMemberAddMaridStatus.SelectedIndex == 0)
                marrieddate = dateTimePickerMemberAddWedingDate.Value.ToString();
            String enable = Convert.ToString(checkBoxAddEnable.Checked);
            String occupation = textBoxMemberAddOccupation.Text;
            String browseImagePath = labelImagePath.Text;
            String msg = cm.InsertMember(title, fname, lname, gender, address, city, mobile, phone, email, occupation, baptized, bapdate, dob, marriedstatus, marrieddate, enable, user, browseImagePath);
            MessageBox.Show(msg);
            clearMember();
            reloadMember("");
            
        }

        public void reloadMember(String searchPara)
        {
            String defaultImagePath = Path.Combine(Environment.CurrentDirectory, @"Images\Default.jpg");
            pictureBoxaddMember.Image = new Bitmap(defaultImagePath);
            dataGridViewAddMember.Rows.Clear();
            dataGridViewUpdateMember.Rows.Clear();
            DataTable dt = cm.SearchMember(searchPara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String memberid = dt.Rows[i]["MemberID"].ToString();
                String title = dt.Rows[i]["Title"].ToString();
                String fname = dt.Rows[i]["FirstName"].ToString();
                String lname = dt.Rows[i]["LastName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String city = dt.Rows[i]["City"].ToString();
                String mobile = dt.Rows[i]["Mobile"].ToString();
                String phone = dt.Rows[i]["HomePhone"].ToString();
                String gender = dt.Rows[i]["Gender"].ToString();
                String baptized = dt.Rows[i]["Baptism"].ToString();
                String bapdate = "";
                if(baptized.Equals("True"))
                    bapdate = dt.Rows[i]["BaptizedDate"].ToString();
                String email = dt.Rows[i]["Email"].ToString();
                String dob = dt.Rows[i]["DOB"].ToString();
                String marriedstatus = dt.Rows[i]["MaritalStatus"].ToString();
                String marrieddate = "";
                if (marriedstatus.Equals("Married"))
                    marrieddate = dt.Rows[i]["WeddingDate"].ToString();
                String occupation = dt.Rows[i]["Occupation"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String image = dt.Rows[i]["image"].ToString();
                String createdDate = dt.Rows[i]["createdate"].ToString();
                String updatedDate = dt.Rows[i]["updatedate"].ToString();
                String userID = dt.Rows[i]["user"].ToString();
                String username = dt.Rows[i]["username"].ToString();
                this.dataGridViewAddMember.Rows.Add(memberid, title, fname, lname, gender, city, mobile, phone, email, occupation, baptized, bapdate, dob, marriedstatus, marrieddate, address, active, image, createdDate, updatedDate, userID, username);
                this.dataGridViewUpdateMember.Rows.Add(memberid, title, fname, lname, gender, city, mobile, phone, email, occupation, baptized, bapdate, dob, marriedstatus, marrieddate, address, active, image, createdDate, updatedDate, userID, username, "remove");
            }
            checkBoxAddEnable.Checked = true;

        }

        private void Member_Registration_Load(object sender, EventArgs e)
        {
            reloadMember("");
        }

        private void checkBoxMemberAddBaptized_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMemberAddBaptized.Checked)
                dateTimePickerMemberAddBaptizedDate.Enabled = true;
            else
                dateTimePickerMemberAddBaptizedDate.Enabled = false;
        }

        private void comboBoxMemberAddMaridStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMemberAddMaridStatus.SelectedIndex == 0)
                dateTimePickerMemberAddWedingDate.Enabled = true;
            else
                dateTimePickerMemberAddWedingDate.Enabled = false;
        }

        private void comboBoxMemberAddTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = comboBoxMemberAddTitle.SelectedIndex;
            if (val == 1 || val == 4)
                comboBoxMemberAddGender.SelectedIndex = 1;
            else
                comboBoxMemberAddGender.SelectedIndex = 0;
        }

        private void textBoxUpdateMemberSearch_TextChanged(object sender, EventArgs e)
        {
            String searchpara = textBoxUpdateMemberSearch.Text;
            reloadMember(searchpara);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            reloadMember("");
        }

        public void clearMember()
        {
            comboBoxMemberAddTitle.SelectedIndex = -1;
            textBoxMemberAddFirstName.Clear();
            textBoxMemberAddLastName.Clear();
            richTextBoxMemberAddAddress.Clear();
            textBoxMemberAddCity.Clear();
            textBoxMemberAddMobile.Clear();
            textBoxMemberAddHomePhone.Clear();
            comboBoxMemberAddGender.SelectedIndex = -1;
            checkBoxMemberAddBaptized.Checked = false;
            textBoxMemberAddEmail.Clear();
            comboBoxMemberAddMaridStatus.SelectedIndex = -1; 
            textBoxMemberAddOccupation.Clear();
        }
        public void clearUpdateMember()
        {
            comboBoxUpdateMemberTitle.SelectedIndex = -1;
            textBoxUpdateMemberFirstName.Clear();
            textBoxUpdateMemberLastName.Clear();
            richTextBoxUpdateMemberAddress.Clear();
            textBoxUpdateMemberCity.Clear();
            textBoxUpdateMemberMobile.Clear();
            textBoxUpdateMemberHomePhone.Clear();
            comboBoxUpdateMemberGender.SelectedIndex = -1;
            checkBoxUpdateMemberBaptized.Checked = false;
            textBoxUpdateMemberEmail.Clear();
            comboBoxUpdateMemberMaridStatus.SelectedIndex = -1;
            textBoxUpdateMemberOccupation.Clear();
        }

        private void buttonAddMemberCancel_Click(object sender, EventArgs e)
        {
            clearMember();
            reloadMember("");
        }

        private void dataGridViewUpdateMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String imagePath = "";
            if (e.RowIndex == -1) return;
            labelUpdateMemberID.Text = dataGridViewUpdateMember.SelectedCells[0].Value.ToString();
            comboBoxUpdateMemberTitle.Text = dataGridViewUpdateMember.SelectedCells[1].Value.ToString();
            textBoxUpdateMemberFirstName.Text = dataGridViewUpdateMember.SelectedCells[2].Value.ToString();
            textBoxUpdateMemberLastName.Text = dataGridViewUpdateMember.SelectedCells[3].Value.ToString();
            comboBoxUpdateMemberGender.Text = dataGridViewUpdateMember.SelectedCells[4].Value.ToString();
            richTextBoxUpdateMemberAddress.Text = dataGridViewUpdateMember.SelectedCells[15].Value.ToString();
            textBoxUpdateMemberCity.Text = dataGridViewUpdateMember.SelectedCells[5].Value.ToString();
            textBoxUpdateMemberMobile.Text = dataGridViewUpdateMember.SelectedCells[6].Value.ToString();
            textBoxUpdateMemberHomePhone.Text = dataGridViewUpdateMember.SelectedCells[7].Value.ToString();
            textBoxUpdateMemberEmail.Text = dataGridViewUpdateMember.SelectedCells[8].Value.ToString();
            textBoxUpdateMemberOccupation.Text = dataGridViewUpdateMember.SelectedCells[9].Value.ToString();
            var baptized = Convert.ToBoolean(dataGridViewUpdateMember.Rows[e.RowIndex].Cells[10].Value.ToString());
            checkBoxUpdateMemberBaptized.Checked = baptized;
            if (baptized)
            {
                dateTimePickerUpdateMemberBaptDate.Text = dataGridViewUpdateMember.SelectedCells[11].Value.ToString();
            }
            dateTimePickerUpdateMemberDOB.Text = dataGridViewUpdateMember.SelectedCells[12].Value.ToString();
            String marriedState = dataGridViewUpdateMember.SelectedCells[13].Value.ToString();
            comboBoxUpdateMemberMaridStatus.Text = marriedState;
            if (marriedState.Equals("Married"))
            {
                dateTimePickerUpdateMemberWeddingDate.Text = dataGridViewUpdateMember.SelectedCells[14].Value.ToString();
            }
            checkBoxUpdateEnable.Checked = Convert.ToBoolean(dataGridViewUpdateMember.Rows[e.RowIndex].Cells[16].Value.ToString());
            imagePath = dataGridViewUpdateMember.SelectedCells[17].Value.ToString();
            pictureBoxupdateimage.Image = Bitmap.FromFile(imagePath);

        }


        private void buttonUpdateMember_Click(object sender, EventArgs e)
        {
            pictureBoxupdateimage.Image = null;
            pictureBoxaddMember.Image = null;
            String user = userID;
            String id = labelUpdateMemberID.Text;
            String title = comboBoxUpdateMemberTitle.Text;
            String fname = textBoxUpdateMemberFirstName.Text;
            String lname = textBoxUpdateMemberLastName.Text;
            String gender = comboBoxUpdateMemberGender.Text;
            String remark = richTextBoxUpdateMemberAddress.Text;
            String city = textBoxUpdateMemberCity.Text;
            String mobile = textBoxUpdateMemberMobile.Text;
            String phone = textBoxUpdateMemberHomePhone.Text;
            String baptized = checkBoxUpdateMemberBaptized.Checked.ToString(); 
            String bapdate = "12/31/9999";
            if (checkBoxUpdateMemberBaptized.Checked)
                bapdate = dateTimePickerUpdateMemberBaptDate.Value.ToString();
            String email = textBoxUpdateMemberEmail.Text;
            String dob = dateTimePickerUpdateMemberDOB.Value.ToString();
            String marriedstatus = comboBoxUpdateMemberMaridStatus.Text;
            String marrieddate = "12/31/9999";
            if (comboBoxUpdateMemberMaridStatus.SelectedIndex == 0)
                marrieddate = dateTimePickerUpdateMemberWeddingDate.Value.ToString();
            String occupation = textBoxUpdateMemberOccupation.Text;
            String active = checkBoxUpdateEnable.Checked.ToString();
            String inactiveReason = comboBoxInactiveReason.Text;
            String browseImagePath = labelupdateimagepath.Text;
            String msg = cm.UpdateMember(id, title, fname, lname, gender, remark, city, mobile, phone, email, occupation, baptized, bapdate, dob, marriedstatus, marrieddate, active, inactiveReason, user, browseImagePath);
            MessageBox.Show(msg);
            reloadMember("");
        }

        private void buttonUpdateMemberCancel_Click(object sender, EventArgs e)
        {
            clearUpdateMember();
            reloadMember("");
        }

        private void dataGridViewUpdateMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //    e.RowIndex >= 0)
            //{
            //    String id = dataGridViewUpdateMember.SelectedCells[0].Value.ToString();
            //    String title = dataGridViewUpdateMember.SelectedCells[1].Value.ToString();
            //    String name = dataGridViewUpdateMember.SelectedCells[2].Value.ToString();
            //    DialogResult res = MessageBox.Show("Do you want to delete "+title+name+" ?", "Delete Member?",MessageBoxButtons.YesNo);
            //    if (res == DialogResult.Yes)
            //    {
            //        cm.DeleteMember(id);
            //        clearUpdateMember();
            //        reloadMember("");
            //    }
            //}
        }

        private void checkBoxUpdateMemberBaptized_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUpdateMemberBaptized.Checked)
                dateTimePickerUpdateMemberBaptDate.Visible = true;
            else
                dateTimePickerUpdateMemberBaptDate.Visible = false;
        }

        private void comboBoxUpdateMemberMaridStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUpdateMemberMaridStatus.Text.Equals("Married"))
                dateTimePickerUpdateMemberWeddingDate.Visible = true;
            else
                dateTimePickerUpdateMemberWeddingDate.Visible = false;
        }

        private void buttonphotobrows_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBoxaddMember.Image = new Bitmap(open.FileName);
                labelImagePath.Text = open.FileName;
            }
            else
            {
                MessageBox.Show("Please Select an Image", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonUpdateimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBoxupdateimage.Image = new Bitmap(open.FileName);
                labelupdateimagepath.Text = open.FileName;
            }

        }


    }
}
