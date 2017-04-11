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
using Windows.Storage;
using System.Windows.Media.Imaging;
using Windows.Storage.Streams;
using Facebook;
using Microsoft.Phone.Tasks;

namespace AFFv2
{
    public partial class TopWp : PhoneApplicationPage
    {
        public TopWp()
        {
            InitializeComponent();
        }
        private const string AppId = "1428117897438796";
        string ExtendedPermissions = "user_about_me,read_stream,publish_stream";

        private readonly FacebookClient _fb = new FacebookClient();
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string id = NavigationContext.QueryString["pram"];
            DataFill df = new DataFill();
            switch (id)
            {
                case "0":
                    txtBlk_appName.Text = "Egypt Taxi Fare  ";
                    AppDesc.Text = @"This app allows you to calculate your fare to check on the taxi's meter, and to estimate the fare to your destination beforehand.";
                   DeveloperName.Text = "Mohamed Kamel";
                    AppCat.Text = "Tools";
                    AppType.Text = " Windows Phone";
                    applink.Text = "http://www.windowsphone.com/en-us/store/app/egypt-taxi-fare/3c1bfbc8-b728-4904-8877-ad1552e1bd1b";

                    

                    Uri myUri = new Uri("/Assets/TopApps/e76f321b-afa5-4da4-ab83-34751af80f84.png", UriKind.Relative);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            logo.Source = bmi;
            break;

                case "1":
            txtBlk_appName.Text = "Islamy";
            AppDesc.Text = @"Islamy is a windows phone application that let you know how you pray and notes about mistakes of it , prayer times and evening azkar before you sleep ";
            DeveloperName.Text = "Mustafa Mamdouh Abel Tawab";
            AppCat.Text = "Books + reference ";
            AppType.Text = " Windows Phone";
            applink.Text = "http://www.windowsphone.com/en-us/store/app/islamy/44a8b9c4-36ed-4cdf-87c3-c830c6d04c25";

            Uri myUri2 = new Uri("/Assets/TopApps/a43adafb-3397-4089-bae2-2521ca88da3c.png", UriKind.Relative);
            BitmapImage bmi2 = new BitmapImage();
            bmi2.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi2.UriSource = myUri2;
            logo.Source = bmi2;
            break;

           

                case "2":
                    txtBlk_appName.Text = "Sha2ety";
                    AppDesc.Text = @"Do you live in Egypt?
Are you looking for an apartment?
Do you find difficulties to sell your apartment?

Here you are this great and simple App!

App features:
-post an offer (address, price, contact info,...)
";
                    DeveloperName.Text = "Abanoub Labib";
                    AppCat.Text = "Business ";
                    AppType.Text = "Windows Phone";
                    applink.Text = "http://www.windowsphone.com/en-us/store/app/sha2ety/7a91fd69-e3be-4dc6-8631-f7a8736cd4a9";

                    Uri myUri3 = new Uri("/Assets/TopApps/f37b0c46-89c3-4381-a797-998e3b593235.png", UriKind.Relative);
            BitmapImage bmi3 = new BitmapImage();
            bmi3.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi3.UriSource = myUri3;
            logo.Source = bmi3;
            break;
                  
                  
                case "3":
                    txtBlk_appName.Text = "Coffee Time";
                    AppDesc.Text = "This application Display and show us how to make Different Coffee and Tea And Drinks , show Different types of cakes and helping in every think in this time  and this application used internet in some pages ";
                    DeveloperName.Text = "Mohamed Ismail";
                    AppCat.Text = "lifestyle";
                    AppType.Text = "Windows Phone";
                    applink.Text = "http://www.windowsphone.com/en-us/store/app/coffee-time/43e90aeb-c440-48c8-a573-a2054771ddb9";

                    Uri myUri4 = new Uri("/Assets/TopApps/39f41005-fb92-4462-b2c6-f00aa14b1940.png", UriKind.Relative);
            BitmapImage bmi4 = new BitmapImage();
            bmi4.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi4.UriSource = myUri4;
            logo.Source = bmi4;
            break;
                  
                case "4":
                    txtBlk_appName.Text = "The Cooker";
                    AppDesc.Text = @"It is a mobile application that will help people to cook as a professional cookers in an interesting way , instead of searching on internet for each item wanted to be cooked.

It will include a several types of food , such as Oriental , European & Asian food ; the main aim is to inform the cooker all the ingredients, recipes, and time needed for each meal ";
                    DeveloperName.Text = "Yousra Radwan";
                    AppCat.Text = "Food + dining";
                    AppType.Text = "Windows Phone";
                    applink.Text = "http://www.windowsphone.com/en-us/store/app/the-cooker/08da116a-b411-4e49-a1f4-52d1892bc20e";

                    Uri myUri5 = new Uri("/Assets/TopApps/d716d4a4-f133-426b-858d-q.png", UriKind.Relative);
            BitmapImage bmi5 = new BitmapImage();
            bmi5.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi5.UriSource = myUri5;
            logo.Source = bmi5;
            break;
                  
                  
                  
                  
                  
            }

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

                var url = string.Format("/FacebookInfoPage.xaml?access_token={0}&id={1}", accessToken, id);

                Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
            };

            fb.GetAsync("me?fields=id");
        }


        private void download_Click(object sender, EventArgs e)
        {

            WebBrowserTask webBrowserTask = new WebBrowserTask();
            string id = NavigationContext.QueryString["pram"];
            DataFill df = new DataFill();
            switch (id)
            {
                case "0": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "1": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "2": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "3": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;
                case "4": webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute); break;


            }
            webBrowserTask.Show();
        }

      
    }
}