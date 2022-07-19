using System;
using Classes;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                makeMenu();
                string commandString = Console.ReadLine();
                int command=0;
                if(!int.TryParse(commandString, out command))
                    continue;
                if (command == 0)
                    return;
                makeAction(command);
                Console.ReadLine();
            }
        }

        static void makeMenu()
        {
            Console.WriteLine("My PharmTech");
            Console.WriteLine("Choose command:");
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Delete Product");
            Console.WriteLine("3. Create Pharmacy");
            Console.WriteLine("4. Delete Pharmacy");
            Console.WriteLine("5. Create Storage");
            Console.WriteLine("6. Delete Storage");
            Console.WriteLine("7. Create Batch");
            Console.WriteLine("8. Delete Batch");
            Console.WriteLine("9. Get All Products by Pharmacy");
            Console.WriteLine("0. Exit");
        }

        static void makeAction(int command){
            switch(command){
                case(1):{Console.WriteLine("Command 1. TODO"); break;}
                case(2):{Console.WriteLine("Command 2. TODO"); break;}
                case(3):{Console.WriteLine("Command 3. TODO"); break;}
                case(4):{Console.WriteLine("Command 4. TODO"); break;}
                case(5):{Console.WriteLine("Command 5. TODO"); break;}
                case(6):{Console.WriteLine("Command 6. TODO"); break;}
                case(7):{Console.WriteLine("Command 7. TODO"); break;}
                case(8):{Console.WriteLine("Command 8. TODO"); break;}
                case(9):{Console.WriteLine("Command 9. TODO"); break;}

            }
        }
    }
}
