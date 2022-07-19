using System;

namespace Classes
{
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
        public string Phone {get{return _phone;} set{if (value == null) _phone = ""; }}

        //конструктор
        public Pharmacy(string name, string address, string phone = ""){
            id = new Guid();
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}