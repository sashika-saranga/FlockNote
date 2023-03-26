using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SQLDB;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerNotifications
    {
        ModelNotifiction mn = new ModelNotifiction();

        public DataTable SelectBirthdayNotification()
        {
            mn.SelectBirthdayNotification();
            return mn.Results;
        }
    }
}
