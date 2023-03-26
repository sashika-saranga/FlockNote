using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlockNote.Model;
using System.Data;

namespace FlockNote.Control
{
    class ControllerMiscellaneous
    {
        ModelMiscellaneous mg = new ModelMiscellaneous();

        public DataTable SelectPayType()
        {
            mg.SelectPayType();
            return mg.Result;
        }

        public DataTable SelectVehicleBrand()
        {
            mg.SelectVehicleBrand();
            return mg.Result;
        }

        public DataTable SelectVehicleType()
        {
            mg.SelectVehicleType();
            return mg.Result;
        }
    }
}
