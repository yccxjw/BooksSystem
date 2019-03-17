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
        static string strcon = "Data Source=J76NEJN7CK57G57;Initial Catalog=BooksSystem;Integrated Security=True";
        SqlConnection con = new SqlConnection(strcon);
        Model.Login_MODEL loginuser = null;


        public Model.Login_MODEL Query(string Username)
        {
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from User_info where Username=@Username";
                cmd.Parameters.Add(new SqlParameter("Username", Username));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        loginuser = new Model.Login_MODEL();
                        loginuser.id = reader.GetInt32(0);
                        loginuser.Username = reader.GetString(1);
                        loginuser.dbpassword = reader.GetString(2);
                    
                    }
                    else
                    {
                        loginuser = new Model.Login_MODEL();
                        loginuser.id = -1;
                        loginuser.Username = "";
                        loginuser.dbpassword = "";
                    }
                }
                return loginuser;
            }
        }
    }
}
