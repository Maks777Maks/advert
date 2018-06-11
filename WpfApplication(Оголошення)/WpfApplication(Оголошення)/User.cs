using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication_Оголошення_
{
    public class User: IDataErrorInfo
    {
        string _login;
        string _password;
        string _city;
        string _name;
        string _tel;

        public User()
        { 
            _login = "";
            _password = "";
            _city = "";
            _name = "";
            _tel = "";
        }

        public User(string a, string b, string c, string d, string e)
        {
            _login = a;
            _password = b;
            _city = c;
            _name = d;
            _tel = e;
        }

        public string Login
        {
            set {
                _login = value; }
            get { return _login; }
        }

        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        public string City
        {
            set { _city = value; }
            get { return _city; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string m = "";
                switch(columnName)
                {
                    case "Login":
                        if(_login.Contains("loh"))
                        {
                            m = "bad";
                        }
                        break;
                    case "Password":
                        if(_password.Length<8)
                        {
                            m = "small";
                        }
                        break;
                }
                return m;

            }
        }
    }
}
