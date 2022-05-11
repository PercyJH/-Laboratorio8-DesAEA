using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            //IntroToLINQ();
            //DataSource();
            //Filtering();
            //Ordering();
            //Grouping();
            //Grouping2();
            //Joinning();

            //IntroToLINQLambda();
            //DataSourceLambda();
            //FilteringLambda();
            //OrderingLambda();
            //GroupingLambda();
            //Grouping2Lambda();
            //JoinningLambda();
            //Console.Read();

        }
        static void IntroToLINQLambda()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery = numbers.Where(x => (x % 2 == 0)).Select(x => x).ToList();

            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }
        static void DataSourceLambda()
        {
            var queryAllCustomers = context.clientes.Select(c=>c);

            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }
        static void FilteringLambda()
        {
            var queryLondonCustomers = context.clientes.Where(c =>c.Ciudad=="Londres").Select(c =>c);

            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }
        static void OrderingLambda()
        {
            var queryLondonCustomers = context.clientes.Where(
                c=> c.Ciudad=="Londres").OrderBy(c=> c.NombreCompañia).Select(c=> c);

            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }
        static void GroupingLambda()
        {
            IQueryable<IGrouping<string, clientes>> queryCustomersByCity = 
                context.clientes.GroupBy(c=> c.Ciudad).Select(c=> c);

            foreach (var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes customer in customerGroup)
                {
                    Console.WriteLine($"{customer.NombreCompañia}");
                }
            }
        }
        static void Grouping2Lambda()
        {
            var custQuery = context.clientes.GroupBy(
                c=> c.Ciudad).Where(c=> c.Count() > 2).OrderBy(c=> c.Key).Select(c=> c);
            foreach (var item in custQuery)
            {
                Console.WriteLine(item.Key);
                foreach (clientes customer in item)
                {
                    Console.WriteLine($"{customer.NombreCompañia}");
                }
            }
        }
        static void JoinningLambda()
        {
            var innerJoinQuery = context.clientes.Join(
                context.Pedidos, c=> c.idCliente,p=> p.IdCliente, (c, p) => new 
                    {   CustomerName = c.NombreCompañia,
                        DistributorName = p.PaisDestinatario
                    });

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }
    }
}
