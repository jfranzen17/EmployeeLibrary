using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public bool IsAdmin { get; set; }

    }
}

