using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDB;
using System.Data;

namespace FlockNote.Model
{
    class ModelPayType
    {
        private String PayTypeID;
        private String PayTypeName;
        private DataTable result;

        public void SearchPaymentType()
        {
            Dictionary<string, object> PayTypePara = new Dictionary<string, object>();
            PayTypePara.Add("PaymentName", PayTypeName);
            result = DBConnection.Select("SP_SearchPaymentType", PayTypePara);
        }

        public String payTypeID
        {
            set { PayTypeID = value; }
        }
        public String payTypeName
        {
            set { PayTypeName = value; }
        }
        public DataTable Result
        {
            get { return result; }

        }
    }
}
