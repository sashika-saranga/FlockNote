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
    public partial class Vehicle_Information : Form
    {
        public Vehicle_Information()
        {
            InitializeComponent();
        }

        ControllerVehicles cv = new ControllerVehicles();

        private void Vehicle_Information_Load(object sender, EventArgs e)
        {
            DataTable dt = cv.SelectVehicles();
            comboBoxSelectVehicle.DataSource = dt;
            comboBoxSelectVehicle.DisplayMember = "RegNo";
            comboBoxSelectVehicle.ValueMember = "VehicleID";
            comboBoxSelectVehicle.SelectedIndex = -1;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            String vid = comboBoxSelectVehicle.SelectedValue.ToString();
            String reneDate = dateTimePickerRenewDate.Value.ToString();
            String amount = textBoxAmount.Text;
            String user = "1";
            if (radioButtonLicense.Checked == true)
            {
                cv.InsertLicense(vid, reneDate, amount, user);
                MessageBox.Show("Licese Details Added Succsessfully");
            }
            else
            {
                cv.InsertInsuarance(vid, reneDate, amount, user);
                MessageBox.Show("Insuarance Details Added Succsessfully");
            }

            clearVehicleInfo();
        }

        private void radioButtonLicense_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonLicense.Checked == true)
                {
                    clearVehicleInfo();
                    String vid = comboBoxSelectVehicle.SelectedValue.ToString();
                    DataTable dt = cv.SelectLicenseDetails(vid);
                    dateTimePickerExpirydate.Text = dt.Rows[0]["expDate"].ToString();
                    labelRemainingDate.Text = dt.Rows[0]["remDays"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No record");
            }

        }

        private void radioButtonInsurance_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonInsurance.Checked == true)
                {
                    clearVehicleInfo();
                    String vid = comboBoxSelectVehicle.SelectedValue.ToString();
                    DataTable dt = cv.SelectInsuaranceDetails(vid);
                    dateTimePickerExpirydate.Text = dt.Rows[0]["expDate"].ToString();
                    labelRemainingDate.Text = dt.Rows[0]["remDays"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No record");
            }
        }

        public void clearVehicleInfo()
        {
            labelRemainingDate.Text="";
            dateTimePickerExpirydate.ResetText();
            textBoxAmount.Clear();
            dateTimePickerRenewDate.ResetText();
        }

        private void comboBoxSelectVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearVehicleInfo();
            radioButtonLicense.Checked = false;
            radioButtonInsurance.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            clearVehicleInfo();
        }

        
    }
}
