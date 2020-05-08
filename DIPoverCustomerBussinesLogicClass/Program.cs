using System;

namespace DIPoverCustomerBussinesLogicClass
{
    //We have implemented DIP in our example where a high-level module(CustomerBusinessLogic) and 
    //low-level module(CustomerDataAccess) are dependent on an abstraction(ICustomerDataAccess). Also, 
    //the abstraction(ICustomerDataAccess) does not depend on details(CustomerDataAccess), 
    //but the details depend on the abstraction
    // https://www.tutorialsteacher.com/ioc/dependency-inversion-principle
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class CustomerBusinessLogic
        {
            ICustomerDataAccess _custDataAccess;

            public CustomerBusinessLogic()
            {
                _custDataAccess = DataAccessFactory.GetCustomerDataAccessObj();
            }

            public string GetCustomerName(int id)
            {
                return _custDataAccess.GetCustomerName(id);
            }
        }

        public interface ICustomerDataAccess
        {
            string GetCustomerName(int id);
        }

        public class CustomerDataAccess : ICustomerDataAccess
        {
            public CustomerDataAccess()
            {
            }

            public string GetCustomerName(int id)
            {
                return "Dummy Customer Name";
            }
        }

        public class DataAccessFactory
        {
            public static ICustomerDataAccess GetCustomerDataAccessObj()
            {
                return new CustomerDataAccess();
            }
        }

    }
}

//The advantages of implementing DIP in the above example is that the CustomerBusinessLogic and CustomerDataAccess 
//classes are loosely coupled classes because CustomerBusinessLogic does not depend on the concrete DataAccess class, 
//instead it includes a reference of the ICustomerDataAccess interface. So now, we can easily use another class 
//which implements ICustomerDataAccess with a different implementation.

//Still, we have not achieved fully loosely coupled classes because the CustomerBusinessLogic class includes a factory 
//class to get the reference of ICustomerDataAccess.This is where the Dependency Injection pattern helps us. 
//In the project
//                              DIAndStrategyPattern
//we will learn how to use the Dependency Injection(DI) and the Strategy pattern using the above example. 