using System;
using System.Linq;

namespace CreditCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your ID code: ");
            string usersID = Console.ReadLine();
            if (Validation(usersID))
            {
                if (GetAge(usersID))
                {
                    HelloUser(usersID);
                    Console.WriteLine("Enter your credit card number:");
                    string creditcardNum = Console.ReadLine();
                    if (CreditCardNumValidation(creditcardNum))
                    {
                        Console.WriteLine("Please enter your CVV code on the back of your credit card");
                        string userCVV = Console.ReadLine();
                        if (CVVcode(userCVV) == true)                        
                            Console.WriteLine("Your card has been accepted.");
                        else
                            Console.WriteLine("Your card has been declined.");
                    }
                    else
                    {
                        Console.WriteLine("Your credit card number is invalid.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong format for the ID card, try again.");
            }



        }

        
        public static bool Validation(string idCode)
        {
            if (idCode.Length == 11)
            {
                try
                {
                    long.Parse(idCode);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public static void HelloUser(string idCode)
        {
            int firstNum = Int32.Parse(idCode[0].ToString());
            if (firstNum == 1 || firstNum == 3 || firstNum == 5)
            {
                Console.WriteLine("Hello sir!");
            }
            else if (firstNum == 2 || firstNum == 4 || firstNum == 6)
            {
                Console.WriteLine("Hello madam!");
            }

        }

        public static bool GetAge(string idCode)
        {
            string getYear = idCode.Substring(1, 2);

            if ((int.Parse(idCode[0].ToString()) > 4 && getYear == "01" || getYear == "02"))
            {
                Console.WriteLine("Welcome.");
                return true;
            }else
            {
                Console.WriteLine("You are not authorized to use a credit card yet.");
                return false;
            }
        }

        public static bool CreditCardNumValidation(string creditcardNum)
        {
            if (creditcardNum.Length == 16 && creditcardNum.All(char.IsDigit))
            {
                return true;
                /*try
                {
                    long.Parse(creditcardNum);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }*/

            }
            else
            {
                return false;
            }

        }

        public static bool CVVcode(string userCVV)
        {

            if (userCVV.Length == 3)
            {
                try
                {
                    int.Parse(userCVV);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong format");
                    return false;
                }

            }else
            {
                Console.WriteLine($"Wrong format");
                return false;
            }

        }


    }
}
