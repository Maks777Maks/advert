using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Оголошення_
{
    public class City
    {
        List<string> _cityes = null;
        public City()
        {
            _cityes = new List<string>
            {
                "All City",
                "Kiev",
                "Cherkasy",
                "Chernigov",
                "Chernivtsi",
                "Dnieper",
                "Donetsk",
                "Ivano-Frankivsk",
                "Kirovograd",
                "Kharkiv",
                "Kherson",
                "Khmelnitsk",
                "Lions",
                "Lugansk",
                "Lutsk",
                "Mykolaiv",
                "Odessa",
                "Poltava",
                "Smooth",
                "Sumy",
                "Ternopil",
                "Uzhhorod",
                "Vinnitsa",
                "Zaporozhye",
                "Zhitomir"
            };
        }
            public List<string> Cityes
        {
            get { return _cityes; }
        }
    }
}
