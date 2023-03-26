using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelFamilyAssign
    {
        private String familyId;
        private String memberId;
        private DataTable result;

        public void SelectAssignedFamilyMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("FamilyID", familyId);
            result = DBConnection.Select("SP_SelectAssignedFamilyMember", MemberPara);
        }

        public void SelectNotAssignedFamilyMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("FamilyID", familyId);
            result = DBConnection.Select("SP_SelectNotAssignedFamilyMember", MemberPara);
        }

        public void InsertFamilyMember()
        {
            Dictionary<string, object> AddMemberPara = new Dictionary<string, object>();
            AddMemberPara.Add("FamilyName", familyId);
            AddMemberPara.Add("Member", memberId);
            DBConnection.insert("SP_InsertFamilyMember", AddMemberPara);
        }

        public void DeleteFamilyMember()
        {
            Dictionary<string, object> MemberDeletPara = new Dictionary<string, object>();
            MemberDeletPara.Add("FamilyID", familyId);
            MemberDeletPara.Add("MemberID", memberId);
            DBConnection.insert("SP_DeleteFamilyMember", MemberDeletPara);
        }

        public String FamilyId
        {
            set { familyId = value; }
        }
        public String MemberId
        {
            set { memberId = value; }
        }
        public DataTable Result
        {
            get { return result; }
        }
    }
}
