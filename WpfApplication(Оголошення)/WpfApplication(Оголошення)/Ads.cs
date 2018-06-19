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
        List<string> images = new List<string>();
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
            images = null;
            price = 0;
            _date = DateTime.Now;
            _user = new User();
        }

        public List<string> Images
        {
            get { return images; }
        }

        public List<string> ImageS
        {
            get {
                System.Windows.MessageBox.Show("Getter  " + images[0]);
                return images; }
        }

        public Ads(string name, string catigory, int price, string text, List<string> imag, DateTime dt, User user)
        {
            this.name = name;
            this.price = price;
            _catygory = catigory;
            _text = text;
            images = imag;
            _date = dt;
            _user = user;
            System.Windows.MessageBox.Show(images[0]);

        }


    }
}

