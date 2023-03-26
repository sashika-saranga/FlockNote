using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerMember
    {
        ModelMember mm = new ModelMember();

        public String InsertMember(String title, String fname, String lname, String gender, String address, String city, String mobile, String phone, String email, String occupation, String baptized, String bapdate,  String dob, String marriedstatus, String marrieddate, String active, String user, String imagepath)
        {
            mm.Title = title;
            mm.Fname = fname;
            mm.Lname = lname;
            mm.Address = address;
            mm.City = city;
            mm.Mobile = mobile;
            mm.User = user;
            mm.Phone = phone;
            mm.Gender = gender;
            mm.Bapdate = bapdate;
            mm.Baptized = baptized;
            mm.Email = email;
            mm.Dob = dob;
            mm.Occupation = occupation;
            mm.Marriedstatus = marriedstatus;
            mm.Marrieddate = marrieddate;
            mm.Active = active;
            mm.Imagepath = imagepath;
            mm.InsertMember();
            return mm.Msg;
        }

        public DataTable SearchMember(String MemberPara)
        {
            mm.Fname = MemberPara;
            mm.SearchMember();
            return mm.Result;
        }

        public String UpdateMember(String id, String title, String fname, String lname, String gender, String address, String city, String mobile, String phone, String email, String occupation, String baptized, String bapdate, String dob, String marriedstatus, String marrieddate, String active, String inactivereason, String user, String imagepath)
        {
            mm.Id = id;
            mm.Title = title;
            mm.Fname = fname;
            mm.Lname = lname;
            mm.Address = address;
            mm.City = city;
            mm.Mobile = mobile;
            mm.User = user;
            mm.Phone = phone;
            mm.Gender = gender;
            mm.Bapdate = bapdate;
            mm.Baptized = baptized;
            mm.Email = email;
            mm.Dob = dob;
            mm.Occupation = occupation;
            mm.Marriedstatus = marriedstatus;
            mm.Marrieddate = marrieddate;
            mm.Active = active;
            mm.Inactde = inactivereason;
            mm.Imagepath = imagepath;
            mm.UpdateMember();
            return mm.Msg;
        }

        public void DeleteMember(String id)
        {
            mm.Id = id;
            mm.DeleteMember();
        }
    }
}
