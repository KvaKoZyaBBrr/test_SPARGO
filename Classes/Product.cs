using System;

namespace Classes
{
    ///<summary>
    /// Список товарных наименований (минимальный набор полей: id товара, наименование)
    ///</summary>
    class Product{
        //гуиды не меняем
        public Guid id {get;}
        //имя может измениться
        public string Name {get; set;}

        //конструктор
        public Product(string name){
            //определеяем 1 раз id
            id = new Guid();
            Name = name;
        }
    }
}