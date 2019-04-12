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
    class OccupationRepository
    {
        public string connectionName;

        DBConnection dbc = new DBConnection();

        public string connect = null;

        #region GetAllOccupation
        public List<Occupation> GetAllOccupation()
        {
            connectionName = dbc.ConnectDB(connect);

            List<Occupation> occupationList = new List<Occupation>();
            using (SqlConnection conn = new SqlConnection(connectionName))
            {

                SqlCommand cmd = new SqlCommand("GetAllOccupations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Occupation occupation = new Occupation();

                        occupation.IdOccupation = Convert.ToInt32(dr["IdOccupation"]);
                        occupation.Description = dr["Description"].ToString();


                        occupationList.Add(occupation);
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

                return occupationList;
            }

        }
        #endregion
    }
}