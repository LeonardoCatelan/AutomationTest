using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTest.Data
{
    public class User
    {
        public readonly string name;
        public readonly string password;
        public readonly string license;

        public User(string name, string password, string license)
        {
            this.name = name;
            this.password = password;
            this.license = license;
        }
    }
}
