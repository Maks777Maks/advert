using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.ComponentModel;

namespace WpfApplication_Оголошення_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<Ads> Adverts = new List<Ads>();
        public List<User> Users = new List<User>();


        public User tmp1 = null;

        Ads ad = new Ads();

        public MainWindow()
        {
            InitializeComponent();
           
            try
            {
                using (TextReader t = new StreamReader("Adverts"))
                {
                    Type[] types = new Type[] { typeof(Ads) };

                    XmlSerializer xml = new XmlSerializer(typeof(List<Ads>), types);
                    Adverts  = (List<Ads>)xml.Deserialize(t);
                    
                }


                using (TextReader t1 = new StreamReader("Users"))
                {
                    Type[] types = new Type[] { typeof(User) };

                    XmlSerializer xml = new XmlSerializer(typeof(List<User>), types);
                    Users = (List<User>)xml.Deserialize(t1);

                }
            }
            catch (FieldAccessException f)
            {
                Console.WriteLine(f.Message);
            }

            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }           
           
            Heading heading = new Heading();
            combo_heading.ItemsSource = heading.Headings;

            City city = new City();
            combo_city.ItemsSource = city.Cityes;
            
            Us.DataContext = tmp1;
        }

        private void Click_Autorization(object sender, RoutedEventArgs e)
        {
            
            Autorization _autorization = new Autorization();
            if (tmp1 == null)
            {
                if (_autorization.ShowDialog() == true)
                {
                    if(_autorization.new_user==true)
                    {
                        Users.Add(tmp1);
                        Type[] types1 = { typeof(User) };
                        XmlSerializer xml1 = new XmlSerializer(typeof(List<User>), types1);
                        using (TextWriter t1 = new StreamWriter("Users"))
                        {
                            xml1.Serialize(t1, Users);
                        }
                    }
                    tmp1 = _autorization.tmp;
                    Us.DataContext = tmp1;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddadvert_Click(object sender, RoutedEventArgs e)
        {
             AddAd Add__Ad = new AddAd(ad,tmp1);
             Add__Ad.ShowDialog();
             Adverts.Add(ad);
            Type[] types = { typeof(Ads) };
            XmlSerializer xml = new XmlSerializer(typeof(List<Ads>), types);
            using (TextWriter t = new StreamWriter("Adverts"))
            {
                xml.Serialize(t, Adverts);

            }
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void FormClosed(object sender, EventArgs e)
        {
           
            
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            tmp1 = null;
            Us.DataContext = tmp1;
        }

    }
}
