using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ObjectWorker
{
    internal class BatchWorker : IObjectWorker
    {
        public void CreateNew()
        {
            int storagesCount = Storages.getInstance().getList().Count;
            int productsCount = Products.getInstance().getList().Count;

            if (storagesCount == 0)
            {
                Console.WriteLine("No Storage to Batch");
                return;
            }
            if (productsCount == 0)
            {
                Console.WriteLine("No Product to Batch");
                return;
            }
            //выводим список инстансов и выбираем нужный
            //сначала склады
            Console.WriteLine("Choose index of Storage");
            Storages.getInstance().printList();

            string commandString = Console.ReadLine();
            int targetStorage = 0;
            if (int.TryParse(commandString, out targetStorage) && targetStorage >= 0 && targetStorage < storagesCount)
            {
                //если склад выбран, то выбираем товар
                Console.WriteLine("Choose index of Product");
                Products.getInstance().printList();

                commandString = Console.ReadLine();
                int targetProduct = 0;
                if (int.TryParse(commandString, out targetProduct) && targetProduct >= 0 && targetProduct < productsCount)
                {
                    //если все норм, вводим количество и записываемся
                    Console.WriteLine("Enter count");
                    commandString = Console.ReadLine();
                    int count = 0;
                    int.TryParse(commandString, out count);
                    Batches.getInstance().addNewInstance(new Batch(Products.getInstance().getList()[targetProduct].id, Storages.getInstance().getList()[targetStorage].id, count));
                    Console.WriteLine($"New Batch was added");
                }
                else
                {
                    Console.WriteLine("Err to choose Product");
                }
            }
            else
            {
                Console.WriteLine("Err to choose Storage");
            }


        }

        public void DeleteOne()
        {
            //получаем список и проверяем на наличие
            List<Batch> list = Batches.getInstance().getList();
            if (list.Count() == 0)
            {
                Console.WriteLine("No Batch to delete");
                return;
            }
            //выводим список инстансов и выбираем нужный
            Console.WriteLine("Exists Batch:");
            Batches.getInstance().printList();
            Console.WriteLine("Choose index removable Batch");
            string commandString = Console.ReadLine();
            int target = 0;
            if (int.TryParse(commandString, out target) && target >= 0 && target < list.Count)
            {
                //удяаляем выбранный
                Batches.getInstance().deleteInstance(target);
                Console.WriteLine($"Batch # {target} was deleted");
            }
            else
            {
                Console.WriteLine("Err to del");
            }
        }
    }
}
