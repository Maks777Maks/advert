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
        public bool new_user = false;
        public List<User> _users = new List<User>();

        public User tmp = new User();
        public Autorization()
        {
            InitializeComponent();
            City city = new City();

            Combo1.ItemsSource = city.Cityes;
            
            this.DataContext = tmp;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            foreach(User i in _users)
            {
                if(i.Login==Log.Text)
                {
                    if(i.Password==Pass.Password)
                    {
                        this.DialogResult = true;
                        tmp=i;
                        this.Close();
                    }
                }
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag == false)
            {
                stack1.Visibility = Visibility.Visible;
                stack2.Visibility = Visibility.Visible;
                flag = true;
            }
            else
            {
                stack1.Visibility = Visibility.Collapsed;
                stack2.Visibility = Visibility.Collapsed;
                flag = false;
            }

        }

        private void Click_Ok(object sender, RoutedEventArgs e)
        {
            if(Log1.Text=="" || Pass1.Text=="" || Pass2.Text=="" || Combo1.SelectedIndex==-1 || Pass4.Text=="")
            {
                MessageBox.Show("Не все поля заполненны!!!");
                return;
            }
            if (Pass2.Text != Pass1.Text)
            {
                MessageBox.Show("Пароль не верный!!!");
                return;
            }
                //tmp.Login = Log1.Text;
                tmp.Password = Pass2.Text;
                //tmp.City = Combo1.SelectedItem.ToString();
                //tmp.Tel = Pass4.Text.ToString();
                this.DialogResult = true;
                new_user = true;
                this.Close();        
        }

        private void Log1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //bool fff = Convert.ToBoolean(sender);
            if (Log1.Text != "")
            {
                Tip.Visibility = Visibility;
            }
            //else
                //Tip.Visibility = Collapsed;
        }
    }
}
