using System;
using System.Text;

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
                StringBuilder sb = new StringBuilder();

                switch (commands[0])
                {
                    case "TakeOdd":

                        password = TakeOdd(password);

                        sb.Append(password);
                        break;

                    case "Cut":

                        int firstIndex = int.Parse(commands[1]);
                        int secondIndex = int.Parse(commands[2]);

                        password = CutPass(password, firstIndex, secondIndex);

                        sb.Append(password);
                        break;

                    case "Substitute":
                        if(password.Contains(commands[1]))
                        {
                            password = Subtitute(password, commands[1], commands[2]);
                            sb.Append(password);
                        }
                        else
                        {
                            sb.Append("Nothing to replace!");
                        }
                        break;
                }

                Console.WriteLine(sb);

                commands = Console.ReadLine().Split(" ");
            }

            Console.WriteLine($"Your password is: {password}");

        }

        private static string Subtitute(string password, string forReplace, string replace)
        {
            password = password.Replace(forReplace, replace);
            return password;
        }

        private static string CutPass(string password, int firstIndex, int secondIndex)
        {

           password= password.Substring(0,firstIndex)+password.Substring(firstIndex+secondIndex);
            return password;
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
            password = newPass;
            return password;
        }
    }
}