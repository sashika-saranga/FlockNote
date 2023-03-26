using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelFamily
    {
        private String familyid;
        private String familyName;
        private String address;
        private String active;
        private DataTable reuslts;

        public void SearchFamily()
        {
            Dictionary<string, object> FamilyNamePara = new Dictionary<string, object>();
            FamilyNamePara.Add("FamilyName", familyName);
            reuslts = DBConnection.Select("SP_SearchFamily", FamilyNamePara);
        }

        public void InsertFamily()
        {
            Dictionary<string, object> AddFamilyPara = new Dictionary<string, object>();
            AddFamilyPara.Add("FamilyName", familyName);
            AddFamilyPara.Add("Address", address);
            AddFamilyPara.Add("Active", active);
            DBConnection.insert("SP_InsertFamily", AddFamilyPara);
        }

        public void UpdateFamily()
        {
            Dictionary<string, object> UpdateFamilyPara = new Dictionary<string, object>();
            UpdateFamilyPara.Add("FamilyID", familyid);
            UpdateFamilyPara.Add("FamilyName", familyName);
            UpdateFamilyPara.Add("Address", address);
            UpdateFamilyPara.Add("Active", active);
            DBConnection.insert("SP_UpdateFamily", UpdateFamilyPara);
        }

        public String Familyid
        {
            set { familyid = value; }
        }

        public String FamilyName
        {
            set { familyName = value; }
        }


        public String Active
        {
            set { active = value; }
        }


        public DataTable Reuslts
        {
            get { return reuslts; }
        }

        public String Address
        {
            set { address = value; }
        }

    }
}
