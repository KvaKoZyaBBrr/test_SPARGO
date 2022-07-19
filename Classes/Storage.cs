using System;

namespace Classes
{
    ///<summary>
    /// Список складов (минимальный набор полей: id склада, id аптеки, наименование)
    ///</summary>
    class Storage{
        //гуиды не меняем
        Guid id{get;}    
        // склад привязываем к аптеке и не меняем
        Guid Pharmacy_id{get;}
        //имя менять можем
        string Name{get;set;}

        //конструктор
        public Storage(Guid pharmacy_id, string name){
            id = new Guid();
            Pharmacy_id = pharmacy_id;
            Name = name;        
        }
    }
}