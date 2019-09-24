using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindODataServiceNetCoreClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //NorthwindModel.NorthwindEntities entities = new NorthwindModel.NorthwindEntities(new Uri("https://services.odata.org/V3/Northwind/Northwind.svc"));
            //IAsyncResult asyncResult;
            //asyncResult = entities.Customers.BeginExecute((ar) =>
            //{
            //    var customers = entities.Customers.EndExecute(ar).ToArray();
            //    Console.WriteLine("{0} customers in the service found.", customers.Length);
            //}, null);
            //WaitHandle.WaitAny(new[] { asyncResult.AsyncWaitHandle });

            //Console.ReadLine();

            NorthwindModel.NorthwindEntities entities = new NorthwindModel.NorthwindEntities(new Uri("https://services.odata.org/V3/Northwind/Northwind.svc"));
            var taskFactory = new TaskFactory<IEnumerable<NorthwindModel.Customer>>();
            var customers = (await taskFactory.FromAsync(entities.Customers.BeginExecute(null, null), iar => entities.Customers.EndExecute(iar))).ToArray();
            Console.WriteLine("{0} customers in the service found.", customers.Length);

            Console.ReadLine();
        }
    }
}
