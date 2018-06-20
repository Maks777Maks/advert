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
        string name;
        string _catygory;
        string _text;
       public  string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        int price;
        DateTime _date;
        public User _user;

        public string _Catygory
        {
            get { return _catygory; }
            set { _catygory = value; }

        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string _Text
        {
            get { return _text; }
            set { _text = value; }

        }

        public DateTime Date
        {
            get { return _date.Date; }
            set { _date = value; }
        }

        public Ads()
        {
            name = "";
            _catygory = "";
            _text = "";
           
            price = 0;
            _date = DateTime.Now;
            _user = new User();
        }

       

       

        public Ads(string name, string catigory, int price, string text, string image1,string image2,string image3, DateTime dt, User user)
        {
            this.name = name;
            this.price = price;
            _catygory = catigory;
            _text = text;
            this.image1 = image1;
            this.image2 = image2;
            this.image3 = image3;
            _date = dt;
            _user = user;
           

        }


    }
}

