using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;
using System.IO;

namespace FlockNote.Model
{
    class ModelMember
    {
        private String id;
        private String title;
        private String fname;
        private String lname;
        private String address;
        private String city;
        private String mobile;
        private String phone;
        private String gender;
        private String baptized;
        private String bapdate;
        private String email;
        private String user;
        private String active;
        private String dob;
        private String marriedstatus;
        private String marrieddate;
        private String occupation;
        private String msg;
        private String inactde;
        private String imagepath;
        private DataTable result;


        public String InsertMember()
        {
            try
            {
                String folderPath = Path.Combine(Environment.CurrentDirectory, @"Images");
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception ex)
                {}
                String memberID = this.SelectLastMember().ToString();
                String newImagePath = Path.Combine(Environment.CurrentDirectory, @"Images\", memberID+".jpg");
                System.IO.File.Copy(imagepath, newImagePath);

                Dictionary<string, object> AddMemberPara = new Dictionary<string, object>();
                AddMemberPara.Add("title", title);
                AddMemberPara.Add("fname", fname);
                AddMemberPara.Add("lname", lname);
                AddMemberPara.Add("remark", address);
                AddMemberPara.Add("city", city);
                AddMemberPara.Add("mobile", mobile);
                AddMemberPara.Add("phone", phone);
                AddMemberPara.Add("gender", gender);
                AddMemberPara.Add("baptized", baptized);
                AddMemberPara.Add("bapdate", bapdate);
                AddMemberPara.Add("email", email);
                AddMemberPara.Add("dob", dob);
                AddMemberPara.Add("marriedstatus", marriedstatus);
                AddMemberPara.Add("marrieddate", marrieddate);
                AddMemberPara.Add("Active", active);
                AddMemberPara.Add("occupation", occupation);
                AddMemberPara.Add("User", user);
                AddMemberPara.Add("ImagePath", newImagePath);
                DBConnection.insert("SP_InsertMember", AddMemberPara);
                msg = "Member inserted successfully";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE KEY"))
                    msg = "Duplicate! Member already avaliable";
                else
                    //msg = ex.ToString();
                    msg = "Member insert error";
            }
            return msg;
        }

        public void SearchMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("FirstName", fname);
            result = DBConnection.Select("SP_SearchMember", MemberPara);
        }

        private int SelectLastMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            result = DBConnection.Select("SP_SelectLastMember", MemberPara);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["MemberID"].ToString())+1;
            }
            else
                return 1;
        }

        public String UpdateMember()
        {
            try
            {
                String newImagePath = Path.Combine(Environment.CurrentDirectory, @"Images\", id + ".jpg");
                System.IO.File.Delete(newImagePath);
                System.IO.File.Copy(imagepath, newImagePath);

                Dictionary<string, object> UpdateMemberPara = new Dictionary<string, object>();
                UpdateMemberPara.Add("id", id);
                UpdateMemberPara.Add("title", title);
                UpdateMemberPara.Add("fname", fname);
                UpdateMemberPara.Add("lname", lname);
                UpdateMemberPara.Add("address", address);
                UpdateMemberPara.Add("city", city);
                UpdateMemberPara.Add("mobile", mobile);
                UpdateMemberPara.Add("phone", phone);
                UpdateMemberPara.Add("gender", gender);
                UpdateMemberPara.Add("baptized", baptized);
                UpdateMemberPara.Add("bapdate", bapdate);
                UpdateMemberPara.Add("email", email);
                UpdateMemberPara.Add("dob", dob);
                UpdateMemberPara.Add("marriedstatus", marriedstatus);
                UpdateMemberPara.Add("marrieddate", marrieddate);
                UpdateMemberPara.Add("Active", active);
                UpdateMemberPara.Add("InactiveDetails", inactde);
                //UpdateMemberPara.Add("image", imagepath);
                UpdateMemberPara.Add("occupation", occupation);
                UpdateMemberPara.Add("User", user);
                DBConnection.insert("SP_UpdateMember", UpdateMemberPara);
                msg = "Member Updated successfully";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE KEY"))
                    msg = "Duplicated, Member id already avaliable";
                else
                    msg = ex.ToString();
                //messege = "Group Name insert error";
            }
            return msg;
        }

        public void DeleteMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("id", id);
            DBConnection.insert("SP_DeleteMember", MemberPara);
        }


        public String Id
        {
            set { id = value; }
        }
        public String Dob
        {
            set { dob = value; }
        }

        public String Marriedstatus
        {
            set { marriedstatus = value; }
        }
        
        public String Marrieddate
        {
            set { marrieddate = value; }
        }
        

        public String Occupation
        {
            set { occupation = value; }
        }

        public String Active
        {
            set { active = value; }
        }
        
        public String Title
        {
            set { title = value; }
        }
        public String Fname
        {
            set { fname = value; }
        }
        public String Lname
        {
            set { lname = value; }
        }
        public String User
        {
            set { user = value; }
        }
        public String Address
        {
            set { address = value; }
        }
        public String City
        {
            set { city = value; }
        }
        public String Mobile
        {
            set { mobile = value; }
        }
        public String Phone
        {
            set { phone = value; }
        }
        public String Gender
        {
            set { gender = value; }
        }
        public String Baptized
        {
            set { baptized = value; }
        }
        public String Bapdate
        {
            set { bapdate = value; }
        }
        public String Email
        {
            set { email = value; }
        }
        public String Msg
        {
            get { return msg; }
        }

        public DataTable Result
        {
            get { return result; }
        }

        public String Inactde
        {
            set { inactde = value; }
        }

        public String Imagepath
        {
            set { imagepath = value; }
        }
    }
}
