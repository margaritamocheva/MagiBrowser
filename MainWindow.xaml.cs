using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MagiBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<String> tabs = new List<String>();
        int index = 0;
        bool blankpage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tabs.Count <= 0 || index <=0 || index == tabs.Count) { addressopen.Content = "Blank Page!"; adressinput.Text = "Blank Page!"; return; }
            index--;
            String element = tabs.ElementAt(index);
            adressinput.Text = element;
            addressopen.Content = "Open a " + element + " successfully!";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String urlregex = "^(http[s]?:\\/\\/(www\\.)?|ftp:\\/\\/(www\\.)?|www\\.){1}([0-9A-Za-z-\\.@:%_\\+~#=]+)+((\\.[a-zA-Z]{2,3})+)(/(.)*)?(\\?(.)*)?";
          Regex r = new Regex(urlregex, RegexOptions.IgnoreCase);
            String address = adressinput.Text;
           Match m = r.Match(address);
          if (m.Success)
            {
                if(tabs.Count!=0) index++;
                addressopen.Content = "Open a " + address + " successfully!";
                tabs.Add(address);
           }
          else addressopen.Content = "Invalid address!";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String element;
            if (blankpage) { element = tabs.ElementAt(0); adressinput.Text = element;
                addressopen.Content = "Open a " + element + " successfully!";
                blankpage = false;
                index++;
                return;
            }
            if (tabs.Count <= 0 || index <= 0 || index == tabs.Count) { addressopen.Content = "Blank Page!"; adressinput.Text = "Blank Page!"; blankpage = true; return; }
            element = tabs.ElementAt(index);
            adressinput.Text = element;
            addressopen.Content = "Open a " + element + " successfully!";
            index++;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            String address = adressinput.Text;
            viewhistory.Items.Add(address);
        }

        private void viewhistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String text = viewhistory.SelectedItem.ToString();
            adressinput.Text = text;
            addressopen.Content = "Open a " + text + " successfully!";
        }
    }
}
