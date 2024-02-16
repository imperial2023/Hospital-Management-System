using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reset:
            // Log in System
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("=====================================");
            Logo.writelogo();
            Console.WriteLine("============================================");
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine("DATA MANAGEMENT & HEALTH INFORMATION SYSTEM");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("============================================");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("USERNAME:  ");
            string username = Console.ReadLine();
            Console.Write("PASSWORD:  ");
            string password = Console.ReadLine();

            if (username == "name" && password == "1234")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
               Main_Menu.writemenu();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Error!\n");
                Console.WriteLine("Press Y to Continue. Press N to Exit!");
                char ans = Convert.ToChar(Console.ReadLine());
                Console.Clear();
                if (ans == 'Y' || ans == 'y')
                {
                    goto Reset;
                }
                if (ans == 'N' || ans == 'n')
                {
                    Environment.Exit(0);
                }
            }
            Console.ReadLine();
            
        }
    }
}
