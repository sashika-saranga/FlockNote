using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerRole
    {
        ModelRole mr = new ModelRole();

        public DataTable SearchRole(String RoleNamePara)
        {
            mr.RoleName = RoleNamePara;
            mr.SearchRole();
            return mr.Reuslts; 
        }

        public void InsertRole(String roleName, String roleType,String active)
        {
            mr.RoleName = roleName;
            mr.Roletype = roleType;
            mr.Active = active;
            mr.InsertRole();
        }

        public void EditRole(String roleid, String roleName, String roletype, String active)
        {
            mr.Roleid = roleid;
            mr.RoleName = roleName;
            mr.Roletype = roletype;
            mr.Active = active;
            mr.EditRole();

        }

        public DataTable SelectLeaderRoles()
        {
            mr.SelectLeaderRoles();
            return mr.Reuslts;
        }
    }
}
