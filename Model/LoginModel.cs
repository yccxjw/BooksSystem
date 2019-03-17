using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class LoginModel
    {
    }
    public class Login_MODEL
    {
        private int _id;
        private string _Username;
        private string _dbpassword;

        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Username
        {
            set { _Username = value; }
            get { return _Username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dbpassword
        {
            set { _dbpassword = value; }
            get { return _dbpassword; }
        }
    }
}
