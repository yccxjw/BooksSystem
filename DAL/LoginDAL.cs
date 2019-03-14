using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    class LoginDAL
    {
    }
    public class Login_DAL
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        Model.Login_MODEL loginuser = null;


        public Model.Login_MODEL Query(string username)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Tab_login where Username=@username";
                cmd.Parameters.Add(new SqlParameter("username", username));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        loginuser = new Model.Login_MODEL();
                        loginuser.Id = reader.GetInt32(0);
                        loginuser.Username = reader.GetString(1);
                        loginuser.password = reader.GetString(2);
                    }
                    else
                    {
                        loginuser = new Model.Login_MODEL();
                        loginuser.Id = -1;
                        loginuser.Username = "";
                        loginuser.password = "";
                    }
                }
                return loginuser;
            }
        }
    }
}
