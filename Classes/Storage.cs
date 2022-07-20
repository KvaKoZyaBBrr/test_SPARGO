using System;

namespace Classes
{
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
    }
}