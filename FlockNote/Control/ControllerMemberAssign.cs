using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerMemberAssign
    {
        ModelMemberAssign mm = new ModelMemberAssign();

        public DataTable SelectAssignedMember(String group)
        {
            mm.GroupId = group;
            mm.SelectAssignedMember();
            return mm.Results;
        }

        public DataTable SelectNotAssignedMember(String group)
        {
            mm.GroupId = group;
            mm.SelectNotAssignedMember();
            return mm.Results;
        }

        public void InsertGroupMember(String group, String member)
        {
            mm.MemberId = member;
            mm.GroupId = group;
            mm.InsertGroupMember();
        }

        public DataTable SelectAssignedRoleMemberGroup(String group, String member)
        {
            mm.GroupId = group;
            mm.MemberId = member;
            mm.SelectAssignedRoleMemberGroup();
            return mm.Results;
        }

        public DataTable SelectNotAssignedRoleMemberGroup(String group, String member)
        {
            mm.GroupId = group;
            mm.MemberId = member;
            mm.SelectNotAssignedRoleMemberGroup();
            return mm.Results;
        }

        public void InsertRoleMember(String group, String member, String role)
        {
            mm.MemberId = member;
            mm.GroupId = group;
            mm.RoleId = role;
            mm.InsertRoleMember();
        }

        public void DeleteGroupMember(String memberid, String groupid)
        {
            mm.MemberId = memberid;
            mm.GroupId = groupid;
            mm.DeleteGroupMember();
        }

        public void DeleteGroupMemberRole(String memberid, String groupid, String roleid)
        {
            mm.MemberId = memberid;
            mm.GroupId = groupid;
            mm.RoleId = roleid;
            mm.DeleteGroupMemberRole();
        }
    }
}