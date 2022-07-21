using Classes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Service
{
    internal class CustomFunctions
    {
        public static void getCountOfProducts() {
            //выбираем аптеку
            Console.WriteLine("Exists Pharmacy");
            Pharmacies.getInstance().printList();
            Console.WriteLine("Choose index of Pharmacy");
            string commandString = Console.ReadLine();
            int PharmIndex = -1;
            if (int.TryParse(commandString, out PharmIndex))
            {
                //отправляем запрос
                List<ProductRow> productRows = SQLAdapter.getInstance().query<ProductRow>(@$"select [Products].[Name], [RawSum].[sumCount] from [Products] right join
                                                                (select[Batches].[Product_id] as prodId, SUM([Batches].[Count]) as sumCount
                                                                    from[Batches]
                                                                    where[Batches].[Storage_id] in
                                                                        (select[Storages].[id]
                                                                            from[Storages]
                                                                            where[Storages].[Pharmacy_id] = '{Pharmacies.getInstance().getList()[PharmIndex].id}')
                                                                    group by[Batches].[Product_id]) as [RawSum] on[Products].[id] =[RawSum].prodId");
                //если есть данные -выводим
                if (productRows.Count == 0)
                {
                    Console.WriteLine("No Data");
                    return;
                }
                foreach (ProductRow pr in productRows)
                    Console.WriteLine(pr.ToString());
            }
            else
            {
                Console.WriteLine("Errof choose");
            }



            
        }

        /// <summary>
        /// класс-болванка для каста строк
        /// </summary>
        class ProductRow {
            string ProductName;
            int count;
            public ProductRow(IDataRecord dataRecord) {
                ProductName = dataRecord[0].ToString();
                int _count = 0;
                int.TryParse(dataRecord[1].ToString(), out _count);
                count= _count;
            }

            public override string ToString()
            {
                return $"{ProductName}:{count}";
            }
        }
    }
}
