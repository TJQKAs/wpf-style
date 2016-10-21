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

namespace WpfStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void stylesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (sender as ComboBox).SelectedItem as ComboBoxItem;

            if (item != null)
            {
                string text = item.Content.ToString();
                var app = App.Current as App;
                var uri = new Uri(text + "Theme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);        
            }

        }


        double dWinScale = 1.0d; //Пример скалирования
        private void sizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (sender as ComboBox).SelectedItem as ComboBoxItem;

            if (item != null)
            {
                myWindow.Width = 1280;
                myWindow.Height = 600;
                double size;
                Double.TryParse(item.Content.ToString(), out size);
                dWinScale = 1.0d * size / 100;  
                ((Grid)myWindow.Content).LayoutTransform =
                new ScaleTransform(dWinScale, dWinScale);
                myWindow.Width = Width * dWinScale;
                myWindow.Height = Height * dWinScale;
               
            }

        }
    }
}
