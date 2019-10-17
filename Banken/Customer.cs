using System;
using System.Collections.Generic;
using System.Text;

namespace Banken
{ 
        class Customer
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public string ShowCustomerName() { return Name; }

        public int ShowCustomerBalance() { return Balance; }

    }

}
