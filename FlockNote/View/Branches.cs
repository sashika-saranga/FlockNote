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
    public partial class Branches : Form
    {
        public Branches()
        {
            InitializeComponent();
        }

        ControllerBranches cb = new ControllerBranches();

        public void loadSearchBranches()
        {
            dataGridViewSearchBranch.Rows.Clear();
            String BranchName = textBoxSearchBranch.Text;
            DataTable dt = cb.SearchBranches(BranchName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String branchid = dt.Rows[i]["BranchID"].ToString();
                String branchname = dt.Rows[i]["BranchName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String phone = dt.Rows[i]["Phone"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewSearchBranch.Rows.Add(branchid, branchname, address, phone, active, date);
            }
        }

        public void loadInsertBranch()
        {
            dataGridViewAddBranch.Rows.Clear();
            String BranchName = textBoxAddBranchName.Text;
            DataTable dt = cb.SearchBranches(BranchName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String branchid = dt.Rows[i]["BranchID"].ToString();
                String branchname = dt.Rows[i]["BranchName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String phone = dt.Rows[i]["Phone"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewAddBranch.Rows.Add(branchid, branchname, address, phone, active, date);
            }
        }

        public void loadUpdateBranch()
        {
            dataGridViewUpdateBranch.Rows.Clear();

            String BranchName = textBoxUpdateSearchBranch.Text;
            DataTable dt = cb.SearchBranches(BranchName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String branchid = dt.Rows[i]["BranchID"].ToString();
                String branchname = dt.Rows[i]["BranchName"].ToString();
                String address = dt.Rows[i]["Address"].ToString();
                String phone = dt.Rows[i]["Phone"].ToString();
                String active = dt.Rows[i]["Active"].ToString();
                String date = dt.Rows[i]["updatedate"].ToString();
                this.dataGridViewUpdateBranch.Rows.Add(branchid, branchname, address, phone, active, date);
            }
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            loadSearchBranches();
            loadInsertBranch();
            loadUpdateBranch();
        }

        private void textBoxSearchBranch_TextChanged(object sender, EventArgs e)
        {
            loadSearchBranches();
        }

        private void buttonBranchSave_Click(object sender, EventArgs e)
        {
            try
            {
                loadInsertBranch();
                String BranchName = textBoxAddBranchName.Text;
                String Address = richTextBoxBranchAddress.Text;
                String Phone = textBoxAddBranchContactNo.Text;
                String Active = checkBoxAddBranchActive.Checked.ToString();
                cb.InsertBranch(BranchName, Address, Phone, Active);
                MessageBox.Show("Branch Name Added Succsessfully");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxAddBranchName.Clear();
            textBoxAddBranchContactNo.Clear();
            richTextBoxBranchAddress.Clear();
            checkBoxAddBranchActive.Checked = false;
            loadSearchBranches();
            loadInsertBranch();
            loadUpdateBranch();
        }

        private void buttonUpdateBranchSave_Click(object sender, EventArgs e)
        {
            try
            {
                loadUpdateBranch();
                String branchid = labelUpdateBranchID.Text;
                String branchName = textBoxUpdateBranch.Text;
                String address = richTextBoxUpdateBranchAddress.Text;
                String phone = textBoxUpdateContactNo.Text;
                String active = checkBoxUpdateBranch.Checked.ToString();
                cb.UpdateBranch(branchid, branchName, address, phone, active);
                MessageBox.Show("Branch Name has been Updated");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxUpdateSearchBranch.Clear();
            textBoxUpdateBranch.Clear();
            richTextBoxUpdateBranchAddress.Clear();
            textBoxUpdateContactNo.Clear();
            checkBoxUpdateBranch.Checked = false;
            loadSearchBranches();
            loadInsertBranch();
            loadUpdateBranch();
        }

        private void dataGridViewUpdateBranch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelUpdateBranchID.Text = dataGridViewUpdateBranch.SelectedCells[0].Value.ToString();
            textBoxUpdateBranch.Text = dataGridViewUpdateBranch.SelectedCells[1].Value.ToString();
            richTextBoxUpdateBranchAddress.Text = dataGridViewUpdateBranch.SelectedCells[2].Value.ToString();
            textBoxUpdateContactNo.Text = dataGridViewUpdateBranch.SelectedCells[3].Value.ToString();
            checkBoxUpdateBranch.Checked = Convert.ToBoolean(dataGridViewUpdateBranch.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void textBoxUpdateSearchBranch_TextChanged(object sender, EventArgs e)
        {
            loadUpdateBranch();
        }

        private void buttonUpdateBranchCancel_Click(object sender, EventArgs e)
        {
            textBoxUpdateSearchBranch.Clear();
            textBoxUpdateBranch.Clear();
            richTextBoxUpdateBranchAddress.Clear();
            textBoxUpdateContactNo.Clear();
            checkBoxUpdateBranch.Checked = false;
        }

        private void buttonBranchFamilyCancel_Click(object sender, EventArgs e)
        {
            textBoxAddBranchName.Clear();
            textBoxAddBranchContactNo.Clear();
            richTextBoxBranchAddress.Clear();
            checkBoxAddBranchActive.Checked = false;
        }
    }
}
