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

namespace AFFv2
{
    public partial class aboutpage : PhoneApplicationPage
    {
        bool sidebar_ = false;
        public aboutpage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            base.OnBackKeyPress(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            newsnavi.Stop();
            navi = 0;
            if (sidebar_ == true)
            {
                sidebarin.Begin();
                sidebar_ = true;
            }
        }
       

        private void rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        private void share_Click(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "Minions Factory";
            shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/s?appid=ca7b0765-c015-47e1-8070-358ceefc0342", UriKind.Absolute);
            shareLinkTask.Message = "Create your own minion character and having fun to save the picture and share it with your friends.";

            shareLinkTask.Show();
        }

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
            newsnavi.Begin();
            navi = 1;
            //NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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
            //newsnavi.Begin();
            //navi = 4;
            NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative));
        }

        private void newsnavi_Completed(object sender, EventArgs e)
        {
            if (navi == 1)
            { NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); }
            else if (navi == 2)
            { NavigationService.Navigate(new Uri("/newspage.xaml", UriKind.Relative)); }
            else if (navi == 3)
            { NavigationService.Navigate(new Uri("/contactus.xaml", UriKind.Relative)); }
            else if (navi == 4)
            { NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative)); }

        }
   
    }
}