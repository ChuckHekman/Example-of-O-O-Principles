using System;
using System.Text.RegularExpressions;

namespace Example_of_O_O_Principles
{
    class Credit : PaymentType
    {
        private ulong cardNumber;
        private int expirationMonth;
        private int expirationYear;
        private int cVV;
        private string name;

        public ulong CardNumber
        {
            get
            {
                return this.cardNumber;
            }
            set
            {
                this.cardNumber = value;
            }
        }

        public int ExpirationMonth
        {
            get
            {
                return this.expirationMonth;
            }
            set
            {
                this.expirationMonth = value;
            }
        }

        public int ExpirationYeae
        {
            get
            {
                return this.expirationYear;
            }
            set
            {
                this.expirationYear = value;
            }
        }
        public int CVV
        {
            get
            {
                return this.cVV;
            }
            set
            {
                this.cVV = value;
            }
        }

        public string Name { get => name; set => name = value; }

        public Credit()
        {
            //Console.WriteLine("Credit (payment) class constructor, no parameters");
        }

        public void GetCreditInfo()
        {
            // get name on credit card
            Console.Write("\nName on credit card: ");
            this.name = Console.ReadLine();

            // get credit card number (continue to loop until a valid int has been entered)
            bool isValid = false;
            while (isValid == false)
            {
                Console.WriteLine("Credit card number (we only take Visa and they always start with the number \"4\" and are 16 digits long): ");
                string input = Console.ReadLine();
                isValid = Regex.IsMatch(input, @"^4[0-9]{12}(?:[0-9]{3})?$");
                if (isValid == true)
                {
                    this.cardNumber = ulong.Parse(input);
                }
            }

            // get the card expiration month (continue to loop until a valid int has been entered)
            bool result = false;
            while (result == false)
            {
                Console.Write("Expiration month: ");
                string input = Console.ReadLine();
                expirationMonth = EditInput.DigitInRange(input, 1, 12);
                if (expirationMonth >= 1 && expirationMonth <= 12)
                {
                    result = true;
                }
            }

            // get the card expiration year (continue to loop until a valid int has been entered)
            result = false;
            while (result == false)
            {
                Console.Write("Expiration year: ");
                string input = Console.ReadLine();
                this.expirationYear = EditInput.DigitInRange(input, 2018, 2026);
                if (this.expirationYear >= 2018 && this.expirationYear <= 2026)
                {
                    result = true;
                }
            }

            // get the card cvv number (continue to loop until a valid int has been entered)
            result = false;
                while (result == false)
                {
                    //result = GetCvvInput();
                    Console.Write("CVV on back of card: ");
                    string input = Console.ReadLine();
                    this.cVV = EditInput.DigitInRange(input, 1, 999);
                    if (this.CVV >= 1 && this.CVV <= 999)
                    {
                        result = true;
                    }
                }
            }

        //public bool GetCvvInput()
        //{
        //    Console.Write("CVV on back of card: ");
        //    string input = Console.ReadLine();
        //    this.cVV = InputValidator.DigitInRange(input, 1, 999);
        //    if (this.CVV >= 1 && this.CVV <= 999)
        //    { return true; }
        //    else
        //    { return false; }
        //}

        public override string ToString()
        {
            return "\nCredit: " +
                "\nSubtotal: ".PadRight(18) +
                base.SubTotal.ToString("$#.##") +
                "\nTax: ".PadRight(18) +
                base.TaxPaid.ToString("$#.##") +
                "\nTotal: ".PadRight(18) +
                base.TotalAmt.ToString("$#.##") +
                "\nName on card: ".PadRight(18) + name +
                "\nCredit card #: ".PadRight(18) +
                this.cardNumber +
                "\nExpiration date: ".PadRight(18) +
                this.expirationMonth + "/" +
                this.expirationYear +
                "\nCVV of ".PadRight(18) +
                this.cVV;
        }
    }
}