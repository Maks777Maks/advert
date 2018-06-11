using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Оголошення_
{
    public class Ads
    {
        string _catygory;
        string _text;
        List<string> images = new List<string>();
        DateTime _date;
        User _user;

        public Ads()
        {
            _catygory = "noname";
            _text = "noname";
            images = null;
            _date = DateTime.Now;
            _user = new User();
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
