using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlTypes;
using System.Collections;
using System.Data;
using CarFactoryService.DataAccess;
using CarFactoryService.Business_Logic;
using CarFactoryService.Service;

namespace CarFactoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService
    {
      
        public List<Product> GetAllProducts()
        {  
            Business_Logic.GetDataLogic logic = new GetDataLogic();
            return logic.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            GetDataLogic logic = new GetDataLogic();
            return logic.GetProductById(id);
        }

        public void InsertProduct(Product product)
        {
            GetDataLogic logic = new GetDataLogic();
            logic.SaveProduct(product);
        }

        public void UpdateProducts(Product product)
        {
            GetDataLogic logic = new GetDataLogic();
            logic.UpdateProduct(product);
        }


        public List<Customer> GetAllCustomers()
        {
            GetDataLogic logic = new GetDataLogic();
            return logic.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            GetDataLogic logic = new GetDataLogic();
            return logic.GetCustomerById(id);
        }

        public void InsertCustomer(Customer customer)
        {
            GetDataLogic logic = new GetDataLogic();
            logic.SaveCustomer(customer);
        }

        public void UpdateCustomers(Customer customer)
        {
            GetDataLogic logic = new GetDataLogic();
            logic.UpdateCustomer(customer);
        }

        public List<Education> GetAllEducations()
        {
            GetDataLogic logic = new GetDataLogic();
            return logic.GetAllEducation();
        }

        public List<Order> GetAllOrders()
        {
            GetDataLogic logic = new GetDataLogic();
            return logic.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            GetDataLogic logic = new GetDataLogic();
            return logic.GetOrderById(id);
        }

        public void InsertOrder(Order order)
        {
            GetDataLogic logic = new GetDataLogic();
            logic.SaveOrder(order);
        }

        public void UpdateOrders(Order order)
        {
            GetDataLogic logic = new GetDataLogic();
            logic.UpdateOrder(order);
        }
      
    }
}
