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
    class Batches: BaseList<Batch>
    {
        // синглтон, так как не нужно плодить списки
        static Batches instance;

        private Batches()
        {
            // заполним при создании
            updateList();
        }

        public static Batches getInstance()
        {
            if (instance == null)
                instance = new Batches();
            updateList();
            return instance;
        }

        public void addNewInstance(Batch newInstance)
        {
            string query = $"INSERT INTO [dbo].[Batches] ([id],[Product_id], [Storage_id], [Count]) VALUES ('{newInstance.id}', '{newInstance.Product_id}', '{newInstance.Storage_id}', '{newInstance.Count}')";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        public void deleteInstance(int index)
        {
            string query = $"DELETE FROM [dbo].[Batches] WHERE [id] = '{list[index].id}'";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        private static void updateList()
        {
            list = SQLAdapter.getInstance().query<Batch>("SELECT * FROM Batches");
        }

    }

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
        int _count=0;
        public int Count {get{return _count; } set{_count =  (value<0)? _count = 0:_count = value;}}
        
        //конструктор
        public Batch(Guid product_id, Guid storage_id, int count){
            id = Guid.NewGuid();
            Product_id = product_id;
            Storage_id = storage_id;
            Count = count;
        }
        //конструктор для каста
        public Batch(IDataRecord data)
        {
            id = Guid.Parse(data[0].ToString());
            Product_id = Guid.Parse(data[1].ToString());
            Storage_id = Guid.Parse(data[2].ToString());
            int value = 0;
            int.TryParse(data[3].ToString(),out value);
            Count = value;
        }

        public override string ToString()
        {
            return $"{Storages.getInstance().getList().Where(x => x.id == Storage_id).FirstOrDefault().Name} : {Products.getInstance().getList().Where(x => x.id == Product_id).FirstOrDefault().Name} = {Count}: ({id})";
        }
    }
}