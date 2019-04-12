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
    public class CustomerRespository
    {
        public string connectionName;
        DBConnection dbc = new DBConnection();
        string connect = null;

        public List<Customer> GetAllCustomers()
        {
            connectionName = dbc.ConnectDB(connect);

            List<Customer> customerList = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                SqlCommand cmd = new SqlCommand("GetAllCustomers",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Customer customer = new Customer();

   
                        customer.IdCustomer = Convert.ToInt32(dr["IdCustomer"]);
                        customer.Name = dr["Name"].ToString();
                        customer.Address = dr["Address"].ToString();
                        customer.Phone = dr["Phone"].ToString();
                        customer.PostalCode = dr["PostalCode"].ToString();
                        customer.JobTitle = dr["Occupation"].ToString();
                        customer.Qualification = dr["Education"].ToString();
                        customer.SuburbName = dr["Suburb"].ToString();
                      
                        customerList.Add(customer);

                        
                    }
                }
                catch (Exception)
                {
                    throw new ApplicationException("error");
                }
                finally
                {
                    conn.Close();
                }
            }

            return customerList;
        }

        #region GetCustomersById
        public Customer GetCustomerById(int id)
        {
            connectionName = dbc.ConnectDB(connect);
            Customer customer = new Customer();

             using(SqlConnection conn = new SqlConnection(connectionName))
                {
                    SqlCommand cmd = new SqlCommand("GetCustomerById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("IdCustomer",id);
                    try
                      {
                          conn.Open();
                          SqlDataReader dr = cmd.ExecuteReader();

                          if (dr.Read())
                          {
                              customer.IdCustomer = Convert.ToInt32(dr["IdCustomer"]);
                              customer.Name = dr["Name"].ToString();
                              customer.Address = dr["Address"].ToString();
                              customer.PostalCode = dr["PostalCode"].ToString();
                              customer.Phone = dr["Phone"].ToString();
                              
                          }
                
                      }
                    catch (Exception ex)
                      {
                          throw new ApplicationException("error",ex);
                      }
                    finally
                      {
                          conn.Close();
                      }
                    return customer;
                }
        }
        #endregion

        #region Save Customer
        public void InsertCustomer(Customer customer)
        {
            connectionName = dbc.ConnectDB(connect);

            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("InsertCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = customer.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = customer.Address;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = customer.PostalCode;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = customer.Phone;
                    cmd.Parameters.Add("@IdEducation", SqlDbType.Int).Value = customer.IdEducation;
                    cmd.Parameters.Add("@IdOccupation", SqlDbType.Int).Value = customer.IdOccupation;
                    cmd.Parameters.Add("@IdSuburb", SqlDbType.Int).Value = customer.IdSuburb;
                    cmd.Parameters.Add("@Occupation", SqlDbType.VarChar).Value = customer.oc.Description;
                    cmd.Parameters.Add("@Suburb", SqlDbType.VarChar).Value = customer.sub.Name;
                    cmd.Parameters.Add("@Education", SqlDbType.VarChar).Value = customer.educ.Name;

                    cmd.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    throw new ApplicationException("error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region Update Customer
        public void UpdateCustomer(Customer customer)
        {
            connectionName = dbc.ConnectDB(connect);
            using (SqlConnection conn = new SqlConnection(connectionName))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdCustomer", SqlDbType.Int).Value = customer.IdCustomer;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = customer.Name;
                    cmd.Parameters.Add("@PostalCode", SqlDbType.Int).Value = customer.PostalCode;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = customer.Address;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = customer.Phone;
                    cmd.Parameters.Add("@IdEducation", SqlDbType.Int).Value = customer.IdEducation;
                    cmd.Parameters.Add("@IdOccupation", SqlDbType.Int).Value = customer.IdOccupation;
                    cmd.Parameters.Add("@IdSuburb", SqlDbType.Int).Value = customer.IdSuburb;
                    cmd.Parameters.Add("@Occupation", SqlDbType.VarChar).Value = customer.oc.Description;
                    cmd.Parameters.Add("@Suburb", SqlDbType.VarChar).Value = customer.sub.Name;
                    cmd.Parameters.Add("@Education", SqlDbType.VarChar).Value = customer.educ.Name;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("error");

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
