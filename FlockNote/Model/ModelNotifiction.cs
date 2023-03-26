using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelNotifiction
    {
        private DataTable results;

        public void SelectBirthdayNotification()
        {
            Dictionary<string, object> BdayPara = new Dictionary<string, object>();
            results = DBConnection.Select("SP_SelectBirthdayNotification", BdayPara);
        }


        public DataTable Results
        {
            get { return results; }
        }
    }
}
