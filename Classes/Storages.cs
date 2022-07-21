using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Classes
{
    /// <summary>
    /// Список товаров
    /// Создан как модель данных продуктов, чтобы не плодить запросы в main
    /// не учтены:
    /// -ошибки подключения
    /// -статусы команд
    /// -синхронизаторы с с бд по таймеру/циклу/событию
    /// есть DRY по всем спискам. TODO DRY
    /// </summary>
    class Storages:BaseList<Storage>
    {
        // синглтон, так как не нужно плодить списки
        static Storages instance;

        private Storages()
        {
            // заполним при создании
            updateList();
        }

        public static Storages getInstance()
        {
            if (instance == null)
                instance = new Storages();
            updateList();
            return instance;
        }

        public void addNewInstance(Storage newInstance)
        {
            string query = $"INSERT INTO [dbo].[Storages] ([id],[Pharmacy_id], [Name]) VALUES ('{newInstance.id}', '{newInstance.Pharmacy_id}', '{newInstance.Name}')";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        public void deleteInstance(int index)
        {
            string query = $"DELETE FROM [dbo].[Storages] WHERE [id] = '{list[index].id}'";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        private static void updateList()
        {
            list = SQLAdapter.getInstance().query<Storage>("SELECT * FROM Storages");
        }

    }


    ///<summary>
    /// Список складов (минимальный набор полей: id склада, id аптеки, наименование)
    ///</summary>
    class Storage{
        //гуиды не меняем
        public Guid id{get;}    
        // склад привязываем к аптеке и не меняем
        public Guid Pharmacy_id{get;}
        //имя менять можем
        public string Name{get;set;}

        //конструктор
        public Storage(Guid pharmacy_id, string name){
            id = Guid.NewGuid();
            Pharmacy_id = pharmacy_id;
            Name = name;        
        }

        //конструктор для каста
        public Storage(IDataRecord data)
        {
            id = Guid.Parse(data[0].ToString());
            Pharmacy_id = Guid.Parse(data[1].ToString());
            Name = (data[1] != null) ? data[2].ToString() : "-";
        }

        public override string ToString()
        {
            Pharmacy pharmacy = Pharmacies.getInstance().getList().Where(x => x.id == Pharmacy_id).FirstOrDefault();
            string pharmName = (pharmacy == null) ? "-" : pharmacy.Name;
            return $"{Name}:{pharmName} ({id})";
        }
    }
}