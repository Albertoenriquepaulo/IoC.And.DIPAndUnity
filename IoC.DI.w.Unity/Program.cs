using System;
using Unity;
using Unity.Injection;

namespace IoC.DI.w.Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();

            objContainer.RegisterType<IDal, Oracle>();
            objContainer.RegisterType<IDal, SQLServer>("MsSQL");
            objContainer.RegisterType<IDal, PostgresSQL>("PostgresSQL");
            // Registers Customer type 
            objContainer.RegisterType<Customer>("MsSQLCustomer", new InjectionConstructor(objContainer.Resolve<IDal>("MsSQL")));
            objContainer.RegisterType<Customer>("PostgresSQLCustomer", new InjectionConstructor(objContainer.Resolve<IDal>("PostgresSQL")));

            Customer customer = objContainer.Resolve<Customer>();
            Customer customer1 = objContainer.Resolve<Customer>("MsSQLCustomer");
            Customer customer2 = objContainer.Resolve<Customer>("PostgresSQLCustomer");


            customer.Name = "Alberto";
            customer.Add();
        }

        class Customer
        {
            private IDal _database;
            public string Name { get; set; }

            public Customer(IDal database)
            {
                _database = database;
            }

            public bool Validate()
            {
                return true;
            }

            public void Add()
            {
                _database.Add();
            }
        }

        interface IDal
        {
            void Add();
        }

        class SQLServer : IDal
        {
            public void Add()
            {
                throw new NotImplementedException();
            }
        }
        class Oracle : IDal
        {
            public void Add()
            {
                throw new NotImplementedException();
            }
        }
        class PostgresSQL : IDal
        {
            public void Add()
            {
                throw new NotImplementedException();
            }
        }
    }


}
