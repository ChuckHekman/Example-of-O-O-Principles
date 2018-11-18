using System;
using System.Collections.Generic;

namespace Example_of_O_O_Principles
{
    class Cash : PaymentType
    {
        private decimal cashTendered;

        public decimal CashTendered
        {
            get
            {
                return this.cashTendered;
            }
            set
            {
                this.cashTendered = value;
            }
        }

        public Cash()
        {
            //Console.WriteLine("Cash (payment) class constructor, no parameters");
        }

        public void EnterCash()
        {
            // enter the amount of cash tendered
            bool result = false;
            while (result == false)
            {
                Console.Write("\nEnter the amount of cash tendered: ");
                //decimal cashTendered = 0.00M;
                string input = Console.ReadLine();
                bool isDecimal = Decimal.TryParse(input, out cashTendered);
                if (isDecimal)
                {
                    result = true;
                }
            }
        }

        public decimal FinalTotal()
        {
            return base.TotalAmt - this.CashTendered;
        }

        public override string ToString()
        {
            return "\nCash: " +
                "\nSubtotal: ".PadRight(17) +
                base.SubTotal.ToString("$#.##") +
                "\nTax: ".PadRight(17) +
                base.TaxPaid.ToString("$#.##") +
                "\nTotal: ".PadRight(17) +
                base.TotalAmt.ToString("$#.##") +
                "\nCash tendered: ".PadRight(17) +
                this.CashTendered.ToString("$#.##") +
                "\nFinal total: ".PadRight(17) +
                this.FinalTotal().ToString("$#.##");
        }

    }
}
