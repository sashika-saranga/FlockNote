using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerVehicles
    {
        ModelVehicles mv = new ModelVehicles();

        public void InsertVehicles(String Vnumber, String Vmodel, String Vbrand, String Vtype, String Active)
        {
            mv.Vnumber = Vnumber;
            mv.Vmodel = Vmodel;
            mv.Vbrand = Vbrand;
            mv.Vtype = Vtype;
            mv.Active = Active;
            mv.InsertVehicles();
        }

        public DataTable SelectVehicles()
        {
            mv.SelectVehicles();
            return mv.Result;
        }

        public void InsertLicense(String vid, String reneDate, String amount, String user)
        {
            mv.Vid = vid;
            mv.Date = reneDate;
            mv.Amount = amount;
            mv.User = user;
            mv.InsertLicense();
        }

        public void InsertInsuarance(String vid, String reneDate, String amount, String user)
        {
            mv.Vid = vid;
            mv.Date = reneDate;
            mv.Amount = amount;
            mv.User = user;
            mv.InsertInsuarance();
        }

        public DataTable SelectLicenseDetails(String vid)
        {
            mv.Vid = vid;
            mv.SelectLicenseDetails();
            return mv.Result;
        }

        public DataTable SelectInsuaranceDetails(String vid)
        {
            mv.Vid = vid;
            mv.SelectInsuaranceDetails();
            return mv.Result;
        }

        public void UpdateVehicle(String vehicleID, String vnumber, String model, String brand, String type, String active)
        {
            mv.Vid = vehicleID;
            mv.Vnumber = vnumber;
            mv.Vmodel = model;
            mv.Vbrand = brand;
            mv.Vtype = type;
            mv.Active = active;
            mv.UpdateVehicle();

        }
    }
}
