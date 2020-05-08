using System;
using System.Collections.Generic;
using System.Text;

//https://www.tutorialsteacher.com/ioc/dependency-injection

namespace DIAndStrategyPattern
{

    class ConstructorInjections
    {
        public class CustomerBusinessLogic
        {
            ICustomerDataAccess _dataAccess;
            public CustomerBusinessLogic(ICustomerDataAccess custDataAccess)
            {
                _dataAccess = custDataAccess;
            }

            public CustomerBusinessLogic()
            {
                _dataAccess = new CustomerDataAccess();
            }

            public string ProcessCustomerData(int id)
            {
                return _dataAccess.GetCustomerName(id);
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
                //get the customer name from the db in real application        
                return "Dummy Customer Name";
            }
        }

        public class CustomerService
        {
            CustomerBusinessLogic _customerBL;

            public CustomerService()
            {
                _customerBL = new CustomerBusinessLogic(new CustomerDataAccess());
            }

            public string GetCustomerName(int id)
            {
                return _customerBL.ProcessCustomerData(id);
            }
        }
    }


}
