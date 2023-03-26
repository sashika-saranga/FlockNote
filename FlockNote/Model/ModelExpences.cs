using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelExpences
    {
        private String exptype;
        private DataTable result;
        private String type;
        private String id;
        private String payment;
        private String amount;
        private String remark;
        private String date;
        private String todate;


        public void InsertExpencesType()
        {
            Dictionary<string, object> AddExpPara = new Dictionary<string, object>();
            AddExpPara.Add("type", exptype);
            DBConnection.insert("SP_InsertExpencesType", AddExpPara);

        }

        public void SearchExpencesType()
        {
            Dictionary<string, object> AddExpPara = new Dictionary<string, object>();
            AddExpPara.Add("type", exptype);
            result = DBConnection.Select("SP_SearchExpenceType", AddExpPara);
        }

        public void EditExpencesType()
        {
            Dictionary<string, object> UpdateExpTypePara = new Dictionary<string, object>();
            UpdateExpTypePara.Add("id", id);
            UpdateExpTypePara.Add("type", type);
            DBConnection.insert("SP_EditExpencesType", UpdateExpTypePara);
        }

        public void SelectExpenceType()
        {
            Dictionary<string, object> AddExpPara = new Dictionary<string, object>();
            result = DBConnection.Select("SP_SelectExpenceType", AddExpPara);
        }

        public void InsertExpences()
        {
            Dictionary<string, object> AddExpPara = new Dictionary<string, object>();
            AddExpPara.Add("ExpencesTypes", type);
            AddExpPara.Add("PaymentType", payment);
            AddExpPara.Add("Amount", amount);
            AddExpPara.Add("Remark", remark);
            AddExpPara.Add("date", date);
            DBConnection.insert("SP_InsertExpences", AddExpPara);

        }

        public void SelectExpenceDatewise()
        {
            Dictionary<string, object> AddExpPara = new Dictionary<string, object>();
            AddExpPara.Add("fromdate", date);
            AddExpPara.Add("todate", todate);
            result = DBConnection.Select("SP_SelectExpenceDatewise", AddExpPara);
        }

        public void DeleteExpences()
        {
            Dictionary<string, object> Para = new Dictionary<string, object>();
            Para.Add("id", id);
            DBConnection.insert("SP_DeleteExpences", Para);
        }

        public DataTable Result
        {
            get { return result; }
        }

        public String Exptype
        {
            set { exptype = value; }
        }

        public String Type
        {
            set { type = value; }
        }

        public String Id
        {
            set { id = value; }
        }

        public String Payment
        {
            set { payment = value; }
        }

        public String Amount
        {
            set { amount = value; }
        }

        public String Remark
        {
            set { remark = value; }
        }

        public String Date
        {
            set { date = value; }
        }

        public String Todate
        {
            set { todate = value; }
        }
    }
}
