using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelUser
    {
        private String id;
        private String user;
        private String username;
        private String password;
        private String type;
        private String state;
        private DataTable result;

        public void SelectUserDeatails()
        {
            Dictionary<string, object> UserDetail = new Dictionary<string, object>();
            result = DBConnection.Select("SP_SelectUserDeatails", UserDetail);
        }

        public void SelectUsers()
        {
            Dictionary<string, object> AddUserPara = new Dictionary<string, object>();
            result = DBConnection.Select("SP_SelectUsers", AddUserPara);
        }

        public void InsertUsers()
        {
            Dictionary<string, object> AddUserPara = new Dictionary<string, object>();
            AddUserPara.Add("username", username);
            AddUserPara.Add("password", password);
            AddUserPara.Add("type", type);
            DBConnection.insert("SP_InsertUsers", AddUserPara);
        }

        public void UpdateUser()
        {
            Dictionary<string, object> UpdateUserPara = new Dictionary<string, object>();
            UpdateUserPara.Add("id", id);
            UpdateUserPara.Add("password", password);
            UpdateUserPara.Add("type", type);
            DBConnection.insert("SP_UpdateUser", UpdateUserPara);
        }

        public void SelectUserPermission()
        {
            Dictionary<string, object> AddUserPara = new Dictionary<string, object>();
            AddUserPara.Add("id", id);
            result = DBConnection.Select("SP_SelectUserPermission", AddUserPara);
        }

        public void SelectAccessGranted()
        {
            Dictionary<string, object> AddUserPara = new Dictionary<string, object>();
            AddUserPara.Add("user", id);
            result = DBConnection.Select("SP_SelectAccessGranted", AddUserPara);
        }

        public void SelectAccessDenied()
        {
            Dictionary<string, object> AddUserPara = new Dictionary<string, object>();
            AddUserPara.Add("user", id);
            result = DBConnection.Select("SP_SelectAccessDenied", AddUserPara);
        }

        public void UpdateUserPermission()
        {
            Dictionary<string, object> UpdatePermissionPara = new Dictionary<string, object>();
            UpdatePermissionPara.Add("user", user);
            UpdatePermissionPara.Add("permissionID", id);
            UpdatePermissionPara.Add("state", state);
            DBConnection.insert("SP_UpdateUserPermission", UpdatePermissionPara);
        }


        public String Id
        {
            set { id = value; }
        }

        public String Username
        {
            set { username = value; }
        }

        public String Password
        {
            set { password = value; }
        }

        public String Type
        {
            set { type = value; }
        }

        public String User
        {
            set { user = value; }
        }

        public String State
        {
            set { state = value; }
        }

        public DataTable Result
        {
            get { return result; }
        }
    }
}
