﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.ObjectWorker
{
    /// <summary>
    /// Класс-обработчик списка аптек
    /// TODO. СРеди всех Worker-ов есть дублькод. TODO DRY
    /// </summary>
    class PharmacyWorker : IObjectWorker
    {
        /// <summary>
        /// создать новый объект
        /// </summary>
        public void CreateNew()
        {
            //вводим данные
            Console.WriteLine("Enter name of pharmacy");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address of pharmacy");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone of pharmacy");
            string? phone = Console.ReadLine();
            //проверяем на то что имя уникальное
            if (Pharmacies.getInstance().getList().Where(x => x.Name == name).Count() > 0)
            {
                Console.WriteLine($"{name} exists");
            }
            //добавляем объект в список
            Pharmacies.getInstance().addNewInstance(new Pharmacy(name, address, phone));
            Console.WriteLine($"Pharmacy '{name} was added'");
        }

        /// <summary>
        /// удалить существующий объект
        /// </summary>
        public void DeleteOne()
        {
            int pharmacyCount = Pharmacies.getInstance().getList().Count;
            //получаем список и проверяем на наличие
            if (pharmacyCount == 0)
            {
                Console.WriteLine("No Pharmacy to delete");
                return;
            }
            //выводим список инстансов и выбираем нужный
            Console.WriteLine("Exists Pharmacies:");
            Pharmacies.getInstance().printList();
            Console.WriteLine("Choose index removable Pharmacy");
            string commandString = Console.ReadLine();
            int target = 0;
            if (int.TryParse(commandString, out target) && target >= 0 && target < pharmacyCount)
            {
                //удяаляем выбранный
                Pharmacies.getInstance().deleteInstance(target);
                Console.WriteLine($"Pharmacy #{target} was deleted");
            }
            else
            {
                Console.WriteLine("Err to del");
            }
        }
    }
}
