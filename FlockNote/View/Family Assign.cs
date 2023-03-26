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
    public partial class Family_Assign : Form
    {
        public Family_Assign()
        {
            InitializeComponent();
        }

        ControllerFamily cf = new ControllerFamily();
        ControllerFamilyAssign cfa = new ControllerFamilyAssign();

        private void Family_Assign_Load(object sender, EventArgs e)
        {
            String FamilyName = "";
            DataTable dtGetCat = cf.SearchFamily(FamilyName);
            comboBoxSelectFamilyName.DataSource = dtGetCat;
            comboBoxSelectFamilyName.DisplayMember = "FamilyName";
            comboBoxSelectFamilyName.ValueMember = "HouseID";
            comboBoxSelectFamilyName.SelectedIndex = -1;
        }

        private void loadFamilyMemberAssign()
        {
            dataGridViewFamilyMembers.Rows.Clear();
            try
            {
                String family = comboBoxSelectFamilyName.SelectedValue.ToString();
                DataTable dt = cfa.SelectAssignedFamilyMember(family);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String memberid = dt.Rows[i]["MemberID"].ToString();
                    String memberName = dt.Rows[i]["fullName"].ToString();
                    this.dataGridViewFamilyMembers.Rows.Add(memberid, memberName, "Remove");
                }

                DataTable dt2 = cfa.SelectNotAssignedFamilyMember(family);
                comboBoxSelectMemberName.DataSource = dt2;
                comboBoxSelectMemberName.DisplayMember = "fullName";
                comboBoxSelectMemberName.ValueMember = "MemberID";
                comboBoxSelectMemberName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
            }
        }

        private void buttonAddFamilyMemberAssign_Click(object sender, EventArgs e)
        {
            String family = comboBoxSelectFamilyName.SelectedValue.ToString();
            String member = comboBoxSelectMemberName.SelectedValue.ToString();
            cfa.InsertFamilyMember(family, member);
            loadFamilyMemberAssign();
        }

        private void comboBoxSelectFamilyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFamilyMemberAssign();
        }

        private void dataGridViewFamilyMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                String memberid = dataGridViewFamilyMembers.SelectedCells[0].Value.ToString();
                String name = dataGridViewFamilyMembers.SelectedCells[1].Value.ToString();
                String familyid = comboBoxSelectFamilyName.SelectedValue.ToString();
                DialogResult res = MessageBox.Show("Do you want to delete " + name + " ?", "Delete Member?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    cfa.DeleteFamilyMember(familyid, memberid);
                    loadFamilyMemberAssign();
                }
            }
        }
    }
}
