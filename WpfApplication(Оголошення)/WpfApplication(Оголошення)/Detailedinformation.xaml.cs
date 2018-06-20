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
    /// Interaction logic for Detailedinformation.xaml
    /// </summary>
    public partial class Detailedinformation : Window
    {

        Ads Ad;
       
       
       
        public Detailedinformation(Ads AD)
        {
            InitializeComponent();

            Ad = AD;

            List1.Items.Add(Ad.image1);
            List1.Items.Add(Ad.image2);
            List1.Items.Add(Ad.image3);
            

            //foreach (string i in List1.Items)
            //{
            //    if (i != null)
            //    {
            //        BitmapImage BI = new BitmapImage(new Uri(i));
            //        Image1.Source = BI;
            //        List1.SelectedItem = i;
            //        break;
            //    }
            //}

            List1.SelectedIndex = 0;






        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (List1.SelectedItem != null)
            {
                if (List1.SelectedIndex != 0)
                {
                    List1.SelectedItem = List1.Items[List1.SelectedIndex - 1];
                }
                else
                    List1.SelectedItem = List1.Items[List1.Items.Count - 1];

            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (List1.SelectedItem != null)
            {
                if (List1.SelectedIndex != List1.Items.Count - 1)
                {
                    List1.SelectedItem = List1.Items[List1.SelectedIndex + 1];
                }
                else
                    List1.SelectedItem = List1.Items[0];
            }
        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage BI = new BitmapImage(new Uri((List1.SelectedItem).ToString()));
            Image1.Source = BI;
        }
    }
}
