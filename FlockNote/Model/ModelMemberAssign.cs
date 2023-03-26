using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelMemberAssign
    {
        private String groupId;
        private String memberId;
        private String roleId;
        //private String name;
        //private String user;
        private DataTable results;
        //private String message;

        public void SelectAssignedMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("groupID", groupId);
            results = DBConnection.Select("SP_SelectAssignedMember", MemberPara);
        }

        public void SelectNotAssignedMember()
        {
            Dictionary<string, object> MemberPara = new Dictionary<string, object>();
            MemberPara.Add("groupID", groupId);
            results = DBConnection.Select("SP_SelectNotAssignedMember", MemberPara);
        }

        public void InsertGroupMember()
        {
            Dictionary<string, object> AddMemberPara = new Dictionary<string, object>();
            AddMemberPara.Add("Group", groupId);
            AddMemberPara.Add("Member", memberId);
            DBConnection.insert("SP_InsertGroupMember", AddMemberPara);
        }

        public void SelectAssignedRoleMemberGroup()
        {
            Dictionary<string, object> MemberRolePara = new Dictionary<string, object>();
            MemberRolePara.Add("GroupID", groupId);
            MemberRolePara.Add("MemberID", memberId);
            results = DBConnection.Select("SP_SelectAssignedRoleMemberGroup", MemberRolePara);
        }

        public void SelectNotAssignedRoleMemberGroup()
        {
            Dictionary<string, object> MemberRolePara = new Dictionary<string, object>();
            MemberRolePara.Add("GroupID", groupId);
            MemberRolePara.Add("MemberID", memberId);
            results = DBConnection.Select("SP_SelectNotAssignedRoleMemberGroup", MemberRolePara);
        }

        public void InsertRoleMember()
        {
            Dictionary<string, object> AddMemberRolePara = new Dictionary<string, object>();
            AddMemberRolePara.Add("Group", groupId);
            AddMemberRolePara.Add("Member", memberId);
            AddMemberRolePara.Add("Role", roleId);
            DBConnection.insert("SP_InsertRoleMember", AddMemberRolePara);
        }

        public void DeleteGroupMember()
        {
            Dictionary<string, object> MemberDeletPara = new Dictionary<string, object>();
            MemberDeletPara.Add("MemberID", memberId);
            MemberDeletPara.Add("GroupID", groupId);
            DBConnection.insert("SP_DeleteGroupMember", MemberDeletPara);
        }

        public void DeleteGroupMemberRole()
        {
            Dictionary<string, object> MemberRoleDeletePara = new Dictionary<string, object>();
            MemberRoleDeletePara.Add("MemberID", memberId);
            MemberRoleDeletePara.Add("GroupID", groupId);
            MemberRoleDeletePara.Add("RoleID", roleId);
            DBConnection.insert("SP_DeleteGroupMemberRole", MemberRoleDeletePara);
        }



        public String GroupId
        {
            set { groupId = value; }
        }
        public DataTable Results
        {
            get { return results; }
        }
        //public String Message
        //{
        //    get { return message; }
        //}
        //public String User
        //{
        //    set { user = value; }
        //}

        //public String Name
        //{
        //    set { name = value; }
        //}

        public String MemberId
        {
            set { memberId = value; }
        }

        public String RoleId
        {
            set { roleId = value; }
        }
    }
}
