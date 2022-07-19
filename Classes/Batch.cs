using System;

namespace Classes
{
    ///<summary>
    /// Список партий (минимальный набор полей: id партии, id товара, id склада, количество в партии)
    ///</summary>
    class Batch{
        //гуиды не меняем
        public Guid id{get;}
        //партия характеризуется также и продуктом и складом. Поэтому их тоже не меняем
        public Guid Product_id{get;}
        public Guid Storage_id{get;}
        //количество в партии ограничиваем (можно и ulong, но надо писать обработчик ошибки)
        int _count;
        public int Count {get{return _count; } set{if (value<0) value = 0;}}
        
        //конструктор
        public Batch(Guid product_id, Guid storage_id, int count){
            id = new Guid();
            Product_id = product_id;
            Storage_id = storage_id;
            Count = count;
        }
    }
}