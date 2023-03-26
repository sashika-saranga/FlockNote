using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;
using SQLDB;

namespace FlockNote.Control
{
    class ControllerUser
    {
        ModelUser mu = new ModelUser();

        public DataTable SelectUserDeatails()
        {
            mu.SelectUserDeatails();
            return mu.Result;
        }

        public DataTable SelectUsers()
        {
            mu.SelectUsers();
            return mu.Result;
        }

        public void InsertUsers(String username, String password, String type)
        {
            mu.Username = username;
            mu.Password = password;
            mu.Type = type;
            mu.InsertUsers();
        }

        public void UpdateUser(String id, String password, String type)
        {
            mu.Id = id;
            mu.Password = password;
            mu.Type = type;
            mu.UpdateUser();
        }

        public DataTable SelectUserPermission(String id)
        {
            mu.Id = id;
            mu.SelectUserPermission();
            return mu.Result;
        }

        public DataTable SelectAccessGranted(String user)
        {
            mu.Id = user;
            mu.SelectAccessGranted();
            return mu.Result;
        }

        public DataTable SelectAccessDenied(String user)
        {
            mu.Id = user;
            mu.SelectAccessDenied();
            return mu.Result;
        }

        public void UpdateUserPermission(String user, String permissionId, String state)
        {
            mu.User = user;
            mu.Id = permissionId;
            mu.State = state;
            mu.UpdateUserPermission();

        }
    }
}
