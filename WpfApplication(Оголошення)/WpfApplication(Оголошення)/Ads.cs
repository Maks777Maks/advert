using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Оголошення_
{
    [Serializable]
    public class Ads
    {
        string _catygory;
        string _text;
        List<string> images = new List<string>();
        DateTime _date;
        public User _user;

        public string _Catygory
        {
            get { return _catygory; }
            set { _catygory = value; }

        }


        public string _Text
        {
            get { return _text; }
            set { _text = value; }

        }
        public DateTime _Date
        {
            get { return _date.Date; }
            set { _date = value; }
        }

        
            

        public Ads()
        {
            _catygory = "";
            _text = "";
            images = null;
            _date = DateTime.Now;
            _user = new User();
        }

        public List<string> Images
        {
            get { return images; }
        }

        



        public Ads(string catigory,string text,List<string>imag,DateTime dt,User user)
        {
            _catygory = catigory;
            _text = text;
            images = imag;
            _date = dt;
            _user = user;
        }


    }
}
