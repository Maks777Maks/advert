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
        List<string> _heading = new List<string>();
        List<string> _city = new List<string>();
        public List<Ads> Adverts = new List<Ads>();
        public List<User> Users = new List<User>();

        public User tmp1 = new User();
        bool flag = false;
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






            _heading.Add("Все рубрики");
            _heading.Add("Недвижимость");
            _heading.Add("Транспорт");
            _heading.Add("Работа");
            _heading.Add("Животные");
            _heading.Add("fable");
            _heading.Add("Электроника");
            _heading.Add("Отдых и спорт");

            foreach (string i in _heading)
            {
                combo_heading.Items.Add(i);
            }

            _city.Add("Винница");
            _city.Add("Луцьк");
            _city.Add("Днепр");
            _city.Add("Донецк");
            _city.Add("Житомир");
            _city.Add("Ужгород");
            _city.Add("Запорожье");
            _city.Add("Ивано-Франковск");
            _city.Add("Киев");
            _city.Add("Кировоград");
            _city.Add("Луганск");
            _city.Add("Львов");
            _city.Add("Николаев");
            _city.Add("Одесса");
            _city.Add("Полтава");
            _city.Add("Ровно");
            _city.Add("Сумы");
            _city.Add("Тернополь");
            _city.Add("Харьков");
            _city.Add("Херсон");
            _city.Add("Хмельницк");
            _city.Add("Черкассы");
            _city.Add("Чернигов");
            _city.Add("Черновцы");

            foreach (string i in _city)
            {
                combo_city.Items.Add(i);
            }
            Us.DataContext = tmp1;
        }

        private void Click_Autorization(object sender, RoutedEventArgs e)
        {
            Autorization _autorization = new Autorization(tmp1, _city);
            if(_autorization.ShowDialog()==true)
            {
                flag = true;
                tmp1 = _autorization.tmp;
               // Us.Header = tmp1.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddadvert_Click(object sender, RoutedEventArgs e)
        {
             AddAd Add__Ad = new AddAd(_heading,ad,tmp1);
             Add__Ad.ShowDialog();
             Adverts.Add(ad);
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show($"count: {Adverts.Count}");

            if (Adverts.Count > 0 && Users.Count > 0)
            {

                Type[] types = { typeof(Ads) };
                Type[] types1 = { typeof(User) };
                XmlSerializer xml1 = new XmlSerializer(typeof(List<User>), types1);
                XmlSerializer xml = new XmlSerializer(typeof(List<Ads>), types);
                using (TextWriter t = new StreamWriter("Adverts"))
                {
                    xml.Serialize(t, Adverts);

                }

                using (TextWriter t1 = new StreamWriter("Users"))
                {


                     xml1.Serialize(t1, Users);
                }
            }
        }

        private void FormClosed(object sender, EventArgs e)
        {
           
            
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {

        }

    }
}
