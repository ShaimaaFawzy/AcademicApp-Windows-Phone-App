using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AFFv2.Resources;
using System.Windows.Media.Imaging;
using System.Threading;
using Microsoft.Phone.Tasks;
using System.ComponentModel;

namespace AFFv2
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool sidebar_ = false;
        public MainPage()
        {
            InitializeComponent();
            Thread.Sleep(100);
            animation_start.Begin();
            TiltEffect.TiltableItems.Add(typeof(StackPanel));
            ShellTile myTile = ShellTile.ActiveTiles.First();
            FlipTileData FlipTile = new FlipTileData
            {
                Title = "Academic AppFactory",
                BackTitle = "Academic AppFactory",
                BackContent = "",
               
               
                SmallBackgroundImage = new Uri("/Assets/150x150.png", UriKind.Relative),
                BackgroundImage = new Uri("/Assets/691x336.png", UriKind.Relative),
                WideBackgroundImage = new Uri("/Assets/691x336.png", UriKind.Relative),
            };
          
        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            e.Cancel = true;
            App.Current.Terminate();

        }
        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    pagemainnavi.Begin();
        
        //}
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            newsnavi.Stop();
            navi = 0;
            animation_start.Begin();
            if (sidebar_ == true)
            {
                sidebarin.Begin();
                sidebar_ = true;
            }
            
        }
        private void Stack_store_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            image_store.Source = new BitmapImage(new Uri("///Assets/source/store image.png"));
        }

        private void Stack_store_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            image_store.Source = new BitmapImage(new Uri("///Assets/source/store image shade.png"));
        }

        private void Stack_phone_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            image_phone.Source = new BitmapImage(new Uri("///Assets/source/phone image.png"));
        }

        private void Stack_phone_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
           
            image_phone.Source = new BitmapImage(new Uri("///Assets/source/phone image shade.png"));
        }

        private void Stack_store_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            animation_storeOut.Begin();
           
        }

        private void Stack_phone_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            animation_phoneOut.Begin();
        }
        
        

        private void animation_phoneOut_Completed(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/WinphoneApps.xaml", UriKind.Relative));
        }

        private void animation_storeOut_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Win8Apps.xaml", UriKind.Relative));
        }

        private void share_Click(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "Academic AppFactory";
            shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/s?appid=ca7b0765-c015-47e1-8070-358ceefc0342", UriKind.Absolute);
            shareLinkTask.Message = "";

            shareLinkTask.Show();
        }






        #region Menu Bar
        private void OnFlick(object sender, FlickGestureEventArgs e)
        {
            if (sidebar_ == false)
            {
                if (e.HorizontalVelocity < 0)
                {
                    sidebarout.Begin();
                }
                sidebar_ = true;
            }
            else if (sidebar_ == true)
            {
                if (e.HorizontalVelocity > 0)
                {
                    sidebarin.Begin();
                }
                sidebar_ = false;
            }
        }
        
        private void menuside_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (sidebar_ == false)
            {
                sidebarout.Begin();
                sidebar_ = true;
            }
            else if (sidebar_ == true)
            {
                sidebarin.Begin();
                sidebar_ = false;
            }
        }
        int navi = 0;
        private void homebtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //newsnavi.Begin();
            //navi = 1;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


        private void newsbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            newsnavi.Begin();
            navi = 2;
            //NavigationService.Navigate(new Uri("/newspage.xaml", UriKind.Relative));
        }

        private void contactbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            newsnavi.Begin();
            navi = 3;
            //NavigationService.Navigate(new Uri("/contactus.xaml", UriKind.Relative));
        }

        private void aboutbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            newsnavi.Begin();
            navi = 4;
            //NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative));
        }

        private void newsnavi_Completed(object sender, EventArgs e)
        {
            if(navi==1)
            { NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); }
            else if (navi==2)
            { NavigationService.Navigate(new Uri("/newspage.xaml", UriKind.Relative)); }
            else if (navi == 3)
            { NavigationService.Navigate(new Uri("/contactus.xaml", UriKind.Relative)); }
            else if (navi == 4)
            { NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative)); }
            
        }

#endregion
        #region AppBar
        private void more_Click(object sender, EventArgs e)
        {
            MarketplaceSearchTask searchTask = new MarketplaceSearchTask();

            searchTask.SearchTerms = "academic appfactory";

            searchTask.Show();
        }

        private void feedback_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/feedback.xaml", UriKind.Relative));
        }
        private void rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        private void newsletter_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/newsletters.xaml", UriKind.Relative));

        }

        #endregion
    }
}