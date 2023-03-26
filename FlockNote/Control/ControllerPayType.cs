using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerPayType
    {
        ModelPayType pt = new ModelPayType();

        public DataTable SearchPaymentType(String PayTypePara)
        {
            pt.payTypeName = PayTypePara;
            pt.SearchPaymentType();
            return pt.Result;

        }
    }
}
