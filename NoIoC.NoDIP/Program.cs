using System;

namespace NoIoC.NoDIP
{
    //https://www.tutorialsteacher.com/ioc/introduction

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class CustomerBusinessLogic
        {
            DataAccess _dataAccess;
            public CustomerBusinessLogic()
            {
                _dataAccess = new DataAccess();
            }

            public string GetCustomerName(int id)
            {
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
    }
}
