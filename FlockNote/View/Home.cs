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
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;
namespace FlockNote
{
    public partial class Home : Form
    {
        String username;
        String userId;
        public Home(String UserName, String UserID)
        {
            this.username = UserName;
            this.userId = UserID;
            InitializeComponent();
        }

        ControllerMember cm = new ControllerMember();
        ControllerHome ch = new ControllerHome();
        ControllerUser cu = new ControllerUser();

        private void Home_Load(object sender, EventArgs e)
        {
            reloadMember("");
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1.0)
            };
            timer.Tick += (o, e1) =>
            {
                setTime();
            };
            timer.Start();

            permissionControl();
            //pictureBoxviewMember.ImageLocation = "Images/27.jp";
        }

        private void setTime()
        {
            labelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        public void permissionControl()
        {
            DataTable dt = cu.SelectUserPermission(userId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String permission = dt.Rows[i]["permissionID"].ToString();
                bool state = (Boolean)dt.Rows[i]["state"];
                switch (permission)
                {
                    case "M11":
                        if (!state)
                            addMemberToolStripMenuItem.Visible = false;
                        break;
                    case "M12":
                        if (!state)
                            groupsToolStripMenuItem.Visible = false;
                        break;
                    case "M13":
                        if (!state)
                            groupsToolStripMenuItem.Visible = false;
                        break;
                    case "M14":
                        if (!state)
                            familyNameToolStripMenuItem.Visible = false;
                        break;
                    case "M15":
                        if (!state)
                            vehiclesToolStripMenuItem1.Visible = false;
                        break;
                    case "M16":
                        if (!state)
                            expencesTypeToolStripMenuItem.Visible = false;
                        break;
                    case "M17":
                        if (!state)
                            branchesToolStripMenuItem.Visible = false;
                        break;
                    case "M18":
                        if (!state)
                            userToolStripMenuItem.Visible = false;
                        break;
                    case "M20":
                        if (!state)
                            reportsToolStripMenuItem.Visible = false;
                        break;
                    case "M21":
                        if (!state)
                            viewBirthDaysToolStripMenuItem.Visible = false;
                        break;
                    case "M22":
                        if (!state)
                            viewAllMembersToolStripMenuItem.Visible = false;
                        break;
                    case "M23":
                        if (!state)
                            viewCellGroupsToolStripMenuItem.Visible = false;
                        break;
                    case "M24":
                        if (!state)
                            viewGroupsToolStripMenuItem.Visible = false;
                        break;
                    case "M25":
                        if (!state)
                            viewInventoryInToolStripMenuItem.Visible = false;
                        break;
                    case "M26":
                        if (!state)
                            viewInventoryOutToolStripMenuItem.Visible = false;
                        break;
                    case "M27":
                        if (!state)
                            viewMembersAgeGroupToolStripMenuItem.Visible = false;
                        break;
                    case "M28":
                        if (!state)
                            viewMemberBaptismToolStripMenuItem.Visible = false;
                        break;
                    case "M29":
                        if (!state)
                            viewExpensesToolStripMenuItem.Visible = false;
                        break;
                    case "M30":
                        if (!state)
                            eventsToolStripMenuItem.Visible = false;
                        break;
                    case "M31":
                        if (!state)
                            addEventToolStripMenuItem.Visible = false;
                        break;
                    case "M32":
                        if (!state)
                            viewEventToolStripMenuItem.Visible = false;
                        break;
                    case "M40":
                        if (!state)
                            vehiclesToolStripMenuItem.Visible = false;
                        break;
                    case "M41":
                        if (!state)
                            vehicleInformationToolStripMenuItem.Visible = false;
                        break;
                    case "M50":
                        if (!state)
                            inventryToolStripMenuItem.Visible = false;
                        break;
                    case "M51":
                        if (!state)
                            inventryInToolStripMenuItem.Visible = false;
                        break;
                    case "M52":
                        if (!state)
                            inventryOutToolStripMenuItem.Visible = false;
                        break;
                    case "M60":
                        if (!state)
                            assignToolStripMenuItem.Visible = false;
                        break;
                    case "M61":
                        if (!state)
                            groupRoleToolStripMenuItem.Visible = false;
                        break;
                    case "M62":
                        if (!state)
                            familyAndMembersToolStripMenuItem.Visible = false;
                        break;
                    case "M63":
                        if (!state)
                            branchMembersToolStripMenuItem.Visible = false;
                        break;
                    case "M70":
                        if (!state)
                            givingsToolStripMenuItem.Visible = false;
                        break;
                    case "M71":
                        if (!state)
                            addGivingsToolStripMenuItem.Visible = false;
                        break;
                    case "M80":
                        if (!state)
                            attendanceToolStripMenuItem.Visible = false;
                        break;
                    case "M90":
                        if (!state)
                            deleteToolStripMenuItem.Visible = false;
                        break;
                    case "M100":
                        if (!state)
                            expencesToolStripMenuItem.Visible = false;
                        break;
                    case "M101":
                        if (!state)
                            addAndDeleteToolStripMenuItem.Visible = false;
                        break;
                }
            }

        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Member_Registration mr = new Member_Registration();
            mr.Show();
        }

        private void rolleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Role r = new Role();
            r.Show();
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Vehicles v = new Vehicles();
            //v.Show();
        }

        private void groupRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Member_Assign ma = new Member_Assign();
            ma.Show();
        }

        private void groupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group g = new Group();
            g.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
        }

        private void vehiclesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vehicles v = new Vehicles();
            v.Show();
        }

        private void familyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Family f = new Family();
            f.Show();
        }

        private void familyAndMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Family_Assign fa = new Family_Assign();
            fa.Show();
        }

        private void givingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void inventryInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventry_In ii = new Inventry_In();
            ii.Show();
        }

        private void inventryOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory_Out io = new Inventory_Out();
            io.Show();
        }

        private void vehicleInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehicle_Information vi = new Vehicle_Information();
            vi.Show();
        }

        private void addGivingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Givings g = new Givings();
            g.Show();
        }

        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Event ad = new Add_Event();
            ad.Show();
        }

       
        private void textBoxSearchMember_TextChanged(object sender, EventArgs e)
        {
            String searchpara = textBoxSearchMember.Text;
            reloadMember(searchpara);
        }

        public void reloadMember(String searchPara)
        {
            dataGridViewSearchMember.Rows.Clear();
            DataTable dt = cm.SearchMember(searchPara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String memberid = dt.Rows[i]["MemberID"].ToString();
                String title = dt.Rows[i]["Title"].ToString();
                String fname = dt.Rows[i]["FirstName"].ToString();
                String lname = dt.Rows[i]["LastName"].ToString();
                String city = dt.Rows[i]["City"].ToString();
                this.dataGridViewSearchMember.Rows.Add(memberid, title, fname, lname, city);
            }

        }

        private void dataGridViewSearchMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String imagePath="";
            if (e.RowIndex == -1) return;
            dataGridViewMemberGroups.Rows.Clear();
            String memberid = dataGridViewSearchMember.Rows[e.RowIndex].Cells[0].Value.ToString();
            DataTable dt = ch.SearchMemberRole(memberid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String group = dt.Rows[i]["Name"].ToString();
                String role = dt.Rows[i]["RoleName"].ToString();
                this.dataGridViewMemberGroups.Rows.Add(group, role);
            }

            DataTable dt2 = ch.SearchMemberAllDetails(memberid);

            labelTitle.Text = dt2.Rows[0]["Title"].ToString();
            labelFname.Text = dt2.Rows[0]["FirstName"].ToString();
            labelLname.Text = dt2.Rows[0]["LastName"].ToString();
            labelGender.Text = dt2.Rows[0]["Gender"].ToString();
            labelAddress.Text = dt2.Rows[0]["Address"].ToString();
            labelCity.Text = dt2.Rows[0]["City"].ToString();
            labelMobile.Text = dt2.Rows[0]["Mobile"].ToString();
            labelHphone.Text = dt2.Rows[0]["HomePhone"].ToString(); 
            labelBaptStatus.Text = dt2.Rows[0]["Baptism"].ToString();
            if (labelBaptStatus.Text.Equals("False"))
                labelBaptDate.Text = "N/A";
            else
                labelBaptDate.Text = dt2.Rows[0]["BaptizedDate"].ToString(); 
            labelEmail.Text = dt2.Rows[0]["Email"].ToString(); 
            labelDOB.Text = dt2.Rows[0]["DOB"].ToString(); 
            labelBaritalStaus.Text = dt2.Rows[0]["MaritalStatus"].ToString();
            if (labelBaritalStaus.Text.Equals("Unmarried"))
                labelMarriedDate.Text = "N/A";
            else
                labelMarriedDate.Text = dt2.Rows[0]["WeddingDate"].ToString();
            imagePath = dt2.Rows[0]["image"].ToString();
            labelOccupation.Text = dt2.Rows[0]["Occupation"].ToString(); 
            labelEnableStatus.Text = dt2.Rows[0]["Active"].ToString();
            labelCellGroup.Text = dt2.Rows[0]["CellGroup"].ToString();
            labelCellGroupRole.Text = dt2.Rows[0]["CellGroupRole"].ToString();
            labelFamily.Text = dt2.Rows[0]["FamilyName"].ToString();
            labelRemark.Text = dt2.Rows[0]["Remark"].ToString();
            labelAge.Text = dt2.Rows[0]["Age"].ToString();
            //pictureBoxviewMember.Image = new Bitmap(imagePath);
        }

        private void expencesTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expences_Type et = new Expences_Type();
            et.Show();
        }

        private void addAndDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expences ex = new Expences();
            ex.Show();
        }

        private void branchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branches b = new Branches();
            b.Show();
        }

        private void branchMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branch_Members bm = new Branch_Members();
            bm.Show();
        }

        private void viewBirthDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BirthDays bd = new BirthDays();
            bd.Show();
        }

        private void viewAllMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportMembers rm = new ReportMembers();
            rm.Show();
        }

        private void viewGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportGroups rg = new ReportGroups();
            rg.Show();
        }

        private void viewMembersAgeGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportAgeGroup ag = new ReportAgeGroup();
            ag.Show();
        }

        private void viewInventoryInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Inventory_In rin = new Report_Inventory_In();
            rin.Show();
        }

        private void viewMemberBaptismToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baptism b = new Baptism();
            b.Show();
        }

        private void viewExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportExpenses re = new ReportExpenses();
            re.Show();
        }

        private void viewCellGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportCellGroups cg = new ReportCellGroups();
            cg.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://eluci.tech/#page-top");
        }

        private void viewLeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportViewLeaders vl = new ReportViewLeaders();
            vl.Show();
        }

        //private Bitmap MyImage;
        //public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        //{
        //    // Sets up an image object to be displayed.
        //    if (MyImage != null)
        //    {
        //        MyImage.Dispose();
        //    }

        //    // Stretches the image to fit the pictureBox.
        //    pictureBoxviewMember.SizeMode = PictureBoxSizeMode.StretchImage;
        //    MyImage = new Bitmap(fileToDisplay);
        //    pictureBoxviewMember.ClientSize = new Size(xSize, ySize);
        //    pictureBoxviewMember.Image = (Images/27.jp)MyImage;
        //}
    }
}
