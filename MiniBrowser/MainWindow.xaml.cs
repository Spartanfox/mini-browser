using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace MiniBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String URL;
        public String Searching;
        public Dictionary<string, string> CartoonLinks = new Dictionary<string,string>();
        public Dictionary<string, string> AnimeLinks   = new Dictionary<string,string>();
        public string Cartoon;
        public string Anime;
        public string Custom;
        public bool Search;
        public ModifyRegistry.ModifyRegistry reg = new ModifyRegistry.ModifyRegistry();
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;

            CartoonLinks.Add("9Cartoon"           , "http://9cartoon.me/Search?s="                );
            CartoonLinks.Add("KissCartoon"        , "https://kisscartoon.pro/?s="                 );
            CartoonLinks.Add("WatchCartoonsOnline", "http://watchcartoonsonline.eu/?s="           );
            CartoonLinks.Add("CartoonExtra"       , "http://www.cartoonextra.com/toon/search?key=");

            AnimeLinks.Add("9Anime"               , "https://9anime.to/search?keyword="         );
            AnimeLinks.Add("KissAnime"            , "http://kissanime.ru/Search/Anime?keyword=" );
            AnimeLinks.Add("CrunchyRoll"          , "http://www.crunchyroll.com/search?from=&q=");

            Cartoon = reg.Read("Cartoon");
            Custom  = reg.Read("Custom");
            Anime   = reg.Read("Anime");
            Navigate(reg.Read("Recent"));

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Navigate();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Video.GoBack();
            }
            catch (Exception)
            {
                this.btnUndo.IsEnabled = false;
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Video.GoForward();
            }
            catch (Exception)
            {
                this.btnRedo.IsEnabled = false;
            }
        }

        private void Video_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            this.btnUndo.IsEnabled = true;
            this.btnRedo.IsEnabled = true;
        }
            
        
        private void Video_Navigated(object sender, NavigationEventArgs e)
        {
            this.HideScriptErrors(Video, true);
            this.btnUndo.IsEnabled = true;
            this.btnRedo.IsEnabled = true;
        }

        private void txtURL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Navigate("");
            }
        }

        private void Navigate(String URL)
        {
            this.HideScriptErrors(Video, true);
            if (URL.Length <= 0)
            {
               
                MessageBox.Show(this, "Please enter a url");
                

            }
            else
            {
                reg.Write("Recent", URL);
                Video.Navigate(URL);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.UpdateLayout();
            this.UpdateDefaultStyle();
            this.ButtonSizes.Height = new GridLength(40);
            base.Height += 64;
            base.Top -= 64;
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            this.WindowStyle = WindowStyle.None;
            this.UpdateLayout();
            this.UpdateDefaultStyle();
            this.ButtonSizes.Height = new GridLength(0);
            base.Height -= 64;
            base.Top += 64;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Video.Refresh();
        }

        private void btnKissCartoon_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.Searching = Cartoon;
            this.IsEnabled = false;
            new Search(this).ShowDialog();
            this.Topmost = true;
            this.IsEnabled = true;
            if (Search) Navigate(CartoonLinks[Cartoon] + URL);
            Search = false;
        } 

        private void btnKissAnime_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.Searching = Anime;
            this.IsEnabled = false;
            new Search(this).ShowDialog();
            this.Topmost = true;
            this.IsEnabled = true;
            if(Search)Navigate(AnimeLinks[Anime]+URL);
            Search = false;
        }

        private void btnYoutube_Click(object sender, RoutedEventArgs e)
        {
            Navigate("https://www.youtube.com/feed/subscriptions");
        }

        private void btnNetflix_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.Searching = "Netflix";
            this.IsEnabled = false;
            new Search(this).ShowDialog();
            this.Topmost = true;
            this.IsEnabled = true;
            if (Search) Navigate("https://www.netflix.com/search?q=" + URL);
            Search = false;
        }

        private void btnCustom_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.Searching = "a Custom URL";
            this.IsEnabled = false;
            new Search(this).ShowDialog();
            this.Topmost = true;
            this.IsEnabled = true;
            if (Search) Navigate(Custom + URL);
            Search = false;
        }
        
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            this.IsEnabled = false;
            new Settings(this).ShowDialog();
            this.Topmost = true;
            this.IsEnabled = true;
        }

        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }
    }
}