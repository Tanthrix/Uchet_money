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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для newTypeWindow.xaml
    /// </summary>
    public partial class newTypeWindow : Window
    {
        public newTypeWindow()
        {
            InitializeComponent();
        }
        public string response = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = typeName.Text;
            if (text == null || text == "")
            {
                MessageBox.Show("XD ???");
            }
            else
            {
                response = text;
                Close();
            }
        }
    }
}