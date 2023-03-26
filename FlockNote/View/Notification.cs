using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlockNote.View;
using FlockNote.Control;

namespace FlockNote
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
        }

        ControllerNotifications cn = new ControllerNotifications();

        private void Notification_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.ControlBox = false;
            loadBirthdayNotfications();
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.Transparent;

        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        public void loadBirthdayNotfications()
        {
            int rowCount = 0;
            String color;
            dataGridViewNotification.Rows.Clear();
            DataTable dt = cn.SelectBirthdayNotification();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rowCount = dataGridViewNotification.Rows.Count;
                String fname = dt.Rows[i]["FirstName"].ToString();
                String lname = dt.Rows[i]["LastName"].ToString();
                String bday = dt.Rows[i]["DOB"].ToString();
                String mobile = dt.Rows[i]["Mobile"].ToString();
                String today = dt.Rows[i]["today"].ToString();
                String remDates = dt.Rows[i]["RemDays"].ToString();
                this.dataGridViewNotification.Rows.Add(fname+" "+lname+" "+"'s B'Day at "+bday+" in "+remDates+" Days. "+"TP: "+mobile);
                if (Int32.Parse(remDates) > 0)
                {
                    dataGridViewNotification.Rows[rowCount].DefaultCellStyle.ForeColor = Color.Orange;
                }
                else if (Int32.Parse(remDates) < 0)
                {
                    dataGridViewNotification.Rows[rowCount].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dataGridViewNotification.Rows[rowCount].DefaultCellStyle.ForeColor = Color.Green;
                }
                
            }
        }
    }
}
