using System;
using System.Collections.Generic;
using System.Text;

namespace DIAndStrategyPattern
{
    //In the method injection, dependencies are provided through methods.This method can be a class method or an interface method.
    //The following example demonstrates the method injection using an interface based method.
    class MethodInjection
    {
        interface IDataAccessDependency
        {
            void SetDependency(ICustomerDataAccess customerDataAccess);
        }

        public class CustomerBusinessLogic : IDataAccessDependency
        {
            ICustomerDataAccess _dataAccess;

            public CustomerBusinessLogic()
            {
            }

            public string GetCustomerName(int id)
            {
                return _dataAccess.GetCustomerName(id);
            }

            public void SetDependency(ICustomerDataAccess customerDataAccess)
            {
                _dataAccess = customerDataAccess;
            }
        }

        public class CustomerService
        {
            CustomerBusinessLogic _customerBL;

            public CustomerService()
            {
                _customerBL = new CustomerBusinessLogic();
                ((IDataAccessDependency)_customerBL).SetDependency(new CustomerDataAccess());
            }

            public string GetCustomerName(int id)
            {
                return _customerBL.GetCustomerName(id);
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
    }
}
