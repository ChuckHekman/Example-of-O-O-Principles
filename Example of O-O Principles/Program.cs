using System;
using System.Collections.Generic;

/*
 
Author:     Chuck Hekman, 11/1/2018

Purpose:    Written as a small example of abstraction, inheritance, encapsulation and polymorphism

Goals       Example of Abstraction
            Example of Inheritance
            Example of Encapsulation
            Example of Polymorphism
            Example of a class that performs input editting

Classes     PaymentType (Abstract base class)
            Cash (Subclass)
            Check (Subclass)
            Credit (Subclass)
            EditInput (used whenever the user inputs something)
            ContinueLoop

*/

namespace Example_of_O_O_Principles
{
    class Program
    {

        static void Main(string[] args)
        {
            List<PaymentType> cashRegisterReceipt = new List<PaymentType>();

            bool doAgain = true;
            while (doAgain == true)
            {
                Console.Clear();

                WelcomeMessage();                                       // display the welcome message
                List<string> paymentOptions = LoadPaymentOptions();     // load the List array with the payment options
                string menuOption = GetMenuSelection(paymentOptions);   // display the payment options, allow user to select one

                decimal salesAmount = GetSalesAmount();

                if (menuOption == "Cash")
                {
                    Cash cash = new Cash();
                    cash.SubTotal = salesAmount;  // using the set property
                    cash.EnterCash();
                    cashRegisterReceipt.Add(cash);
                }
                else if (menuOption == "Check")
                {
                    Check check = new Check();
                    check.SubTotal = salesAmount;  // using the set property
                    check.GetCheckNumber();
                    cashRegisterReceipt.Add(check);
                }
                else if (menuOption == "Credit Card")
                {
                    Credit credit = new Credit();
                    credit.SubTotal = salesAmount;  // using the set property
                    credit.GetCreditInfo();
                    cashRegisterReceipt.Add(credit);
                }
                doAgain = ContinueLoop.Continue();
            }

            foreach (PaymentType cRR in cashRegisterReceipt)
            {
                Console.WriteLine($"{cRR.ToString()}");
            }

            Console.ReadKey();
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Chuck's exercise on Abstraction, Inheritance, Encapsulation and Polymorphism");
            Console.WriteLine("");
            Console.WriteLine("The user will have an opportunity to select the pay type they wish" +
                "\nand then enter the total amount of the sale." +
                "\nThen a subclass will be instantiated for that pay type." +
                "\nEach pay type will have additional prompts appropriate to that specific type");
        }

        static List<string> LoadPaymentOptions()
        {
            List<string> paymentOptions = new List<string>();

            paymentOptions.Add("Cash");
            paymentOptions.Add("Check");
            paymentOptions.Add("Credit Card");

            return paymentOptions;
        }

        static string GetMenuSelection(List<string> PaymentOptions)
        {
            int optionSelected = 0;     // initialize 
            bool result = false;        // initilize the while loop variable
            while (result == false)
            {
                Console.WriteLine("\nPlease select one of the following: 1 (cash), 2 (check), 3 (credit card) ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out optionSelected))
                {
                    if (optionSelected >= 1 && optionSelected <= PaymentOptions.Count)
                        result = true;
                }
                else
                {
                    Console.WriteLine($"\nPlease enter a number from 1 to {PaymentOptions.Count}");
                }
            }
            return PaymentOptions[optionSelected - 1];
        }

        public static decimal GetSalesAmount()
        {
            decimal salesAmount;        // initialize 
            bool result = false;        // initilize the while loop variable
            while (result == false)
            {
                Console.Write("\nPlease enter the total amount of the sale: ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out salesAmount))
                {
                    if (salesAmount > 0)
                    {
                        return salesAmount;
                    }
                }
                else
                {
                    Console.WriteLine($"\nThat was not a valid sales amount.");
                }
            }
            return 0.00M;
        }
    }
}
