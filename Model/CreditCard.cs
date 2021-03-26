using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CreditCard : Payment
    {
        public string Number { get; set; }
        public string Cardholder { get; set; }
        public string CVV { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
