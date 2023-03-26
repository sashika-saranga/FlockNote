using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelBranchMember
    {
        private String branchid;
        private String memberid;
        private String roleid;
        private DataTable result;


        public void SelectAssignedBranchMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("BranchID", branchid);
            result = DBConnection.Select("SP_SelectAssignedBranchMember", MemberPara);
        }

        public void SelectNotAssignedBranchMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("BranchID", branchid);
            result = DBConnection.Select("SP_SelectNotAssignedBranchMember", MemberPara);
        }

        public void InsertBranchMember()
        {
            Dictionary<string, object> AddMemberPara = new Dictionary<string, object>();
            AddMemberPara.Add("BranchID", branchid);
            AddMemberPara.Add("MemberID", memberid);
            DBConnection.insert("SP_InsertBranchMember", AddMemberPara);
        }
        /// <summary>
        /// ///////////////
        /// </summary>
        public void SelectAssignedRoleMemberBranch()
        {
            Dictionary<string, object> MemberRolePara = new Dictionary<string, object>();
            MemberRolePara.Add("BranchID", branchid);
            MemberRolePara.Add("MemberID", memberid);
            result = DBConnection.Select("SP_SelectAssignedRoleMemberBranch", MemberRolePara);
        }

        public void SelectNotAssignedRoleMemberBranch()
        {
            Dictionary<string, object> MemberRolePara = new Dictionary<string, object>();
            MemberRolePara.Add("BranchID", branchid);
            MemberRolePara.Add("MemberID", memberid);
            result = DBConnection.Select("SP_SelectNotAssignedRoleMemberBranch", MemberRolePara);
        }

        public void InsertBranchMemberRole()
        {
            Dictionary<string, object> AddMemberRolePara = new Dictionary<string, object>();
            AddMemberRolePara.Add("Branch", branchid);
            AddMemberRolePara.Add("Member", memberid);
            AddMemberRolePara.Add("Role", roleid);
            DBConnection.insert("SP_InsertBranchMemberRole", AddMemberRolePara);
        }

        public void DeleteBranchMember()
        {
            Dictionary<string, object> MemberDeletPara = new Dictionary<string, object>();
            MemberDeletPara.Add("MemberID", memberid);
            MemberDeletPara.Add("BranchID", branchid);
            DBConnection.insert("SP_DeleteBranchMember", MemberDeletPara);
        }

        public void DeleteBranchMemberRole()
        {
            Dictionary<string, object> MemberRoleDeletePara = new Dictionary<string, object>();
            MemberRoleDeletePara.Add("MemberID", memberid);
            MemberRoleDeletePara.Add("BranchID", branchid);
            MemberRoleDeletePara.Add("RoleID", roleid);
            DBConnection.insert("SP_DeleteBranchMemberRole", MemberRoleDeletePara);
        }

        public String Branchid
        {
            set { branchid = value; }
        }

        public String Memberid
        {
            set { memberid = value; }
        }

        public String Roleid
        {
            set { roleid = value; }
        }

        public DataTable Result
        {
            get { return result; }
        }
    }
}
