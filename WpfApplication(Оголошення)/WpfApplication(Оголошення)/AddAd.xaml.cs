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
    /// Interaction logic for AddAd.xaml
    /// </summary>
    public partial class AddAd : Window
    {
        User user;
        Ads Ad;
        public AddAd(List<string> heading, Ads ad, User user)
        {
            InitializeComponent();
            ComboBox1.ItemsSource = heading;
            Ad = ad;
            try
            {
                //System.Windows.Forms.MessageBox.Show($"Name: {user.Name}");
                this.user = user;
                Tel.Text = this.user.Tel.ToString();
                City.Text = this.user.City;
                Login.Text = this.user.Password;
            }
            catch
            {

            }








        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Logotip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            if (true == ofd.ShowDialog())

            {
                BitmapImage bi = new BitmapImage(new Uri(ofd.FileName));
                Image i = new Image();
                i.Source = bi;
                (sender as Button).Content = i;


            }
        }

        private void AddAdvert(object sender, RoutedEventArgs e)
        {
            List<string> images = new List<string>();
            if ((Image1.Content as Image) != null && (Image2.Content as Image) != null && (Image3.Content as Image) != null)
            {
                images.Add((Image1.Content as Image).Source.ToString());
                images.Add((Image2.Content as Image).Source.ToString());
                images.Add((Image3.Content as Image).Source.ToString());
                Ads a = new Ads(ComboBox1.SelectedItem.ToString(), Text.Text, images, new DateTime(), user);

            }
        }
    }
}