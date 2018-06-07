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
        string _image;
        DateTime _date;
        User _user;

        public Ads()
        {
            _catygory = "noname";
            _text = "noname";
            _image = "noname";
            _date = DateTime.Now;
            _user = new User();
        }
    }
}
