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
    class EducationRepository
    {
        public string connectionName;

        DBConnection dbc = new DBConnection();

        public string connect = null;

        #region GetAllQualification
        public List<Education> GetAllQualification()
        {
            connectionName = dbc.ConnectDB(connect);

            List<Education> educationList = new List<Education>();
            using (SqlConnection conn = new SqlConnection(connectionName))
            {

                SqlCommand cmd = new SqlCommand("GetAllEducations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                       Education education = new Education();

                       education.IdEducation = Convert.ToInt32(dr["IdEducation"]);
                       education.Name = dr["Name"].ToString();


                       educationList.Add(education);
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

                return educationList;
            }

        }
        #endregion
    }
}
