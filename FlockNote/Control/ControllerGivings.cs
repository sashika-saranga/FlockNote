using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlockNote.Model;
using System.Data;

namespace FlockNote.Control
{
    class ControllerGivings
    {
        ModelGivings mg = new ModelGivings();

        public DataTable SearchMember(String MemberPara)
        {
            mg.Fname = MemberPara;
            mg.SearchMember();
            return mg.Result;
        }

        public DataTable SearchGivingTypes(String GivingPara)
        {
            mg.Givingtype = GivingPara;
            mg.SearchGivingTypes();
            return mg.Result;
        }

        public void InsertGivingDetails(String givingID, String amount, String remark)
        {
            mg.Givingid = givingID;
            mg.Amount = amount;
            mg.Remark = remark;
            mg.InsertGivingDetails();

        }

        public String InsertGivingHeader(String memberID, String Payment, String payType, String User)
        {
            mg.Id = memberID;
            mg.Amount = Payment;
            mg.Paytype = payType;
            mg.User = User;
            mg.InsertGivingHeader();
            return mg.Messege;
        }
    }
}
