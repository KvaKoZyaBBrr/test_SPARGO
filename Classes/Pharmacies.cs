using Service;
using System;
using System.Collections.Generic;
using System.Data;

namespace Classes
{
    /// <summary>
    /// Список аптек
    /// Создан как модель данных продуктов, чтобы не плодить запросы в main
    /// не учтены:
    /// -ошибки подключения
    /// -статусы команд
    /// -синхронизаторы с с бд по таймеру/циклу/событию
    /// есть DRY по всем спискам. TODO DRY
    /// </summary>
    class Pharmacies
    {
        List<Pharmacy> pharmacies = new List<Pharmacy>();
        // синглтон, так как не нужно плодить списки
        static Pharmacies instance;

        private Pharmacies()
        {
            // заполним при создании
            updateList();
        }

        public static Pharmacies getInstance()
        {
            if (instance == null)
                instance = new Pharmacies();
            return instance;
        }

        public List<Pharmacy> getList()
        {
            return pharmacies;
        }

        public void addNewInstance(Pharmacy pharmacy)
        {
            string query = $"INSERT INTO [dbo].[Pharmacies] ([id],[Name],[Address], [Phone]) VALUES ('{pharmacy.id}', '{pharmacy.Name}', '{pharmacy.Address}', '{pharmacy.Phone}')";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        public void deleteInstance(int index)
        {
            string query = $"DELETE FROM [dbo].[Pharmacies] WHERE [id] = '{pharmacies[index].id}'";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        public void updateList()
        {
            pharmacies = SQLAdapter.getInstance().query<Pharmacy>("SELECT * FROM Pharmacies");
        }
    }

    ///<summary>
    /// Список аптек (минимальный набор полей: id аптеки, наименование, адресс, телефон)
    ///</summary>
    class Pharmacy{
        //гуиды не меняем
        public Guid id {get;}
        //изменяемые параметры аптеки
        public string Name {get;set;}
        public string Address {get;set;}
        //аптека может работать без номера, обработаем null (можно и nullable)
        string _phone;
        public string Phone {get{return _phone;} set{ _phone = (value == null)?"":value;  }}

        //конструктор
        public Pharmacy(string name, string address, string phone = ""){
            id = Guid.NewGuid();
            Name = name;
            Address = address;
            Phone = phone;
        }
        //конструктор для каста
        public Pharmacy(IDataRecord data)
        {
            id = Guid.Parse(data[0].ToString());
            Name = (data[1] != null) ? data[1].ToString() : "-";
            Address = (data[2] != null) ? data[2].ToString() : "-";
            Phone = (data[3] != null) ? data[3].ToString() : "-";
        }

        public override string ToString()
        {
            return $"{Name}|{Address}|{Phone}:({id})";
        }
    }
}