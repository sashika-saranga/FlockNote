using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelHome
    {
        private String memberid;
        private DataTable result;

        public void SearchMemberRole()
        {
            Dictionary<string, object> Para = new Dictionary<string, object>();
            Para.Add("MemberID", memberid);
            result = DBConnection.Select("SP_SearchMemberRole", Para);
        }

        public void SearchMemberAllDetails()
        {
            Dictionary<string, object> Para = new Dictionary<string, object>();
            Para.Add("MemberID", memberid);
            result = DBConnection.Select("SP_SearchMemberAllDetails", Para);
        }
        public String Memberid
        {
            set { memberid = value; }
        }

        public DataTable Result
        {
            get { return result; }
        }
    }
}
