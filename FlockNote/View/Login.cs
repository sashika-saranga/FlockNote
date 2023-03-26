using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.View;
using SQLDB;

namespace FlockNote.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> user = new Dictionary<string, object>();
                user.Add("un", textBoxLoginUserName.Text);
                user.Add("pw", textBoxLoginPassword.Text);
                DataSet dt = DBConnection.Select("SP_SelectUser", user, 1);
                String username = dt.Tables[0].Rows[0]["username"].ToString();
                String userId = dt.Tables[0].Rows[0]["id"].ToString();


                    Dictionary<string, object> logPara = new Dictionary<string, object>();
                    logPara.Add("un", textBoxLoginUserName.Text);
                    DBConnection.insert("SP_InsertLoginRecord", logPara);

                    //Home h = new Home(username, userId);
                    Home h = new Home(username, userId);
                    h.Show();
                    this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect Login. Please Try Again!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLoginUserName.Clear();
                textBoxLoginPassword.Clear();
            }
            //Home h = new Home();
            //h.Show();
            //this.Hide();
        }
    }
}
