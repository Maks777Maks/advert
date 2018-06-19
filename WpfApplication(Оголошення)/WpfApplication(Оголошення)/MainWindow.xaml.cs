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
using System.Collections.ObjectModel;

namespace WpfApplication_Оголошення_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public ObservableCollection<Ads> Adverts = new ObservableCollection<Ads>();
        public ObservableCollection<User> Users = new ObservableCollection<User>();

        ObservableCollection<Ads> tmp_ads = new ObservableCollection<Ads>();


        public User tmp1 = null;

        Ads ad = new Ads();

        public MainWindow()
        {
            InitializeComponent();

            ReadFromXML();
            Heading heading = new Heading();
            combo_heading.ItemsSource = heading.Headings;

            City city = new City();
            combo_city.ItemsSource = city.Cityes;

            Select.Items.Add("Ascending price");
            Select.Items.Add("Decending price");
            Select.Items.Add("By date");
            tmp_ads.Add(new Ads());

            tmp_ads = Adverts;
            view.ItemsSource = tmp_ads;
            Us.DataContext = tmp1;
        }

        private void ReadFromXML()
        {
            try
            {
                if (File.Exists("Users1.xml") == true)
                {
                    XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<User>));
                    using (FileStream t1 = new FileStream("Users1.xml", FileMode.Open))
                    {
                        Users = (ObservableCollection<User>)xml.Deserialize(t1);
                    }
                }            

                if (File.Exists("Adverts1.xml") == true)
                {
                    using (FileStream t = new FileStream("Adverts1.xml", FileMode.Open))
                    {
                        Type[] types = new Type[] { typeof(Ads) };

                        XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Ads>), types);
                        Adverts = (ObservableCollection<Ads>)xml.Deserialize(t);
                    }
                }              
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
                    if (_autorization.new_user == true)
                    {
                        tmp1 = _autorization.tmp;
                        Us.DataContext = tmp1;
                        Users.Add(tmp1);
                        Type[] types1 = { typeof(User) };
                        XmlSerializer xml1 = new XmlSerializer(typeof(ObservableCollection<User>));
                        using (FileStream t1 = new FileStream("Users1.xml", FileMode.Create))
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
            if (tmp1 != null)
            {
                AddAd Add__Ad = new AddAd(tmp1);
                Add__Ad.ShowDialog();
                MessageBox.Show(Add__Ad.Ad.Name.ToString());
                Adverts.Add(Add__Ad.Ad);
                Type[] types = { typeof(Ads) };
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Ads>), types);
                using (FileStream t = new FileStream("Adverts1.xml", FileMode.Create))
                {
                    xml.Serialize(t, Adverts);
                }
                
                tmp_ads = Adverts;
                view.ItemsSource = tmp_ads;
                
                foreach(Ads i in view.Items)
                {
                    MessageBox.Show(i.Date.ToString());
                }
            }
            else
            {
                MessageBox.Show("First you need to log in");
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

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            //ReadFromXML();            
            tmp_ads = Adverts;
            

            //foreach (Ads i in Adverts)
            //{
            //    if(Text.Text!="")
            //    {
            //       // tmp_ads.Remove()
            //    }
            //}

        }
    }
}
