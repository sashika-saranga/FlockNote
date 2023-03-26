using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.Control;
using SQLDB;

namespace FlockNote.View
{
    public partial class Vehicles : Form
    {
        public Vehicles()
        {
            InitializeComponent();
        }

        ControllerVehicles cv = new ControllerVehicles();
        ControllerMiscellaneous cm = new ControllerMiscellaneous();

        private void Vehicles_Load(object sender, EventArgs e)
        {
            loadAddVehicleDetails();
            loadAddVehicleViewDetails();
            loadUpdateVehicleDetails();

            DataTable dtGetCat1 = cm.SelectVehicleBrand();
            comboBoxAddVehicleBrand.DataSource = dtGetCat1;
            comboBoxAddVehicleBrand.DisplayMember = "Brand";
            comboBoxAddVehicleBrand.ValueMember = "BrandId";
            comboBoxAddVehicleBrand.SelectedIndex = -1;

            DataTable dtGetCat2 = cm.SelectVehicleType();
            comboBoxAddVehicleType.DataSource = dtGetCat2;
            comboBoxAddVehicleType.DisplayMember = "VehicleType";
            comboBoxAddVehicleType.ValueMember = "TypeID";
            comboBoxAddVehicleType.SelectedIndex = -1;

            DataTable dtGetCat3 = cm.SelectVehicleBrand();
            comboBoxUpdateVehicleBrand.DataSource = dtGetCat3;
            comboBoxUpdateVehicleBrand.DisplayMember = "Brand";
            comboBoxUpdateVehicleBrand.ValueMember = "BrandId";
            comboBoxUpdateVehicleBrand.SelectedIndex = -1;

            DataTable dtGetCat4 = cm.SelectVehicleType();
            comboBoxUpdateVehicleType.DataSource = dtGetCat4;
            comboBoxUpdateVehicleType.DisplayMember = "VehicleType";
            comboBoxUpdateVehicleType.ValueMember = "TypeID";
            comboBoxUpdateVehicleType.SelectedIndex = -1;
        }

        public void loadAddVehicleDetails()
        {
            dataGridViewAddVehicle.Rows.Clear();
            DataTable dt = cv.SelectVehicles();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["VehicleID"].ToString();
                String Vnumber = dt.Rows[i]["RegNo"].ToString();
                String Vmodel = dt.Rows[i]["Model"].ToString();
                String Vbrand = dt.Rows[i]["Brand"].ToString();
                String Vtpye = dt.Rows[i]["Type"].ToString();
                String Active = dt.Rows[i]["Active"].ToString();
                this.dataGridViewAddVehicle.Rows.Add(id, Vnumber, Vmodel, Vbrand, Vtpye, Active);
            }
        }

        public void loadAddVehicleViewDetails()
        {
            dataGridViewSearchVehicleOnfo.Rows.Clear();
            DataTable dt = cv.SelectVehicles();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["VehicleID"].ToString();
                String Vnumber = dt.Rows[i]["RegNo"].ToString();
                String Vmodel = dt.Rows[i]["Model"].ToString();
                String Vbrand = dt.Rows[i]["Brand"].ToString();
                String Vtpye = dt.Rows[i]["Type"].ToString();
                String Active = dt.Rows[i]["Active"].ToString();
                this.dataGridViewSearchVehicleOnfo.Rows.Add(id, Vnumber, Vmodel, Vbrand, Vtpye, Active);
            }
        }

        public void loadUpdateVehicleDetails()
        {
            dataGridViewUpdateVehicle.Rows.Clear();
            DataTable dt = cv.SelectVehicles();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["VehicleID"].ToString();
                String Vnumber = dt.Rows[i]["RegNo"].ToString();
                String Vmodel = dt.Rows[i]["Model"].ToString();
                String Vbrand = dt.Rows[i]["Brand"].ToString();
                String Vtpye = dt.Rows[i]["Type"].ToString();
                String Active = dt.Rows[i]["Active"].ToString();
                this.dataGridViewUpdateVehicle.Rows.Add(id, Vnumber, Vmodel, Vbrand, Vtpye, Active);
            }
        }

        private void buttonAddVehicleSave_Click(object sender, EventArgs e)
        {
            try
            {

                String Vnumber = textBoxAddVehicleNum.Text;
                String Vmodel = textBoxAddVehicleModel.Text;
                String Vbrand = comboBoxAddVehicleBrand.Text.ToString();
                String Vtpye = comboBoxAddVehicleType.Text.ToString();
                String Active = checkBoxAddVehicleActive.Checked.ToString();
                cv.InsertVehicles(Vnumber, Vmodel, Vbrand, Vtpye, Active);
                MessageBox.Show("Vehicle Added Successfully");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            loadAddVehicleDetails();
            loadAddVehicleViewDetails();
            loadUpdateVehicleDetails();
            textBoxAddVehicleNum.Clear();
            textBoxAddVehicleModel.Clear();
            comboBoxAddVehicleBrand.SelectedIndex = -1;
            comboBoxAddVehicleType.SelectedIndex = -1;
        }

        private void dataGridViewUpdateVehicle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelUpdateVehicleID.Text = dataGridViewUpdateVehicle.SelectedCells[0].Value.ToString();
            textBoxUpdateVehicleNum.Text = dataGridViewUpdateVehicle.SelectedCells[1].Value.ToString();
            textBoxUpdateVehicleModel.Text = dataGridViewUpdateVehicle.SelectedCells[2].Value.ToString();
            comboBoxUpdateVehicleBrand.Text = dataGridViewUpdateVehicle.SelectedCells[3].Value.ToString();
            comboBoxUpdateVehicleType.Text = dataGridViewUpdateVehicle.SelectedCells[4].Value.ToString();
            checkBoxUpdateVehicleActive.Checked = Convert.ToBoolean(dataGridViewUpdateVehicle.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        private void textBoxSearchVehicleInfo_TextChanged(object sender, EventArgs e)
        {
            loadAddVehicleViewDetails();
        }

        private void textBoxUpdateSearch_TextChanged(object sender, EventArgs e)
        {
            loadUpdateVehicleDetails();
        }

        private void buttonUpdateVehicleSave_Click(object sender, EventArgs e)
        {
            try
            {
                loadUpdateVehicleDetails();
                String vid = labelUpdateVehicleID.Text;
                String vNum = textBoxUpdateVehicleNum.Text;
                String vmodel = textBoxUpdateVehicleModel.Text;
                String vbrand = comboBoxUpdateVehicleBrand.Text;
                String vtype = comboBoxUpdateVehicleType.Text;
                String active = checkBoxUpdateVehicleActive.Checked.ToString();
                cv.UpdateVehicle(vid, vNum, vmodel, vbrand, vtype, active);
                MessageBox.Show("Vehicle details has been Updated");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxUpdateVehicleNum.Clear();
            textBoxUpdateVehicleModel.Clear();
            comboBoxUpdateVehicleBrand.SelectedIndex = -1;
            comboBoxUpdateVehicleType.SelectedIndex = -1;
            checkBoxUpdateVehicleActive.Checked = false;
            loadAddVehicleDetails();
            loadAddVehicleViewDetails();
            loadUpdateVehicleDetails();
        }
    }
}
