using cw6.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public class SqlServerDbService : IDbService
    {

        private const string ConString = "Data Source=db-mssql;Initial Catalog=s16520;Integrated Security=True";
        /*        public void CheckIndexNumber(string index)
                {
                    SqlConnection con = new SqlConnection();
                    SqlCommand com = new SqlCommand();


                }*/

        public Student GetStudent(string index)
        {
            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();

                try
                {
                    com.CommandText = "select * from Student where IndexNumber=@index";
                    com.Parameters.AddWithValue("index", index);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        return null;
                    }
                    var st = new Student();
                    st.Index = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();

                    dr.Close();
                    return st;
                }
                catch (SqlException exc)
                {
                    Console.WriteLine(exc);
                }
                return null;
            }
        }

        //...
    }
}
