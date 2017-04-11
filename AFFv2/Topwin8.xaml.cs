using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AAFv2;
using AFFv2.Resources;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.Phone.Tasks;
using Facebook;
namespace AFFv2
{
    public partial class Topwin8 : PhoneApplicationPage
    {
        private const string AppId = "1428117897438796";
        string ExtendedPermissions = "user_about_me,read_stream,publish_stream";

        private readonly FacebookClient _fb = new FacebookClient();
        public Topwin8()
        {
            InitializeComponent();
        }
        
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string id = NavigationContext.QueryString["pram"];
            DataFill df = new DataFill();
            switch (id)
            {
                case "0":
                    txtBlk_appName.Text = "مترو القاهرة  ";
                    AppDesc.Text = @"
يقدم لمستخدمى مترو الانفاق كثيرا من الخدمات الهامة 
كما يمكنك البحث عن مكان ما وسط اكثر من 15000 الف مكان يحيط بمحطات المترو للخطين الرئيسيين ومشاركة المعلومات مع اصدقائك 
كما يمكنك مشاهدة الفيديوهات الارشادية دون الحاجة الى الاتصال بالانترنت
";
                    DeveloperName.Text = "Mohamed Hussien";
                    AppCat.Text = "Tools";
                    AppType.Text = " Windows 8";
                   applink.Text = "http://apps.microsoft.com/windows/en-us/app/52a6452e-44ec-4748-bdcc-22440bbaa46c";

                    
                    Image  m=new Image ();
                    Uri myUri1 = new Uri("/Assets/TopApps/m.png", UriKind.Relative);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri1;
            logo.Source = bmi;
               break;
                    

        


                case "1":
                    txtBlk_appName.Text = "Science For Kids  ";
                    AppDesc.Text = @"Science For Kids is to provide educational resources for teachers and parents that help make science fun and engaging for kids, taking important concepts and putting them into a form that kids can not only understand but also enjoy.";
                    DeveloperName.Text = "sidky sobhy sidy";
                    AppCat.Text = "Education";
                    AppType.Text = " Windows 8";
                   applink.Text = "http://apps.microsoft.com/windows/en-US/app/science-forkids/856c30d2-cb99-4d84-9adf-adac7913f116";


                    Uri myUri2 = new Uri("/Assets/TopApps/Science ForKids.png", UriKind.Relative);
            BitmapImage bmi2 = new BitmapImage();
            bmi2.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi2.UriSource = myUri2;
            logo.Source = bmi2;
                  break;

                case "2":
                    txtBlk_appName.Text = "Kidzania";
                    AppDesc.Text = @"Kidzania is an educational app that help kids to define their goals, and shape their future career by demonstrating responsibilities for each career, and showing the good and bad stuff about these careers.";
                    DeveloperName.Text = "Mina Willam";
                    AppCat.Text = "Entertainment";
                    AppType.Text = "Windows 8";
                    applink.Text = "http://apps.microsoft.com/windows/en-us/app/kidzania/442fa2cf-afc5-4edb-8b48-1fbaa26e591e";

                    Uri myUri3 = new Uri("/Assets/TopApps/Icon.png", UriKind.Relative);
            BitmapImage bmi3 = new BitmapImage();
            bmi3.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi3.UriSource = myUri3;
            logo.Source = bmi3;

                break;

                case "3":
                    txtBlk_appName.Text = "Fos7tna";
                    AppDesc.Text = "فسحتنا تطبيق يساعدك علي معرفة اجمل الاماكن والمعالم السياحية وبعض المنتجعات التي يمكنك ان تقضي بها وقت ممتع ويتضمن ايضا بعض العروض الحصرية علي موقع فسحتنا علي الانترنت";
                    DeveloperName.Text = "Mohamed Hamid";
                    AppCat.Text = "Travel";
                    AppType.Text = "Windows 8";
                    applink.Text = "http://apps.microsoft.com/windows/en-us/app/fos7tna/b460c51a-0781-4a16-9047-a984d6825aaa";


                    Uri myUri4 = new Uri("/Assets/TopApps/Fos7tna.png", UriKind.Relative);
            BitmapImage bmi4 = new BitmapImage();
            bmi4.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi4.UriSource = myUri4;
            logo.Source = bmi4;

                
                  

                 
                     break;

                case "4":
                    txtBlk_appName.Text = " Otere Shooter";
                    AppDesc.Text = @"This game to strengthen intuition and act quickly, you can kill more bad guys and deliverance from enemies .
Game Control : Keyboard arrows to move in all directions
Ctrl for Rocket launch";
                    DeveloperName.Text = "Hatem  Heshmat";
                    AppCat.Text = "Games";
                    AppType.Text = "Windows 8.1";
                    applink.Text = "http://apps.microsoft.com/windows/en-us/app/5d2c48c7-85f4-4aa9-af7a-c93888e1105f";


                    Uri myUri5 = new Uri("/Assets/TopApps/Otere Shooter.png", UriKind.Relative);
            BitmapImage bmi5 = new BitmapImage();
            bmi5.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi5.UriSource = myUri5;
            logo.Source = bmi5;

                
                  
                     break;



            }
        }

       
        private void download_Click(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            string id = NavigationContext.QueryString["pram"];
            DataFill df = new DataFill();
            switch (id)
            { 
                case "0" :  webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute);break;
                case "1": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "2": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "3": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "4": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;

        
        }
            webBrowserTask.Show();
        }
        private Uri GetFacebookLoginUrl(string appId, string extendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appId;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "touch";

            // add the 'scope' only if we have extendedPermissions.
            if (!string.IsNullOrEmpty(extendedPermissions))
            {
                // A comma-delimited list of permissions
                parameters["scope"] = extendedPermissions;
            }

            return _fb.GetLoginUrl(parameters);
        }
        private void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (!_fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                return;
            }

            if (oauthResult.IsSuccess)
            {
                var accessToken = oauthResult.AccessToken;
                LoginSucceded(accessToken);
            }
            else
            {
                // user cancelled
                MessageBox.Show(oauthResult.ErrorDescription);
            }
        }

        private void LoginSucceded(string accessToken)
        {
            var fb = new FacebookClient(accessToken);

            fb.GetCompleted += (o, e) =>
            {
                if (e.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(e.Error.Message));
                    return;
                }

                var result = (IDictionary<string, object>)e.GetResultData();
                var id = (string)result["id"];
                var id2 = (string)result["id2"];
                var url = string.Format("/TopFacebook.xaml?access_token={0}&id={1}&id2={2}", accessToken, id,id2);

                Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
            };

            fb.GetAsync("me?fields=id");
        }

        

        private void Face_Click(object sender, EventArgs e)
        {
            var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);
            webBrowser1.Navigate(loginUrl);

            web1.Visibility = Visibility.Visible;
            dis.Visibility = Visibility.Collapsed;
        }
    }
}