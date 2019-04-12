using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarFactoryService
{
    [ServiceContract]
    public interface IService
    {
        #region GetData
        [OperationContract]
        List<Service.Customer> GetAllCustomers();

        [OperationContract]
        Service.Customer GetCustomerById(int Id);

        [OperationContract]
        List<Service.Product> GetAllProducts();

        [OperationContract]
        Service.Product GetProductById(int id);

        [OperationContract]
        List<Service.Order> GetAllOrders();

        [OperationContract]
        Service.Order GetOrderById(int id);

        [OperationContract]
        List<Service.Education> GetAllEducations();

        
        #endregion

        #region SaveData
        [OperationContract]
        void InsertCustomer(Service.Customer customer);

        [OperationContract]
        void InsertProduct(Service.Product product);

        [OperationContract]
        void InsertOrder(Service.Order order);

        [OperationContract]
        void UpdateCustomers(Service.Customer customer);

        [OperationContract]
        void UpdateProducts(Service.Product product);

        [OperationContract]
        void UpdateOrders(Service.Order order);
        #endregion

    }
}
