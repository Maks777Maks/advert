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

        User tmp = new User();
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
            
            foreach(string i in _heading)
            {
                heading.Items.Add(i);
            }
        }

        private void Click_Autorization(object sender, RoutedEventArgs e)
        {
            Autorization _autorization = new Autorization(tmp,_city);
            if(_autorization.ShowDialog()==true)
            {
                flag = true;
                Us.Text = tmp.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddadvert_Click(object sender, RoutedEventArgs e)
        {
             AddAd Add__Ad = new AddAd(_heading,ad,tmp);
            Add__Ad.ShowDialog();
        }
    }
}
