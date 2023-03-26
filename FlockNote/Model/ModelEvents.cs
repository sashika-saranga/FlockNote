using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDB;
using System.Data;

namespace FlockNote.Model
{
    class ModelEvents
    {
        private String id;
        private String organizor;
        private String description;
        private String date;
        private String user;
        private String mid;
        private String gid;
        private String msg;
        private DataTable result;

        public void InsertGroups()
        {
            try
            {
                Dictionary<string, object> AddPara = new Dictionary<string, object>();
                AddPara.Add("GroupID", gid);
                DBConnection.insert("SP_InsertEventGroups", AddPara);
            }
            catch (Exception ex)
            {

            }

        }

        public void InsertMembers()
        {
            try
            {
                Dictionary<string, object> AddPara = new Dictionary<string, object>();
                AddPara.Add("MemberID", mid);
                DBConnection.insert("SP_InsertEventMembers", AddPara);
            }
            catch (Exception ex)
            {

            }

        }

        public String InsertEventHeader()
        {
            try
            {
                Dictionary<string, object> AddPara = new Dictionary<string, object>();
                AddPara.Add("EventOrganizer", organizor);
                AddPara.Add("EventDescription", description);
                AddPara.Add("EventDate", date);
                AddPara.Add("User", user);
                DBConnection.insert("SP_InsertEventHeader", AddPara);
                msg = "Record Insert Succsessfully";

            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            return msg;
        }


        public String Id
        {
            set { id = value; }
        }

        public String Organizor
        {
            set { organizor = value; }
        }

        public String Description
        {
            set { description = value; }
        }

        public String Date
        {
            set { date = value; }
        }

        public String User
        {
            set { user = value; }
        }

        public String Mid
        {
            set { mid = value; }
        }

        public String Gid
        {
             set { gid = value; }
        }

        public DataTable Result
        {
            get { return result; }
        }

        public String Msg
        {
            get { return msg; }
        }
    }
}
