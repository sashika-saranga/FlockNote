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
    public partial class Family : Form
    {
        public Family()
        {
            InitializeComponent();
        }

        ControllerFamily cf = new ControllerFamily();

        public void loadSearchFamily()
        {
            dataGridViewSearchFamily.Rows.Clear();
            String FamilyName = textBoxSearchFamily.Text;
            DataTable dt = cf.SearchFamily(FamilyName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String familyid = dt.Rows[i]["HouseID"].ToString();
                String familyname = dt.Rows[i]["FamilyName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewSearchFamily.Rows.Add(familyid, familyname, address, active, date);
            }
        }

        public void loadInsertFamily()
        {
            dataGridViewAddFamily.Rows.Clear();
            String FamilyName = textBoxAddFamilyName.Text;
            DataTable dt = cf.SearchFamily(FamilyName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String familyid = dt.Rows[i]["HouseID"].ToString();
                String family = dt.Rows[i]["FamilyName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewAddFamily.Rows.Add(familyid, family, address, active, date);
            }
        }

        public void loadUpdateFamily()
        {
            dataGridViewUpdateFamily.Rows.Clear();

            String FamilyName = textBoxUpdateSearchFamily.Text;
            DataTable dt = cf.SearchFamily(FamilyName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String familyid = dt.Rows[i]["HouseID"].ToString();
                String familyName= dt.Rows[i]["FamilyName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewUpdateFamily.Rows.Add(familyid, familyName, address, active, date);
            }
        }

        private void Family_Load(object sender, EventArgs e)
        {
            loadSearchFamily();
            loadInsertFamily();
            loadUpdateFamily();
        }

        private void buttonFamilySave_Click(object sender, EventArgs e)
        {
         
            try
            {
                loadInsertFamily();
                String FamilyName = textBoxAddFamilyName.Text;
                String Address = richTextBoxFamilyAddress.Text;
                String Active = checkBoxAddFamilyActive.Checked.ToString();
                cf.InsertFamily(FamilyName, Address, Active);
                MessageBox.Show("Family Added Succsessfully");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxAddFamilyName.Clear();
            richTextBoxFamilyAddress.Clear();
            checkBoxAddFamilyActive.Checked = false;
            loadSearchFamily();
            loadInsertFamily();
            loadUpdateFamily();
        }

        private void buttonUpdateFamilySave_Click(object sender, EventArgs e)
        {
            
            try
            {
                loadUpdateFamily();
                String familyid = labelUpdateFamilyID.Text;
                String familyName = textBoxUpdateFamily.Text;
                String address = richTextBoxUpdateFamilyAddress.Text;
                String active = checkBoxUpdateFamily.Checked.ToString();
                cf.UpdateFamily(familyid, familyName, address, active);
                MessageBox.Show("Family Name has been Updated");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxUpdateSearchFamily.Clear();
            textBoxUpdateFamily.Clear();
            richTextBoxUpdateFamilyAddress.Clear();
            checkBoxUpdateFamily.Checked = false;
            loadUpdateFamily();
            loadSearchFamily();
            loadInsertFamily();
        }

        private void dataGridViewUpdateFamily_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelUpdateFamilyID.Text = dataGridViewUpdateFamily.SelectedCells[0].Value.ToString();
            textBoxUpdateFamily.Text = dataGridViewUpdateFamily.SelectedCells[1].Value.ToString();
            richTextBoxUpdateFamilyAddress.Text = dataGridViewUpdateFamily.SelectedCells[2].Value.ToString();
            checkBoxUpdateFamily.Checked = Convert.ToBoolean(dataGridViewUpdateFamily.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void textBoxUpdateSearchFamily_TextChanged(object sender, EventArgs e)
        {
            loadUpdateFamily();
        }

        private void textBoxSearchFamily_TextChanged(object sender, EventArgs e)
        {
            loadSearchFamily();
        }
    }
}
