using System;
using System.Data;
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

namespace Калькулятор
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in korobka.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += But_click;
                }
            }
        }

        private void check1_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked == true)
            {
                list1.IsEnabled = true;
            }
            else
            {
                list1.IsEnabled = false;
            }
        }

        private void But_click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str =="AC")
            {
                TextCout.Text = "";
            }
            else if(str =="=")
            {
                string x = new DataTable().Compute(TextCout.Text, null).ToString();
                if (check1.IsChecked == true)
                {
                    TextCout.Text += " = ";
                    TextCout.Text += x;
                    list1.Items.Add(TextCout.Text);
                }

                TextCout.Text = x;

            }
            else if (str == "Очистить историю")
            {
                list1.Items.Clear();
            }
            else if(str == "Удалить запись")
            {
                list1.Items.Remove(list1.SelectedItem);
            }
            else
            {
                TextCout.Text += str;
            }

            //throw new NotImplementedException();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radio1.IsChecked == true)
            {
                list1.Visibility = Visibility.Visible;
                check1.Visibility = Visibility.Visible;
                del_his.Visibility = Visibility.Visible;
                del_lis.Visibility = Visibility.Visible;
            }
            else if (radio2.IsChecked == true)
            {
                list1.Visibility = Visibility.Hidden;
                check1.Visibility = Visibility.Hidden;
                del_his.Visibility = Visibility.Hidden;
                del_lis.Visibility = Visibility.Hidden;
            }
        }
    }
}
