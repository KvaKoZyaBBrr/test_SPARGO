using System;

namespace Classes
{
    ///<summary>
    /// Список аптек (минимальный набор полей: id аптеки, наименование, адресс, телефон)
    ///</summary>
    class Pharmacy{
        //гуиды не меняем
        Guid id {get;}
        //изменяемые параметры аптеки
        string Name {get;set;}
        string Address {get;set;}
        string Phone {get;set;}

        //конструктор
        public Pharmacy(string name, string address, string phone){
            id = new Guid();
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}