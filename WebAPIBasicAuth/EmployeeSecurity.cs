using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIBasicAuth
{
    public class EmployeeSecurity
    {
        public static bool Login(string uname, string pass)
        {
            using (testEntities entity = new testEntities())
            {
                return entity.tblLogins.Any(x => x.username.Equals(uname, StringComparison.OrdinalIgnoreCase) && x.pass == pass);
            }
        }
    }
}