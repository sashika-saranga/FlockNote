using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDB;
using System.Data;

namespace FlockNote.Model
{
    class ModelBranches
    {
        private String branchid;
        private String branchName;
        private String address;
        private String phone;
        private String active;
        private DataTable reuslts;

        public void SearchBranches()
        {
            Dictionary<string, object> BranchPara = new Dictionary<string, object>();
            BranchPara.Add("BranchName", branchName);
            reuslts = DBConnection.Select("SP_SearchBranches", BranchPara);
        }

        public void InsertBranch()
        {
            Dictionary<string, object> Addbranch = new Dictionary<string, object>();
            Addbranch.Add("BranchName", branchName);
            Addbranch.Add("Address", address);
            Addbranch.Add("Phone", phone);
            Addbranch.Add("Active", active);
            DBConnection.insert("SP_InsertBranch", Addbranch);
        }

         public void UpdateBranch()
        {
            Dictionary<string, object> Addbranch = new Dictionary<string, object>();
            Addbranch.Add("BranchID", branchid);
            Addbranch.Add("BranchName", branchName);
            Addbranch.Add("Address", address);
            Addbranch.Add("Phone", phone);
            Addbranch.Add("Active", active);
            DBConnection.insert("SP_UpdateBranch", Addbranch);
        }

        public String Branchid
        {
            set { branchid = value; }
        }

        public String BranchName
        {
            set { branchName = value; }
        }

        public String Address
        {
            set { address = value; }
        }

        public String Phone
        {
            set { phone = value; }
        }

        public String Active
        {
            set { active = value; }
        }

        public DataTable Reuslts
        {
            get { return reuslts; }
        }
    }
}
