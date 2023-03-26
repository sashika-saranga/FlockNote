using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelGivings
    {
        private String id;
        private String givingid;
        private String fname;
        private String givingtype;
        private String amount;
        private String remark;
        private String paytype;
        private DataTable result;
        private String messege;
        private String user;

        public void SearchMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("FirstName", fname);
            result = DBConnection.Select("SP_SearchMember", MemberPara);
        }

        public void SearchGivingTypes()
        {
            Dictionary<string, object> GivingPara = new Dictionary<string, object>();
            GivingPara.Add("Giving", givingtype);
            result = DBConnection.Select("SP_SearchGivingType", GivingPara);
        }

        public void InsertGivingDetails()
        {
            try
            {
                Dictionary<string, object> AddGivingPara = new Dictionary<string, object>();
                AddGivingPara.Add("givingID", givingid);
                AddGivingPara.Add("Amount", amount);
                AddGivingPara.Add("Remark", remark);
                DBConnection.insert("SP_InsertGivingDetails", AddGivingPara);
            }
            catch (Exception ex)
            {
 
            }

        }

        public String InsertGivingHeader()
        {
            try
            {
                Dictionary<string, object> AddGivingPara = new Dictionary<string, object>();
                AddGivingPara.Add("memberID", id);
                AddGivingPara.Add("Amount", amount);
                AddGivingPara.Add("PayType", paytype);
                AddGivingPara.Add("User", user);
                DBConnection.insert("SP_InsertGivingHeader", AddGivingPara);
                messege = " Record inserted successfully";
            }
            catch (Exception ex)
            {
                messege = ex.ToString();
            }
            return messege;
        }


        public String Fname
        {
            set { fname = value; }
        }

        public String Id
        {
            set { id = value; }
        }
        public DataTable Result
        {
            get { return result; }
        }

        public String Givingtype
        {
            set { givingtype = value; }
        }

        public String Messege
        {
            get { return messege; }
        }

        public String Givingid
        {
            set { givingid = value; }
        }

        public String Amount
        {
            set { amount = value; }
        }

        public String Remark
        {
            set { remark = value; }
        }

        public String User
        {
            set { user = value; }
        }

        public String Paytype
        {
            set { paytype = value; }
        }
    }
}
