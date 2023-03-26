using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerExpences
    {
        ModelExpences me = new ModelExpences();

        public void InsertExpType(String type)
        {
            me.Exptype = type;
            me.InsertExpencesType();
        }

        public DataTable SearchExpencesType(String type)
        {
            me.Exptype = type; 
            me.SearchExpencesType(); 
            return me.Result;
        }
        public void EditExpencesType(String id, String type)
        {
            me.Id = id;
            me.Type = type;
            me.EditExpencesType();
        }

        public DataTable SelectExpenceType()
        {
            me.SelectExpenceType();
            return me.Result;
        }

        public void InsertExpences(String type, String payment, String amount, String remark, String date)
        {
            me.Type = type;
            me.Payment = payment;
            me.Amount = amount;
            me.Remark = remark;
            me.Date = date;
            me.InsertExpences();
        }

        public DataTable SelectExpenceDatewise(String fromdate, String todate)
        {
            me.Date = fromdate;
            me.Todate = todate;
            me.SelectExpenceDatewise();
            return me.Result;
        }

        public void DeleteExpences(String id)
        {
            me.Id = id;
            me.DeleteExpences();
        }
    }
}
