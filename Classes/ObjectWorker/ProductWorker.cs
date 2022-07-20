using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ObjectWorker
{
    /// <summary>
    /// Класс-обработчик списка продуктов
    /// TODO. СРеди всех Worker-ов есть дублькод. TODO DRY
    /// </summary>
    class ProductWorker : IObjectWorker
    {
        public void CreateNew()
        {
            //вводим данные
            Console.WriteLine("Enter name of product");
            string name = Console.ReadLine();
            //проверяем на то что имя уникальное
            if (Products.getInstance().getList().Where(x => x.Name == name).Count() > 0)
            {
                Console.WriteLine($"{name} exists");
            }
            //добавляем объект в список
            Products.getInstance().addNewInstance(new Product(name));
            Console.WriteLine($"Product '{name} was added'");
        }

        public void DeleteOne()
        {
            //получаем список и проверяем на наличие
            List<Product> ps = Products.getInstance().getList();
            if (ps.Count() == 0)
            {
                Console.WriteLine("No products to delete");
            }
            else
            {
                //выводим список инстансов и выбираем нужный
                Console.WriteLine("Exists products:");
                for (int i = 0; i < ps.Count; i++)
                    Console.WriteLine($"{i}. {ps[i].ToString()}");
                Console.WriteLine("Choose index removable product");
                string commandString = Console.ReadLine();
                int target = 0;
                if (int.TryParse(commandString, out target) && target >= 0 && target < ps.Count)
                {
                    //удяаляем выбранный
                    Products.getInstance().deleteInstance(target);
                    Console.WriteLine($"Product {ps[target].Name} was deleted");
                }
                else
                {
                    Console.WriteLine("Err to del");
                }
            }
        }
    }
}
