using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Data;
using CarFactoryService.Service;

namespace CarFactoryService.DataAccess
{
    public class OrderRepository
    {
        public string connectionName;

        DBConnection dbc = new DBConnection();

        string connect = null;

        public List<Order> GetAllOrders()
        {
            connectionName = dbc.ConnectDB(connect);

            List<Order> orderList = new List<Order>();

            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                SqlCommand cmd = new SqlCommand("GetAllOrders",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                   conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        Order orders = new Order();

                        orders.IdOrder = Convert.ToInt32(dr["IdOrder"]);
                        orders.Quantity = Convert.ToInt32(dr["Quantity"]);
                        orders.IdCustomer = Convert.ToInt32(dr["IdCustomer"]);
                        orders.IdProduct = Convert.ToInt32(dr["IdProduct"]);
                        orders.CustomerName = dr["CustomerName"].ToString();
                        orders.ProductName = dr["ProductName"].ToString();
                        orders.OrderDate = Convert.ToDateTime(dr["OrderDate"]);

                        orderList.Add(orders);
                    }      

                }
                catch(Exception)
                {
                    throw new ApplicationException("error");
                }
                finally
                {
                    conn.Close();
                }
                return orderList;
            }
        }

          #region GetOrderById
        public Order GetOrderById(int id)
        {
            connectionName = dbc.ConnectDB(connect);
            Order orders = new Order();

            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                SqlCommand cmd = new SqlCommand("GetOrderById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrder",id);

                try
                {
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        orders.IdOrder = Convert.ToInt32(dr["IdOrder"]);
                        orders.Quantity = Convert.ToInt32(dr["Quantity"]);
                        orders.IdCustomer = Convert.ToInt32(dr["IdCustomer"]);
                        orders.IdProduct = Convert.ToInt32(dr["IdProduct"]);
                        orders.CustomerName = dr["CustomerName"].ToString();
                        orders.ProductName = dr["ProductName"].ToString();
                        orders.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                        
                    }
                    
                }
                catch (Exception)
                {

                }
                finally
                {
                    conn.Close();
                }

            }

            return orders;
        }
        #endregion

        #region Save Orders
        public void InsertOrder(Order orders)
        {
            connectionName = dbc.ConnectDB(connect);
            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("InsertOrder",conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCustomer",SqlDbType.Int).Value = orders.IdCustomer;
                    cmd.Parameters.Add("@IdProduct",SqlDbType.Int).Value = orders.IdProduct;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = orders.Quantity;
                    cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = orders.customer.Name;
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = orders.product.Name;
                    cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orders.OrderDate;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error");
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        #endregion

        #region Update Order
        public void UpdateOrder(Order orders)
        {
            connectionName = dbc.ConnectDB(connect);

            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UpdateOrder", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdOrder", SqlDbType.Int).Value = orders.IdOrder;
                    cmd.Parameters.Add("@IdCustomer", SqlDbType.Int).Value = orders.IdCustomer;
                    cmd.Parameters.Add("@IdProduct", SqlDbType.Int).Value = orders.IdProduct;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = orders.Quantity;
                    cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = orders.customer.Name;
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = orders.product.Name;
                    cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = orders.OrderDate;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    throw new ApplicationException("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        #endregion
        }
    }
}


