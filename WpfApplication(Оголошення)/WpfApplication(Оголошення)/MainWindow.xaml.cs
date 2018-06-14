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

        Ads ad= new Ads();

        public MainWindow()
        {
            InitializeComponent();

           

            ReadFromXML();


            Heading heading = new Heading();
            combo_heading.ItemsSource = heading.Headings;

            City city = new City();
            combo_city.ItemsSource = city.Cityes;
            
            Us.DataContext = tmp1;
        }


        private void ReadFromXML()
        {
            try
            {
                if (File.Exists("Users1.xml") == true)
                {
                    //[] types = new Type[] { typeof(User) };
                    XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                    using (FileStream t1 = new FileStream("Users1.xml", FileMode.Open))
                    {


                        Users = (List<User>)xml.Deserialize(t1);

                    }
                }
                else
                    MessageBox.Show("!!!");


                if (File.Exists("Adverts1.xml") == true)
                {
                    using (FileStream t = new FileStream("Adverts1.xml",FileMode.Open))
                    {
                        Type[] types = new Type[] { typeof(Ads) };

                        XmlSerializer xml = new XmlSerializer(typeof(List<Ads>), types);
                        Adverts = (List<Ads>)xml.Deserialize(t);

                    }
                }
                else
                    MessageBox.Show("!!!");


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Click_Autorization(object sender, RoutedEventArgs e)
        {
            
            Autorization _autorization = new Autorization(Users);
            if (tmp1 == null)
            {
                if (_autorization.ShowDialog() == true)
                {
                    if(_autorization.new_user==true)
                    {
                        tmp1 = _autorization.tmp;
                        Us.DataContext = tmp1;
                        Users.Add(tmp1);
                        Type[] types1 = { typeof(User) };
                        XmlSerializer xml1 = new XmlSerializer(typeof(List<User>));
                        using (FileStream t1 = new FileStream("Users1.xml",FileMode.Create))
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
            using (FileStream t = new FileStream("Adverts1.xml", FileMode.Create))
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
