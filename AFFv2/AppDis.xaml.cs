using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Windows.Media.Imaging;
using Windows.System;
using Facebook;
using Microsoft.Phone.Net.NetworkInformation;


namespace AFFv2
{
    public partial class AppDis : PhoneApplicationPage
    {
        private const string AppId  = "1428117897438796";
        string ExtendedPermissions = "user_about_me,read_stream,publish_stream";

        private readonly FacebookClient _fb = new FacebookClient();
        public AppDis()
        {
            if (NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.None)
            {
                CustomMessageBox cmb = new CustomMessageBox()
                {
                    Content = " No Internet Connection \n Please check your connection !",
                    Height = 200,
                    Opacity = 0.9,
                    FontSize = 25,


                    LeftButtonContent = "Check",

                    RightButtonContent = "Close!"
                };

                cmb.Dismissed += (s1, e1) =>
                {
                    switch (e1.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:
                            Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-cellular:"));

                            break;
                        case CustomMessageBoxResult.RightButton:
                            cmb.Visibility = Visibility.Collapsed;
                            break;

                        default:
                            break;
                    }

                };
                cmb.Show();
            }
        
            InitializeComponent();
          //  RefreshTodoItems();
        }
     public    void  LoadPageData()
        {
            txtBlk_appName.Text = Page1.items[Page1.PublicId].appname;
            DeveloperName.Text = Page1.items[Page1.PublicId].developername;
            AppDesc.Text = Page1.items[Page1.PublicId].appdescription;
            AppCat.Text = Page1.items[Page1.PublicId].appsection;
            AppType.Text = Page1.items[Page1.PublicId].apptype;
         applink.Text = Page1.items[Page1.PublicId].applink;

           
        
        
            Uri myUri = new Uri(Page1.items[Page1.PublicId].applogo, UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            logo.Source = bmi;

        }
      
        private void rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        //private async void RefreshTodoItems()
        //{
        //    MobileServiceInvalidOperationException exception = null;

        //    try
        //    {

        //        items = await todoTable.Where(todoItem => todoItem.Complete == false).ToCollectionAsync();
        //        //prProgress.IsActive = false;
        //        //prProgress.Visibility = Visibility.Collapsed;
        //    }
        //    catch (MobileServiceInvalidOperationException e)
        //    {
        //        exception = e;
        //    }

        //    if (exception != null)
        //    {
        //        MessageBox.Show("Internet Problem");
        //    }
        //    else
        //    {
        //     //   AAF a = new AAF();

        //      //  a.appdescription = AppDesc.Text;
        //    //    scroll. = items;

        //    }
        //}


     
    //    int CurrentID;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            LoadPageData();
                
            }



        private  void download_Click(object sender, EventArgs e)
        {
      //  Uri u= new Uri(Page1.items[Page1.PublicId].applink, UriKind.Absolute);

            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri(applink.Text, UriKind.Absolute);

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

                var url = string.Format("/FacebookInfoPage.xaml?access_token={0}&id={1}", accessToken, id);

                Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
            };

            fb.GetAsync("me?fields=id");
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            var loginUrl = GetFacebookLoginUrl(AppId, ExtendedPermissions);
            webBrowser1.Navigate(loginUrl);
            web1.Visibility = Visibility.Visible;
            dis.Visibility = Visibility.Collapsed;
        }
        private void share_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = txtBlk_appName.Text;
            emailComposeTask.Body = "This Application is awesome" + " try it! Download it! " + " #AcademicAppFactory" + " #EgyptAppFactory " + " #WindowsPhone " + " \n \t \n " + "Application Link \n" + applink.Text + " ";
            emailComposeTask.To = "";
            emailComposeTask.Show();

        }
    }
}