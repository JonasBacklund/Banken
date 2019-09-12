using System;
using System.Collections.Generic;
using System.Text;

namespace Banken
{ 
        class Customer
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public string ShowCustomer() { return Name +" "+ Balance ; }

        internal bool customerList()
        {
            throw new NotImplementedException();
        }
    }

}
