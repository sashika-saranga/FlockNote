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
    public partial class Expences : Form
    {
        public Expences()
        {
            InitializeComponent();
        }
        ControllerExpences me = new ControllerExpences();
        ControllerPayType cpt = new ControllerPayType();

        private void Expences_Load(object sender, EventArgs e)
        {
            DataTable dtGetExp = me.SelectExpenceType();
            comboBoxExpenceType.DataSource = dtGetExp;
            comboBoxExpenceType.DisplayMember = "type";
            comboBoxExpenceType.ValueMember = "id";

            String payName = "";
            DataTable dtGetPayType = cpt.SearchPaymentType(payName);
            comboBoxPaymentType.DataSource = dtGetPayType;
            comboBoxPaymentType.DisplayMember = "PaytypeName";
            comboBoxPaymentType.ValueMember = "PaytypeID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String ExpencesTypes = comboBoxExpenceType.SelectedValue.ToString();
                String PaymentType = comboBoxPaymentType.SelectedValue.ToString();
                String Amount = textBoxAmount.Text;
                String Remark = richTextBoxRemark.Text;
                String date = dateTimePickerExpence.Value.ToString();
                me.InsertExpences(ExpencesTypes, PaymentType, Amount, Remark, date);

                MessageBox.Show("Expences Successfully Inserted");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            textBoxAmount.Clear();
            richTextBoxRemark.Clear();
        }

        public void findExpences()
        {
            try
            {
                String fromdate = dateTimePickerFrom.Value.ToString();
                String todate = dateTimePickerTo.Value.ToString();
                DataTable dt = me.SelectExpenceDatewise(fromdate, todate);
                dataGridViewDeleteExpence.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String id = dt.Rows[i]["ExpencesID"].ToString();
                    String type = dt.Rows[i]["ExpencesTypes"].ToString();
                    String Amount = dt.Rows[i]["Amount"].ToString();
                    String PaymentType = dt.Rows[i]["PaymentType"].ToString();
                    String remark = dt.Rows[i]["Remark"].ToString();
                    String Expencedate = dt.Rows[i]["ExpenceDate"].ToString();
                    String createdDate = dt.Rows[i]["CreateDate"].ToString();
                    this.dataGridViewDeleteExpence.Rows.Add(id, type, Amount, PaymentType, remark, Expencedate, createdDate);
                }
            }
            catch (Exception ex)
            {
                dataGridViewDeleteExpence.Rows.Clear();
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            findExpences();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            findExpences();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewDeleteExpence.CurrentCell.RowIndex;
            String id = dataGridViewDeleteExpence.Rows[rowindex].Cells[0].Value.ToString();
            me.DeleteExpences(id);
            MessageBox.Show("Expences Record Successfully Deleted");
            findExpences();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxAmount.Clear();
            richTextBoxRemark.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            dataGridViewDeleteExpence.Rows.Clear();
        }


    }
}
