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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        MainWindow main;
        public Settings(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            foreach (string key in main.AnimeLinks.Keys)
            {
                AnimeLst.Items.Add(key);
                if (main.Anime.Equals(key)) AnimeLst.SelectedIndex = AnimeLst.Items.Count-1;
            }
            foreach (string key in main.CartoonLinks.Keys)
            {
                CartoonLst.Items.Add(key);
                if (main.Cartoon.Equals(key)) CartoonLst.SelectedIndex = CartoonLst.Items.Count - 1;
            }

            CustomLnk.Text = main.Custom;

            this.Left = (main.Left + main.Width / 2) - Width / 2;
            this.Top = (main.Top + main.Height / 2) - Height / 2;


        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            main.Cartoon =  CartoonLst.SelectedItem as string;
            main.Anime = AnimeLst.SelectedItem as string;
            main.Custom = CustomLnk.Text;

            main.reg.Write("Anime", main.Anime);
            main.reg.Write("Cartoon", main.Cartoon);
            main.reg.Write("Custom", main.Custom);
            this.Close();
        }
    }
}
