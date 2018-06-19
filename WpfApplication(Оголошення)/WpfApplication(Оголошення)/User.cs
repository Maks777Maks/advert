using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WpfApplication_Оголошення_
{
    [Serializable]
    public class User: IDataErrorInfo , INotifyPropertyChanged
    {
       private bool isValid = false;
        string _login;
        string _password;
        string _city;
        string _name;
        string _tel;
        string _mail;

        string pattern;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsValid
        {
            set
            {
                if (PropertyChanged != null)
                {
                    isValid = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
                }
            }
            get { return isValid; }
        }

        public User()
        { 
            _login = "";
            _password = "";
            _city = "";
            _name = "";
            _tel = "";
            _mail = "";
        }

        public User(string a, string b, string c, string d, string e, string m)
        {
            _login = a;
            _password = b;
            _city = c;
            _name = d;
            _tel = e;
            _mail = m;        
        }

        public string Mail
        {
            set { _mail = value; }          
            get { return _mail; }
        }

        public string Login
        {
            set { _login = value; }
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
                IsValid = true;
                switch(columnName)
                {
                    case "Login":
                        if(_login==""/*.Contains("loh")*/)
                        {                           
                            m = "bad";
                            IsValid = false;
                        }
                        break;
                    case "Password":
                        if (_password.Length < 8)
                        {
                            m = "small";
                            IsValid = false;
                        }
                        break;
                    case "Tel":
                        pattern = @"^\d{10}$";
                        if (!Regex.IsMatch(_tel, pattern))
                        m = "Incorrect";
                        IsValid = false;
                        break;
                    case "Name":
                        pattern = @"[A-Z][a-z]+$";
                        if (!Regex.IsMatch(_name, pattern))
                        {
                            m = "Incorrect";
                            IsValid = false;
                        }                         
                        break;
                    case "City":
                        if (_city == "")
                        {
                            m = "Incorrect";
                            IsValid = false;
                        }
                        break;
                    case "Mail":
                        if (_mail == "")
                        {
                            m = "Incorrect";
                            IsValid = false;
                        }
                        pattern = @"[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                        if (!Regex.IsMatch(_mail, pattern, RegexOptions.IgnoreCase))
                        {
                            m = "Incorrect";
                            IsValid = false;
                        }
                        break;
                }
                return m;
            }
        }
    }
}
