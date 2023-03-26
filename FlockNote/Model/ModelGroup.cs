using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelGroup
    {
        private String groupId;
        private String groupName;
        private String groupType;
        private String active;
        private String type;
        private String user;
        private DataTable result;
        private String messege;


        public void SelectGroupByType()
        {
            Dictionary<string, object> GroupNTypePara = new Dictionary<string, object>();
            GroupNTypePara.Add("GroupType", groupType);
            result = DBConnection.Select("SP_SelectGroupByType", GroupNTypePara);
        }

        public void SearchGroup()
        {
            Dictionary<string, object> GroupNamePara = new Dictionary<string, object>();
            GroupNamePara.Add("GroupName", groupName);
            result = DBConnection.Select("SP_SearchGroup", GroupNamePara);
        }
        
        public void SearchOtherGroup()
        {
            Dictionary<string, object> GroupNamePara = new Dictionary<string, object>();
            GroupNamePara.Add("GroupName", groupName);
            result = DBConnection.Select("SP_SearchOtherGroup", GroupNamePara);
        }

        public void SearchCellGroup()
        {
            Dictionary<string, object> GroupNamePara = new Dictionary<string, object>();
            GroupNamePara.Add("GroupName", groupName);
            result = DBConnection.Select("SP_SearchCellGroup", GroupNamePara);
        }

        public String InsertGroup()
        {
            try
            {
                Dictionary<string, object> AddGroupPara = new Dictionary<string, object>();
                AddGroupPara.Add("GroupName", groupName);
                AddGroupPara.Add("Active", active);
                AddGroupPara.Add("Type", type);
                AddGroupPara.Add("UserID", user);
                DBConnection.insert("SP_InsertGroup", AddGroupPara);
                messege = groupName + " inserted successfully";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE KEY"))
                    messege = "Duplicated, Group Name already avaliable";
                else
                    messege = ex.ToString();
                    //messege = "Group Name insert error";
            }
            return messege;
        }

        public String UpdateGroup()
        {
            try
            {
                Dictionary<string, object> UpdateGroupPara = new Dictionary<string, object>();
                UpdateGroupPara.Add("GroupID", groupId);
                UpdateGroupPara.Add("GroupName", groupName);
                UpdateGroupPara.Add("Active", active);
                UpdateGroupPara.Add("user", user);
                DBConnection.insert("SP_UpdateGroup", UpdateGroupPara);
                messege = "Group updated";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE KEY"))
                    messege = "Duplicated, Group Name already avaliable";
                else
                    messege = ex.ToString();
                //messege = "Group Name insert error";
            }
            return messege;
        }



        public String GroupId
        {
            set { groupId = value; }
        }
        public String GroupName
        {
            set { groupName = value; }
        }
        public String GroupType
        {
            set { groupType = value; }
        }
        public String Active
        {
            set { active = value; }
        }
        public String Type
        {
            set { type = value; }
        }
        public String User
        {
            set { user = value; }
        }

        public DataTable Result
        {
            get { return result; }
        }

        public String Messege
        {
            get { return messege; }
        }
    }
}
