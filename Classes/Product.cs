using System;
using System.Data;
using System.Data.SqlClient;
using Service;

namespace Classes
{
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

        public Product(IDataRecord data) {
            id = Guid.Parse(data[0].ToString());
            Name = (data[1]!=null)?data[1].ToString():"-";

        }

        public void save() {
            string query = $"INSERT INTO [dbo].[Products] ([id],[Name]) VALUES ('{id}', '{Name}')";
            SQLAdapter.getInstance().command(query);
        }


        public void delete() {
            string query = $"DELETE FROM [dbo].[Products] WHERE [id] = '{id}'";
            SQLAdapter.getInstance().command(query);
        }

        public override string ToString()
        {
            return $"{Name}:({id})";
        }
    }

    
}