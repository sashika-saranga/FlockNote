using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDB;
using System.Data;

namespace FlockNote.Model
{
    class ModelInventory
    {
        String item;
        String qty;
        String remark;
        String date;
        String type;
        String cost;
        String member;
        String payType;
        DataTable result;


        public void InsertInventoryIn()
        {
            Dictionary<string, object> AddInventPara = new Dictionary<string, object>();
            AddInventPara.Add("Item", item);
            AddInventPara.Add("Qty", qty);
            AddInventPara.Add("Remark", remark);
            AddInventPara.Add("Date", date);
            AddInventPara.Add("Type", type);
            AddInventPara.Add("Cost", cost);
            DBConnection.insert("SP_InsertInventoryIn", AddInventPara);
        }

        public void InsertInventoryOut()
        {
            Dictionary<string, object> AddInventPara = new Dictionary<string, object>();
            AddInventPara.Add("Item", item);
            AddInventPara.Add("Qty", qty);
            AddInventPara.Add("Remark", remark);
            AddInventPara.Add("Date", date);
            AddInventPara.Add("Type", type);
            AddInventPara.Add("Cost", cost);
            AddInventPara.Add("PayType", payType);
            DBConnection.insert("SP_InsertInventoryOut", AddInventPara);
        }

        public void SelectAllItems()
        {
            Dictionary<string, object> ItemPara = new Dictionary<string, object>();
            ItemPara.Add("Name", item);
            result = DBConnection.Select("SP_SelectAllItems", ItemPara);
        }

        public void InsertInventryInMembers()
        {
            Dictionary<string, object> AddInventMemberPara = new Dictionary<string, object>();
            AddInventMemberPara.Add("Member", member);
            DBConnection.insert("SP_InsertInventryInMembers", AddInventMemberPara);
        }

        public String Item
        {
            set { item = value; }
        }

        public String Qty
        {
            set { qty = value; }
        }
        public String Remark
        {
            set { remark = value; }
        }

        public String Date
        {
            set { date = value; }
        }
        public String Type
        {
            set { type = value; }
        }
        public String Cost
        {
            set { cost = value; }
        }
        public DataTable Result
        {
            get { return result; }
        }

        public String Member
        {
            set { member = value; }
        }

        public String PayType
        {
            set { payType = value; }
        }
    }
}
