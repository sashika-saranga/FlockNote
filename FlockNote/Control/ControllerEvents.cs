using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FlockNote.Model;

namespace FlockNote.Control
{
    class ControllerEvents
    {
        ModelEvents me = new ModelEvents();

        public void InsertGroups(String ID)
        {
            me.Gid = ID;
            me.InsertGroups();

        }

        public void InsertMembers(String ID)
        {
            me.Mid = ID;
            me.InsertMembers();

        }

        public String InsertEventHeader(String organizor, String description, String date, String User)
        {
            me.Organizor = organizor;
            me.Description = description;
            me.Date = date;
            me.User = User;
            me.InsertEventHeader();
            return me.Msg;
        }
    }
}
