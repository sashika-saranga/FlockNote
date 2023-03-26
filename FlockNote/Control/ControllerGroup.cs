using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerGroup
    {
        ModelGroup mg = new ModelGroup();

        public DataTable SelectGroupByType(String GroupType)
        {
            mg.GroupType = GroupType;
            mg.SelectGroupByType();
            return mg.Result;
        }

        public DataTable SearchGroup(String GroupNamePara)
        {
            mg.GroupName = GroupNamePara;
            mg.SearchGroup();
            return mg.Result;
        }

        public DataTable SearchOtherGroup(String GroupNamePara)
        {
            mg.GroupName = GroupNamePara;
            mg.SearchOtherGroup();
            return mg.Result;
        }

        public DataTable SearchCellGroup(String GroupNamePara)
        {
            mg.GroupName = GroupNamePara;
            mg.SearchCellGroup();
            return mg.Result;
        }

        public String InsertGroup(String GroupName, String Active, String Type, String user)
        {
            mg.GroupName = GroupName;
            mg.Active = Active;
            mg.Type = Type;
            mg.User = user;
            mg.InsertGroup();
            return mg.Messege;
        }

        public String UpdateGroup(String GroupId, String GroupName, String Active, String user)
        {
            mg.GroupId = GroupId;
            mg.GroupName = GroupName;
            mg.Active = Active;
            mg.User = user;
            mg.UpdateGroup();
            return mg.Messege;
        }
    }
}
