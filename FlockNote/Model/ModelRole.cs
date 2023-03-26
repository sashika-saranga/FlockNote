using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelRole
    {
        private String roleid;
        private String roleName;
        private String roletype;
        private String active;
        private DataTable reuslts;

        public void SearchRole()
        {
            Dictionary<string, object> RoleNamePara = new Dictionary<string, object>();
            RoleNamePara.Add("RoleName", roleName);
            reuslts = DBConnection.Select("SP_SearchRole", RoleNamePara);
        }

        public void InsertRole()
        {
            Dictionary<string, object> AddRolePara = new Dictionary<string, object>();
            AddRolePara.Add("RoleName", roleName);
            AddRolePara.Add("RoleType", roletype);
            AddRolePara.Add("Active", active);
            DBConnection.insert("SP_InsertRole", AddRolePara);

        }

        public void EditRole()
        {
            Dictionary<string, object> UpdateRolePara = new Dictionary<string, object>();
            UpdateRolePara.Add("RoleID", roleid );
            UpdateRolePara.Add("RoleName", roleName);
            UpdateRolePara.Add("RoleType", roletype);
            UpdateRolePara.Add("Active", active);
            DBConnection.insert("SP_UpdateRole", UpdateRolePara);
        }

        public void SelectLeaderRoles()
        {
            Dictionary<string, object> RoleNamePara = new Dictionary<string, object>();
            reuslts = DBConnection.Select("SP_SelectLeaderRoles", RoleNamePara);
        }


        public String Roleid
        {
            set { roleid = value; }
        }

        public String RoleName
        {
            set { roleName = value; }
        }

        public String Active
        {
            set { active = value; }
        }


        public DataTable Reuslts
        {
            get { return reuslts; }
        }

        public String Roletype
        {
            set { roletype = value; }
        }
    }
}
