using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Оголошення_
{
    class Heading
    {
        List<string> heading = null;
        public Heading()
        {
            heading = new List<string>
            {
                "All heading",
                "Property",
                "Transport",
                "Job",
                "Animals",
                "Electronics",
                "Recreation and Sports"               
            };
        }
        public List<string> Headings
        {
            get { return heading; }
        }
    }
}
