using System;

namespace Classes
{
    ///<summary>
    /// Список партий (минимальный набор полей: id партии, id товара, id склада, количество в партии)
    ///</summary>
    class Batch{
        //гуиды не меняем
        Guid id{get;}
        //партия характеризуется также и продуктом и складом. Поэтому их тоже не меняем
        Guid Product_id{get;}
        Guid Storage_id{get;}
        //количество в партии
        int Count {get;set;}
        
        //конструктор
        public Batch(Guid product_id, Guid storage_id, int count){
            id = new Guid();
            Product_id = product_id;
            Storage_id = storage_id;
            Count = count;
        }
    }
}