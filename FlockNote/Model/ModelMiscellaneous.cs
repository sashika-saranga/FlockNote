using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDB;
using System.Data;

namespace FlockNote.Model
{
    class ModelMiscellaneous
    {
        private DataTable result;

        public void SelectPayType()
        {
            result = DBConnection.Select("SP_SelectPayType");
        }

        public void SelectVehicleBrand()
        {
            result = DBConnection.Select("SP_SelectVehicleBrand");
        }

        public void SelectVehicleType()
        {
            result = DBConnection.Select("SP_SelectVehicleType");
        }


        public DataTable Result
        {
            get { return result; }
        }
    }
}
