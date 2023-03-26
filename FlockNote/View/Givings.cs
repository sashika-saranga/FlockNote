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
    public partial class Givings : Form
    {
        public Givings()
        {
            InitializeComponent();
        }

        ControllerGivings cg = new ControllerGivings();
        ControllerMiscellaneous cm = new ControllerMiscellaneous();
        private void Givings_Load(object sender, EventArgs e)
        {
            String MemberName = "";
            DataTable dtGetCat = cg.SearchMember(MemberName);
            comboBoxAddGivingsSelectMember.DataSource = dtGetCat;
            comboBoxAddGivingsSelectMember.DisplayMember = "fullName";
            comboBoxAddGivingsSelectMember.ValueMember = "MemberID";
            comboBoxAddGivingsSelectMember.SelectedIndex = -1;

            String GivingType = "";
            DataTable dtGetCat1 = cg.SearchGivingTypes(GivingType);
            comboBoxAddGivingType.DataSource = dtGetCat1;
            comboBoxAddGivingType.DisplayMember = "giving";
            comboBoxAddGivingType.ValueMember = "givingID";
            comboBoxAddGivingType.SelectedIndex = -1;


            DataTable dtGetCat2 = cm.SelectPayType();
            comboBoxAddGivingsPayType.DataSource = dtGetCat2;
            comboBoxAddGivingsPayType.DisplayMember = "PaytypeName";
            comboBoxAddGivingsPayType.ValueMember = "PaytypeID";
            comboBoxAddGivingsPayType.SelectedIndex = -1;

            AddSubTotalGivings();
        }

        private void buttonAddGivings_Click(object sender, EventArgs e)
        {
            //String type = comboBoxAddGivingType.SelectedItem.ToString();
            //String amount = textBoxAddGivingsAmount.Text;
            //String remark = textBoxAddGivingsRemark.Text;
            try
            {
                String memberID = comboBoxAddGivingsSelectMember.SelectedValue.ToString();
                String typeID = comboBoxAddGivingType.SelectedValue.ToString();
                String type = comboBoxAddGivingType.Text.ToString();
                String amount = textBoxAddGivingsAmount.Text;
                String remark = textBoxAddGivingsRemark.Text;
                dataGridViewAddGivings.Rows.Add(memberID,typeID, type, amount, remark);

                textBoxAddGivingsAmount.Clear();
                textBoxAddGivingsRemark.Clear();
                comboBoxAddGivingType.SelectedIndex = -1;

            }
            catch (FormatException)
            {
                
            }
            AddSubTotalGivings();

        }

        public void AddSubTotalGivings()
        {
            if (dataGridViewAddGivings.Rows.Count > 0)
            {
                double subtot = 0.0;
                foreach (DataGridViewRow row in dataGridViewAddGivings.Rows)
                {
                    double a = Convert.ToDouble(row.Cells[3].Value);
                    subtot += a;
                    textBoxAddGivingsTotal.Text = subtot.ToString();
                }
            }
            else
            {
                textBoxAddGivingsTotal.Text = "0.00";
            }

        }

        public void DeleteGivingsRowData()
        {
            foreach (DataGridViewRow item in this.dataGridViewAddGivings.SelectedRows)
            {
                dataGridViewAddGivings.Rows.RemoveAt(item.Index);
            }

            AddSubTotalGivings();

        }

        private void buttonDeleteAddGivings_Click(object sender, EventArgs e)
        {
            DeleteGivingsRowData();
        }

        private void buttonAddGivingsSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Save the Record?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String memberID = comboBoxAddGivingsSelectMember.SelectedValue.ToString();
                String Payment = textBoxAddGivingsTotal.Text;
                String payType = comboBoxAddGivingsPayType.Text.ToString();
                String User = "1";
                cg.InsertGivingHeader(memberID, Payment, payType, User);
                foreach (DataGridViewRow row in dataGridViewAddGivings.Rows)
                {
                    String givingID = row.Cells[1].Value.ToString();
                    String amount = row.Cells[3].Value.ToString();
                    String remark = row.Cells[4].Value.ToString();
                    //MessageBox.Show(memberId+" "+givingID+" "+amount+" "+remark);
                    cg.InsertGivingDetails(givingID, amount, remark);
                }
            }
            clearGivings();
                    
        }

        public void clearGivings()
        {
            comboBoxAddGivingsSelectMember.SelectedIndex = -1;
            comboBoxAddGivingType.SelectedIndex = -1;
            textBoxAddGivingsAmount.Clear();
            textBoxAddGivingsRemark.Clear();
            comboBoxAddGivingType.SelectedIndex = -1;
            dataGridViewAddGivings.Rows.Clear();
        }

        private void buttonAddGivingsCancel_Click(object sender, EventArgs e)
        {
            clearGivings();
        }
    }
}
