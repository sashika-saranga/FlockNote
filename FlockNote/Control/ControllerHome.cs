using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerHome
    {
        ModelHome mh = new ModelHome();

        public DataTable SearchMemberRole(String memberid)
        {
            mh.Memberid = memberid;
            mh.SearchMemberRole();
            return mh.Result;
        }

        public DataTable SearchMemberAllDetails(String memberid)
        {
            mh.Memberid = memberid;
            mh.SearchMemberAllDetails();
            return mh.Result;
        }
    }
}
