using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;


namespace FlockNote.Control
{
    class ControllerInventry
    {
        ModelInventory mi = new ModelInventory();

        public void InsertInventoryIn(String Item, String Qty, String remark, String Date, String Type, String Cost)
        {
            mi.Item = Item;
            mi.Qty = Qty;
            mi.Remark = remark;
            mi.Date = Date;
            mi.Type = Type;
            mi.Cost = Cost;
            mi.InsertInventoryIn();
        }

        public void InsertInventoryOut(String Item, String Qty, String date, String cost, String payType, String type, String remark)
        {
            mi.Item = Item;
            mi.Qty = Qty;
            mi.Remark = remark;
            mi.Date = date;
            mi.Type = type;
            mi.Cost = cost;
            mi.PayType = payType;
            mi.InsertInventoryOut();
        }

        public DataTable SelectAllItems(String Name)
        {
           mi.Item = Name;
           mi.SelectAllItems();
           return mi.Result;
        }

        public void InsertInventryInMembers(String MemberID)
        {
            mi.Member = MemberID;
            mi.InsertInventryInMembers();
        }
    }
}
