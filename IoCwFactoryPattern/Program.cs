using System;

namespace IoCwFactoryPattern
{
    //This is a simple implementation of IoC and the first step towards achieving fully loose coupled design.
    //As mentioned in the previous chapter, we will not achieve complete loosely coupled classes by only using IoC. 
    //Along with IoC, we also need to use DIP, Strategy pattern, and DI(Dependency Injection). 
    //https://www.tutorialsteacher.com/ioc/inversion-of-control
    //DIP = Dependency Inversion Principle NO es Dependency Injection Principle 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class CustomerBusinessLogic
        {
            public CustomerBusinessLogic()
            {
            }

            public string GetCustomerName(int id)
            {
                DataAccess _dataAccess = DataAccessFactory.GetDataAccessObj();

                return _dataAccess.GetCustomerName(id);
            }
        }

        public class DataAccess
        {
            public DataAccess()
            {
            }

            public string GetCustomerName(int id)
            {
                return "Dummy Customer Name"; // get it from DB in real app
            }
        }
        public class DataAccessFactory
        {
            public static DataAccess GetDataAccessObj()
            {
                return new DataAccess();
            }
        }
    }
}

//In the above example, we implemented the factory pattern to achieve IoC. But, the CustomerBusinessLogic 
//class uses the concrete DataAccess class.  Therefore, it is still tightly coupled, even though we have 
//inverted the dependent object creation to the factory class. Let's use DIP on the CustomerBusinessLogic 
//and DataAccess classes and make them more loosely coupled. 
//              DIPoverCustomerBussinesLogicClass Proyect in this Solution