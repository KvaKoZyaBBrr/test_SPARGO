using System;
using Classes.ObjectWorker;
using Service;

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

            IObjectWorker productFactory = new ProductWorker();
            IObjectWorker pharmacyFactory = new PharmacyWorker();
            IObjectWorker storageFactory = new StorageWorker();
            IObjectWorker batchFactory = new BatchWorker();

            switch (command){
                case(1):{
                        productFactory.CreateNew();
                        break;
                    }
                case(2):{
                        productFactory.DeleteOne();
                        break;
                    }
                case(3):
                    {
                        pharmacyFactory.CreateNew();
                        break;
                    }
                case (4):
                    {
                        pharmacyFactory.DeleteOne();
                        break;
                    }
                case (5):
                    {
                        storageFactory.CreateNew();
                        break;
                    }
                case (6):
                    {
                        storageFactory.DeleteOne();
                        break;
                    }
                case (7):
                    {
                        batchFactory.CreateNew();
                        break;
                    }
                case (8):
                    {
                        batchFactory.DeleteOne();
                        break;
                    }
                case (9):
                    {
                        CustomFunctions.getCountOfProducts(); 
                        break;
                    }

            }
        }
    }
}
