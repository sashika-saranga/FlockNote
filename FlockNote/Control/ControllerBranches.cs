using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerBranches
    {
        ModelBranches mb = new ModelBranches();

        public DataTable SearchBranches(String branch)
        {
            mb.BranchName = branch;
            mb.SearchBranches();
            return mb.Reuslts;
        }

        public void InsertBranch(String branchName, String Address, String phone, String active)
        {
            mb.BranchName = branchName; ;
            mb.Address = Address;
            mb.Phone = phone;
            mb.Active = active;
            mb.InsertBranch();
        }

        public void UpdateBranch(String branchid, String branchName, String Address, String phone, String active)
        {
            mb.Branchid = branchid;
            mb.BranchName = branchName; ;
            mb.Address = Address;
            mb.Phone = phone;
            mb.Active = active;
            mb.UpdateBranch();

        }
    }
}
