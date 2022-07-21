using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ObjectWorker
{
    internal class StorageWorker : IObjectWorker
    {
        public void CreateNew()
        {
            int pharmacyCount = Pharmacies.getInstance().getList().Count;
            if (pharmacyCount == 0)
            {
                Console.WriteLine("No Pharmacy to Storage");
                return;
            }
            //вводим данные
            Console.WriteLine("Enter name of Storage");
            string name = Console.ReadLine();
            if (Storages.getInstance().getList().Where(x => x.Name == name).Count() > 0)
            {
                Console.WriteLine($"{name} exists");
                return;
            }

            //выводим список инстансов и выбираем нужный
            Console.WriteLine("Choose index of Pharmacy");
            Pharmacies.getInstance().printList();
                
            string commandString = Console.ReadLine();
            int target = 0;
            if (int.TryParse(commandString, out target) && target >= 0 && target < pharmacyCount)
            {
                Storages.getInstance().addNewInstance(new Storage(Pharmacies.getInstance().getList()[target].id, name));
                Console.WriteLine($"Storage {name} was added");
            }
            else
            {
                Console.WriteLine("Err to choose pharmacy");
            }
        }

        public void DeleteOne()
        {
            //получаем список и проверяем на наличие
            int storageCount = Storages.getInstance().getList().Count;
            if (storageCount == 0)
            {
                Console.WriteLine("No Storage to delete");
                return;
            }

            //выводим список инстансов и выбираем нужный
            Console.WriteLine("Exists Storages:");
            Storages.getInstance().printList();
            Console.WriteLine("Choose index removable Storage");
            string commandString = Console.ReadLine();
            int target = 0;
            if (int.TryParse(commandString, out target) && target >= 0 && target < storageCount)
            {
                //удяаляем выбранный
                Storages.getInstance().deleteInstance(target);
                Console.WriteLine($"Storage #{target} was deleted");
            }
            else
            {
                Console.WriteLine("Err to del");
            }
        }
    }
}
