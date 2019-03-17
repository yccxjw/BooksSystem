using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class LoginBLL
    {

    }
    public class Login_BLL
    {
        DAL.Login_DAL dal = new DAL.Login_DAL();

        public Model.Login_MODEL getlogin(string Username)
        {
            return dal.Query(Username);
        }
    }
}
