using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Service
{
    class SQLAdapter
    {
        //Инициализируем подключение
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DBTestPharmacy;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        //синглтон
        static SQLAdapter _instance;
        private SQLAdapter()
        {
            connection.Open();
        }

        public static SQLAdapter getInstance()
        {
            if (_instance == null)
            {
                _instance = new SQLAdapter();
            }
            return _instance;
        }

        //закрываемся на деструкторе
        ~SQLAdapter()
        {
            connection.Close();
        }

        /// <summary>
        /// Команда без возврата
        /// </summary>
        /// <param name="query">запрос</param>
        public void command(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Запросим данные из БД
        /// </summary>
        /// <typeparam name="T">Тип по факту для каста данных в объект (для этого в объекте должны быть реализованы конструкторы с IData)</typeparam>
        /// <param name="query">запрос</param>
        /// <returns></returns>
        public List<T> query<T>(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            //реализуем 
            SqlDataReader reader = command.ExecuteReader();
            List<T> result = new List<T>();
            while (reader.Read())
            {
                result.Add((T)Activator.CreateInstance(typeof(T), reader));
            }
            reader.Close();
            return result;
        }

    }
}
