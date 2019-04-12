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
    class SuburbRepository
    {
        public string connectionName;

        DBConnection dbc = new DBConnection();

        public string connect = null;

        #region GetAllSuburbs
        public List<Suburb> GetAllSuburbs()
        {
            connectionName = dbc.ConnectDB(connect);

            List<Suburb> suburbList = new List<Suburb>();
            using (SqlConnection conn = new SqlConnection(connectionName))
            {

                SqlCommand cmd = new SqlCommand("GetAllSuburbs", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Suburb suburb = new Suburb();

                        suburb.IdSuburb = Convert.ToInt32(dr["IdSuburb"]);
                        suburb.Name = dr["Name"].ToString();
                        suburb.PostalCode = dr["PostalCode"].ToString();
                        suburb.Country = dr["Country"].ToString();

                        suburbList.Add(suburb);
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

                return suburbList;
            }

        }
        #endregion
    }
}