using System;
using System.Collections.Generic;
using System.Data;
using Service;

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
    class Products
    {
        List<Product> products = new List<Product>();
        // синглтон, так как не нужно плодить списки
        static Products instance;

        private Products(){
            // заполним при создании
            updateList();
        }

        public static Products getInstance(){
            if(instance==null)
                instance = new Products();
            return instance;
        }

        public List<Product> getList(){
            return products;
        }

        public void addNewInstance(Product product) {
            string query = $"INSERT INTO [dbo].[Products] ([id],[Name]) VALUES ('{product.id}', '{product.Name}')";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        public void deleteInstance(int index) {
            string query = $"DELETE FROM [dbo].[Products] WHERE [id] = '{products[index].id}'";
            SQLAdapter.getInstance().command(query);
            updateList();
        }

        public void updateList(){
            products = SQLAdapter.getInstance().query<Product>("SELECT * FROM Products");
        }
    }

    ///<summary>
    /// Список товарных наименований (минимальный набор полей: id товара, наименование)
    ///</summary>
    class Product
    {

        //гуиды не меняем
        public Guid id {get;}
        //имя может измениться
        public string Name {get; set;}

        //конструктор
        public Product(string name){
            //определеяем 1 раз id
            id = Guid.NewGuid();
            Name = name;
        }
        //конструктор для каста
        public Product(IDataRecord data) {
            id = Guid.Parse(data[0].ToString());
            Name = (data[1]!=null)?data[1].ToString():"-";
        }

        public override string ToString()
        {
            return $"{Name}:({id})";
        }
    }

    
}