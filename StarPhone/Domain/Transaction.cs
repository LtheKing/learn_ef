using System;
using System.Collections.Generic;

namespace Domain
{
    public class Transaction
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public List<Phone> Phones { get; set; }
        public DateTime TransactionDate { get; set; }

        public Phone Phone { get; set; }
    }
}