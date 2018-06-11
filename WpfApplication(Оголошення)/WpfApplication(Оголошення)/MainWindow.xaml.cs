﻿using System;
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
        

        User tmp = new User();
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
            
            foreach(string i in _heading)
            {
                heading.Items.Add(i);
            }
        }

        private void Click_Autorization(object sender, RoutedEventArgs e)
        {
            Autorization _autorization = new Autorization(tmp, _city);
            if(_autorization.ShowDialog()==true)
            {
                flag = true;
                Us.Text = tmp.Name;
               // Users = _autorization._users;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddadvert_Click(object sender, RoutedEventArgs e)
        {
             AddAd Add__Ad = new AddAd(_heading,ad,tmp);
             Add__Ad.ShowDialog();
             Adverts.Add(ad);
        }

        private void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show($"count: {Adverts.Count}");

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
    }
}
