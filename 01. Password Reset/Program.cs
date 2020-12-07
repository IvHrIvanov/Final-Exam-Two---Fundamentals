using System;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(" ");

            while (commands[0] != "Done")
            {
                switch (commands[0])
                {
                    case "TakeOdd":
                        password = TakeOdd(password);
                        break;
                }


            }



        }

        private static string TakeOdd(string password)
        {
            string newPass = string.Empty;

            for (int i = 0; i < password.Length; i++)
            {
                if (i % 2 == 1)
                {
                    newPass += password[i];
                }
            }

            return password;
        }
    }
}