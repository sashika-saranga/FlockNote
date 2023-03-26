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
    public partial class Expences_Type : Form
    {
        public Expences_Type()
        {
            InitializeComponent();
        }
        ControllerExpences ce = new ControllerExpences();

        public void loadInsertExpType()
        {
            dataGridViewAddExpences.Rows.Clear();
            String UnitName = textBoxAddExpences.Text;
            DataTable dt = ce.SearchExpencesType(UnitName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["id"].ToString();
                String name = dt.Rows[i]["type"].ToString();
                this.dataGridViewAddExpences.Rows.Add(id, name);
            }
        }

        public void loadEditExpType()
        {
            dataGridViewEdotExpences.Rows.Clear();

            String ExpType = textBoxSearchEditExpences.Text;
            DataTable dt = ce.SearchExpencesType(ExpType);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String id = dt.Rows[i]["id"].ToString();
                String type = dt.Rows[i]["type"].ToString();
                this.dataGridViewEdotExpences.Rows.Add(id, type);
            }

        }

        private void buttonAddExpences_Click(object sender, EventArgs e)
        {
            try
            {
                loadInsertExpType();
                String type = textBoxAddExpences.Text;
                ce.InsertExpType(type);
                MessageBox.Show("Expences Type Added");
                loadInsertExpType();
                loadEditExpType();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxAddExpences.Clear();

        }

        private void Expences_Type_Load(object sender, EventArgs e)
        {
            loadInsertExpType();
            loadEditExpType();
        }

        private void textBoxSearchEditExpences_TextChanged(object sender, EventArgs e)
        {
            loadEditExpType();
        }


        private void buttonEditExpences_Click(object sender, EventArgs e)
        {
            try
            {
                loadEditExpType();

                String id = labelExID.Text;
                String type = textBoxEditExpences.Text;
                ce.EditExpencesType(id, type);
                MessageBox.Show("Expences Type Successfully Updated");
                loadInsertExpType();
                loadEditExpType();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            textBoxEditExpences.Clear();

        }

        private void dataGridViewEdotExpences_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            labelExID.Text = dataGridViewEdotExpences.SelectedCells[0].Value.ToString();
            textBoxEditExpences.Text = dataGridViewEdotExpences.SelectedCells[1].Value.ToString();
        }
    }
}
