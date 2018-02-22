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

namespace MiniBrowser
{
    /// <summary>
    /// Interaction logic for Scearch.xaml
    /// </summary>
    public partial class Search : Window
    {
        MainWindow main;
        public Search(MainWindow Parent)
        {
            InitializeComponent();
            this.main = Parent;
            this.Topmost = true;
            this.txtLabel.Content = "What would you like to search on "+Parent.Searching+"?";
            this.Left = (Parent.Left+Parent.Width/2)-Width/2;
            this.Top = (Parent.Top+Parent.Height/2)-Height/2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.URL = URLSearch.Text;
            main.Search = true;
            this.Close();
        }
    }
}
