using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerFamilyAssign
    {
        ModelFamilyAssign fa = new ModelFamilyAssign();

        public DataTable SelectAssignedFamilyMember(String family)
        {
            fa.FamilyId = family;
            fa.SelectAssignedFamilyMember();
            return fa.Result;
        }

        public DataTable SelectNotAssignedFamilyMember(String family)
        {
            fa.FamilyId = family;
            fa.SelectNotAssignedFamilyMember();
            return fa.Result;
        }

        public void InsertFamilyMember(String family, String member)
        {
            fa.FamilyId = family;
            fa.MemberId = member;
            fa.InsertFamilyMember();
        }

        public void DeleteFamilyMember(String familyid, String memberid)
        {
            fa.FamilyId = familyid;
            fa.MemberId = memberid;
            fa.DeleteFamilyMember();
        }
    }
}
