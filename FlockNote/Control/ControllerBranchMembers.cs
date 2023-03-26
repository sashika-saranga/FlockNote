using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerBranchMembers
    {
        ModelBranchMember mbm = new ModelBranchMember();

        public DataTable SelectAssignedBranchMember(String branch)
        {
            mbm.Branchid = branch;
            mbm.SelectAssignedBranchMember();
            return mbm.Result;
        }

        public DataTable SelectNotAssignedBranchMember(String branch)
        {
            mbm.Branchid = branch;
            mbm.SelectNotAssignedBranchMember();
            return mbm.Result;
        }

        public void InsertBranchMember(String branch, String member)
        {
            mbm.Memberid = member;
            mbm.Branchid = branch;
            mbm.InsertBranchMember();
        }
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="member"></param>
        /// <returns></returns>

        public DataTable SelectAssignedRoleMemberBranch(String branch, String member)
        {
            mbm.Branchid = branch;
            mbm.Memberid = member;
            mbm.SelectAssignedRoleMemberBranch();
            return mbm.Result;
        }

        public DataTable SelectNotAssignedRoleMemberBranch(String branch, String member)
        {
            mbm.Branchid = branch;
            mbm.Memberid = member;
            mbm.SelectNotAssignedRoleMemberBranch();
            return mbm.Result;
        }

        public void InsertBranchMemberRole(String member, String branch, String role)
        {
            mbm.Memberid = member;
            mbm.Branchid = branch;
            mbm.Roleid = role;
            mbm.InsertBranchMemberRole();
        }

        public void DeleteBranchMember(String memberid, String branchid)
        {
            mbm.Memberid = memberid;
            mbm.Branchid = branchid;
            mbm.DeleteBranchMember();
        }

        public void DeleteBranchMemberRole(String memberid, String branchid, String roleid)
        {
            mbm.Memberid = memberid;
            mbm.Branchid = branchid;
            mbm.Roleid = roleid;
            mbm.DeleteBranchMemberRole();
        }
    }
}
