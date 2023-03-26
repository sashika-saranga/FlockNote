using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerFamily
    {
        ModelFamily mf = new ModelFamily();

        public DataTable SearchFamily(String FamilyNamePara)
        {
            mf.FamilyName = FamilyNamePara;
            mf.SearchFamily();
            return mf.Reuslts;
        }

        public void InsertFamily(String FamilyName, String Address, String active)
        {
            mf.FamilyName = FamilyName;
            mf.Address = Address;
            mf.Active = active;
            mf.InsertFamily();
        }

        public void UpdateFamily(String familyID, String familyName, String address, String active)
        {
            mf.Familyid = familyID;
            mf.FamilyName = familyName;
            mf.Address = address;
            mf.Active = active;
            mf.UpdateFamily();

        }
    }
}
