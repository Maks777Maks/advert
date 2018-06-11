using System;
using System.Collections.Generic;
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

namespace WpfApplication_Оголошення_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> _heading = new List<string>();
        List<string> _city = new List<string>();

        public User tmp1 = new User();
        bool flag = false;
        Ads ad = new Ads();

        public MainWindow()
        {
            InitializeComponent();
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
           //  AddAd Add__Ad = new AddAd(_heading,ad,tmp);
           // Add__Ad.ShowDialog();
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            tmp1 = null;
        }
    }
}
