using System;
using System.Collections.Generic;
using System.Text;

namespace Example_of_O_O_Principles
{
    abstract class PaymentType
    {
        private const decimal tax = .06M;
        private decimal subTotal = .00M;
        private decimal taxPaid = .00M;
        private decimal totalAmt = .00M;

        public decimal Tax { get; set; }

        public decimal SubTotal
        {
            get
            {
                return this.subTotal;
            }
            set
            {
                this.subTotal = value;
            }
        }

        public decimal TaxPaid
        {
            get
            {
                return this.SubTotal * tax;
            }
            set
            {
            }
        }

        public decimal TotalAmt
        {
            get
            {
                return this.SubTotal + this.TaxPaid;
            }
            set { }
        }

        public PaymentType() // Default constructor
        {
        }

        public virtual string ToString()
        {
            return "";
        }
    }
}