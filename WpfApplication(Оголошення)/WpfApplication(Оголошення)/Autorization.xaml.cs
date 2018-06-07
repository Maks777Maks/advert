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
using System.Windows.Shapes;

namespace WpfApplication_Оголошення_
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        bool flag = false;
        List<User> _users = new List<User>();

        User tmp = new User();
        public Autorization(User a)
        {
            InitializeComponent();
            tmp = a;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            foreach(User i in _users)
            {
                if(i.Login==Log.Text)
                {
                    if(i.Password==Pass.Text)
                    {
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag == false)
            {
                gr.Visibility = Visibility.Visible;
                flag = true;
            }
            else
            {
                gr.Visibility = Visibility.Collapsed;
                flag = false;
            }
        }
    }
}
