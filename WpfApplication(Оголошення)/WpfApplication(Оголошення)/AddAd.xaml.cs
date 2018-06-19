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
        public Ads Ad = new Ads();
        List<string> images = new List<string>();
        public AddAd(User user)
        {
            InitializeComponent();

            Heading heading = new Heading();
            ComboBox1.ItemsSource = heading.Headings;

            this.user = user;
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
                images.Add(ofd.FileName);
                BitmapImage bi = new BitmapImage(new Uri(ofd.FileName));
                Image i = new Image();
                i.Source = bi;
                (sender as Button).Content = i;
            }
        }
       

        private void AddAdvert(object sender, RoutedEventArgs e)
        {
            

            //foreach (Button i in Grid1.Children)
            //{
            //    if ((i.Content as Image) != null)
            //    {
            //        images.Add((i.Content as Image).Source.ToString());
            //    }
            //}
            //if (images.Count != 0)
            foreach(var i in images)
            {
                MessageBox.Show(i);
            }
                Ad = new Ads(Title.Text, ComboBox1.SelectedItem.ToString(), int.Parse(_price.Text), Text.Text, images, new DateTime(), user);
            this.Close();
        }
    }
}