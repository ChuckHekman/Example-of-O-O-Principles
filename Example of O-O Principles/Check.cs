using System;

namespace Example_of_O_O_Principles
{
    class Check : PaymentType
    {
        private int checkNumber;

        public int CheckNumber
        {
            get
            {
                return this.checkNumber;
            }
            set
            {
                this.checkNumber = value;
            }
        }

        public Check()
        {
            //Console.WriteLine("Check (payment) class constructor, no parameters");
        }

        public void GetCheckNumber()
        {
            // get check number (continue to loop until a valid int has been entered)
            // get the card cvv number (continue to loop until a valid int has been entered)
            bool result = false;
            while (result == false)
            {
                Console.Write("Enter the check number (up to 4 digits): ");
                string input = Console.ReadLine();
                this.checkNumber = EditInput.DigitInRange(input, 1, 9999);
                if (this.CheckNumber >= 1 && this.CheckNumber <= 9999)
                {
                    result = true;
                }
            }
        }

        public override string ToString()
        {
            return "\nCheck: " +
                "\nSubtotal: ".PadRight(17) +
                base.SubTotal.ToString("$#.##") +
                "\nTax: ".PadRight(17) + 
                base.TaxPaid.ToString("$#.##") +
                "\nTotal: ".PadRight(17) +
                base.TotalAmt.ToString("$#.##") +
                "\nCheck number: ".PadRight(17) +
                CheckNumber;
        }
    }
}
