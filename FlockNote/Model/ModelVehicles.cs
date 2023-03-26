using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;

namespace FlockNote.Model
{
    class ModelVehicles
    {
        private String vid;
        private String vnumber;
        private String vmodel;
        private String vbrand;
        private String vtype;
        private String active;
        private DataTable result;
        private String date;
        private String amount;
        private String user;


        public void InsertVehicles()
        {
            Dictionary<string, object> AddVehiclePara = new Dictionary<string, object>();
            AddVehiclePara.Add("RegNo", vnumber);
            AddVehiclePara.Add("Model", vmodel);
            AddVehiclePara.Add("Brand", vbrand);
            AddVehiclePara.Add("Type", vtype);
            AddVehiclePara.Add("Active", active);
            DBConnection.insert("SP_InsertVehicles", AddVehiclePara);
        }

        public void SelectVehicles()
        {
            Dictionary<string, object> AddVehiclePara = new Dictionary<string, object>();
            result = DBConnection.Select("SP_SelectVehicles", AddVehiclePara);
        }

        public void InsertLicense()
        {
            Dictionary<string, object> AddLicensePara = new Dictionary<string, object>();
            AddLicensePara.Add("Vid", vid);
            AddLicensePara.Add("RenDate", date);
            AddLicensePara.Add("Amount", amount);
            AddLicensePara.Add("user", user);
            DBConnection.insert("SP_InsertLicense", AddLicensePara);
        }
        public void InsertInsuarance()
        {
            Dictionary<string, object> AddInsuPara = new Dictionary<string, object>();
            AddInsuPara.Add("Vid", vid);
            AddInsuPara.Add("RenDate", date);
            AddInsuPara.Add("Amount", amount);
            AddInsuPara.Add("user", user);
            DBConnection.insert("SP_InsertInsuarance", AddInsuPara);
        }

        public void SelectLicenseDetails()
        {
            Dictionary<string, object> LicensePara = new Dictionary<string, object>();
            LicensePara.Add("Vid", vid);
            result = DBConnection.Select("SP_SelectLicenseDetails", LicensePara);
        }

        public void SelectInsuaranceDetails()
        {
            Dictionary<string, object> InsuPara = new Dictionary<string, object>();
            InsuPara.Add("Vid", vid);
            result = DBConnection.Select("SP_SelectInsuaranceDetails", InsuPara);
        }

        public void UpdateVehicle()
        {
            Dictionary<string, object> UpdateVehiclePara = new Dictionary<string, object>();
            UpdateVehiclePara.Add("VehicleID", vid);
            UpdateVehiclePara.Add("VehicleNumber", vnumber);
            UpdateVehiclePara.Add("Model", vmodel);
            UpdateVehiclePara.Add("Brand", vbrand);
            UpdateVehiclePara.Add("Type", vtype);
            UpdateVehiclePara.Add("Active", active);
            DBConnection.insert("SP_UpdateVehicle", UpdateVehiclePara);
        }

        public String Vid
        {
            set { vid = value; }
        }
        public String Vnumber
        {
            set { vnumber = value; }
        }
        public String Vmodel
        {
            set { vmodel = value; }
        }
        public String Vbrand
        {
            set { vbrand = value; }
        }
        public String Vtype
        {
            set { vtype = value; }
        }
        public String Active
        {
            set { active = value; }
        }
        public DataTable Result
        {
            get { return result; }
        }

        public String Date
        {
            set { date = value; }
        }

        public String Amount
        {
            set { amount = value; }
        }

        public String User
        {
            set { user = value; }
        }
    }
}
