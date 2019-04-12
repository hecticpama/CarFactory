using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Data;
using CarFactoryService;
using CarFactoryService.Service;
using CarFactoryService.DataAccess;

namespace CarFactoryService.Business_Logic
{
    public class GetDataLogic
    {
        public string connectionName;

        DBConnection db = new DBConnection();
      


        public List<Service.Product> GetAllProducts()
        {
            DataAccess.ProductRepository repo = new DataAccess.ProductRepository();
            return repo.GetAllProduct();
        }

        public Product GetProductById(int id)
        {
            ProductRepository repo = new ProductRepository();
            return repo.GetProductById(id);
        }

        public void SaveProduct(Product product)
        {
            ProductRepository repo = new ProductRepository();
            repo.InsertProduct(product);
        }

        public void SaveCustomer(Customer customer)
        {
            CustomerRespository repo = new CustomerRespository();
            repo.InsertCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            CustomerRespository repo = new CustomerRespository();
            repo.UpdateCustomer(customer);
        }

        public void UpdateProduct(Product product)
        {
            ProductRepository repo = new ProductRepository();
            repo.UpdateProduct(product);
        }

        public List<Order> GetAllOrders()
        {
            OrderRepository repo = new OrderRepository();
            return repo.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            OrderRepository repo = new OrderRepository();
            return repo.GetOrderById(id);
        }

        public void SaveOrder(Order orders)
        {
            OrderRepository repo = new OrderRepository();
            repo.InsertOrder(orders);
        }

        public void UpdateOrder(Order orders)
        {
            OrderRepository repo = new OrderRepository();
            repo.UpdateOrder(orders);
        }

        public List<Customer> GetAllCustomers()
        {
            CustomerRespository repo = new CustomerRespository();
            return repo.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            CustomerRespository repo = new CustomerRespository();
            return repo.GetCustomerById(id);
        }

        public List<Education> GetAllEducation()
        {
            EducationRepository repo = new EducationRepository();
            return repo.GetAllQualification();
        }

        public List<Occupation> GetAllOccupation()
        {
            OccupationRepository repo = new OccupationRepository();
            return repo.GetAllOccupation();
        }

        public List<Suburb> GetAllSuburbs()
        {
            SuburbRepository repo = new SuburbRepository();
            return repo.GetAllSuburbs();
        }
    }
}
