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
    public class ProductRepository
    {
        public string connectionName;

        DBConnection dbc = new DBConnection();

        public string connect = null;
        
        #region GetAllProduct
        public List<Product> GetAllProduct()
        {
            connectionName = dbc.ConnectDB(connect);

            List<Service.Product> productList = new List<Service.Product>();
            using (SqlConnection conn = new SqlConnection(connectionName))
            {
              
                SqlCommand cmd = new SqlCommand("GetAllProducts",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Service.Product product = new Service.Product();

                        product.IdProduct = Convert.ToInt32(dr["IdProduct"]);
                        product.Name = dr["Name"].ToString();
                        product.Price = Convert.ToDouble(dr["Price"]);

                        productList.Add(product);
                    }
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error");
                }

                finally
                {
                    conn.Close();
                }

                return productList;
            }

        }
        #endregion

        #region GetProductById
        public Service.Product GetProductById(int id)
        {
            connectionName = dbc.ConnectDB(connect);
            Service.Product product = new Service.Product();

            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                SqlCommand cmd = new SqlCommand("GetProductById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProduct",id);

                try
                {
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        product.IdProduct = Convert.ToInt32(dr["IdProduct"]);
                        product.Name = dr["Name"].ToString();
                        product.Price = Convert.ToDouble(dr["Price"]);
                                           
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

            return product;
        }
        #endregion

        #region SaveProduct
        public void InsertProduct(Product product)
        {
            connectionName = dbc.ConnectDB(connect);
            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("InsertProducts",conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name",SqlDbType.VarChar).Value = product.Name;
                    cmd.Parameters.Add("@Price",SqlDbType.VarChar).Value = product.Price;


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

        #region Update Product
        public void UpdateProduct(Product product)
        {
            connectionName = dbc.ConnectDB(connect);

            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UpdateProducts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdProduct", SqlDbType.Int).Value = product.IdProduct;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                    cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = product.Price;
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
