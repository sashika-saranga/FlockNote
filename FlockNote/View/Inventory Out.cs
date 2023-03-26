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
    public partial class Inventory_Out : Form
    {
        public Inventory_Out()
        {
            InitializeComponent();
        }

        ControllerInventry ci = new ControllerInventry();
        ControllerMiscellaneous cm = new ControllerMiscellaneous();

        public void SelectAllItems()
        {
            DataTable dt = ci.SelectAllItems("");
            comboBoxInventOutItem.DataSource = dt;
            comboBoxInventOutItem.DisplayMember = "Name";
            comboBoxInventOutItem.ValueMember = "ItemID";
            comboBoxInventOutItem.SelectedIndex = -1;
        }

        private void Inventory_Out_Load(object sender, EventArgs e)
        {
            DataTable dtGetCat1 = cm.SelectPayType();
            comboBoxPaymentMethode.DataSource = dtGetCat1;
            comboBoxPaymentMethode.DisplayMember = "PaytypeName";
            comboBoxPaymentMethode.ValueMember = "PaytypeID";
            comboBoxPaymentMethode.SelectedIndex = -1;

            SelectAllItems();
        }

        private void radioControl()
        {
            if (radioButtonInventOutSell.Checked == true)
            {
                textBoxInventOutTotalCost.Enabled = true;
                comboBoxPaymentMethode.Enabled = true;
            }
            else 
            {
                textBoxInventOutTotalCost.Enabled = false;
                comboBoxPaymentMethode.Enabled = false;
            }
        }

        private void radioButtonInventOutSell_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void radioButtonInventOutDonation_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void radioButtonInventOutDamage_CheckedChanged(object sender, EventArgs e)
        {
            radioControl();
        }

        private void buttonInventOutSave_Click(object sender, EventArgs e)
        {
            String item = comboBoxInventOutItem.SelectedValue.ToString();
            String qty = textBoxInventOutQty.Text;
            String date = dateTimePickerInventOutDate.Value.ToShortDateString();
            String cost = "0";
            String payType = "0";
            String type = "";
            String remark = richTextBoxInventOutRemark.Text;
            type = radioButtonInventOutSell.Checked ? "Sell" : radioButtonInventOutDonation.Checked ? "Donation" : "Damage";
            if(type.Equals("Sell")){
                cost = textBoxInventOutTotalCost.Text;
                payType = comboBoxPaymentMethode.SelectedValue.ToString();
            }

            ci.InsertInventoryOut(item, qty, date, cost, payType, type, remark);

            comboBoxInventOutItem.SelectedIndex = -1;
            comboBoxPaymentMethode.SelectedIndex = -1;
            textBoxInventOutQty.Clear();
            textBoxInventOutTotalCost.Clear();
            richTextBoxInventOutRemark.Clear();
            radioButtonInventOutSell.Checked = false;
            radioButtonInventOutDonation.Checked = false;
            radioButtonInventOutDamage.Checked = false;

        }

        private void buttonInventOutCancel_Click(object sender, EventArgs e)
        {
            comboBoxInventOutItem.SelectedIndex = -1;
            comboBoxPaymentMethode.SelectedIndex = -1;
            textBoxInventOutQty.Clear();
            textBoxInventOutTotalCost.Clear();
            richTextBoxInventOutRemark.Clear();
            radioButtonInventOutSell.Checked = false;
            radioButtonInventOutDonation.Checked = false;
            radioButtonInventOutDamage.Checked = false;
        }
    }
}
