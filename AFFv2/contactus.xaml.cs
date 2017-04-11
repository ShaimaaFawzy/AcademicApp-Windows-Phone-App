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
using Windows.System;
using System.Threading.Tasks;

namespace AFFv2
{
    public partial class contactus : PhoneApplicationPage
    {
        bool sidebar_ = false;
        public contactus()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            animation_fb.Stop();
            animation_tw.Stop();
            animation_yt.Stop();
            newsnavi.Stop();
            navi = 0;
            if (sidebar_ == true)
            {
                sidebarin.Begin();
                sidebar_ = true;
            }
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
            navi = 1;
            newsnavi.Begin();
            
            //NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        async void fac()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            NavigationService.Navigate(new Uri("/Facebook.xaml", UriKind.Relative));
        }

        async void Twitter()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            NavigationService.Navigate(new Uri("/Twitter.xaml", UriKind.Relative));


        }

        async void Youtube()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            NavigationService.Navigate(new Uri("/Youtube.xaml", UriKind.Relative));

        }


        private void newsbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            newsnavi.Begin();
            navi = 2;
            //NavigationService.Navigate(new Uri("/newspage.xaml", UriKind.Relative));
        }

        private void contactbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //newsnavi.Begin();
            //navi = 3;
            NavigationService.Navigate(new Uri("/contactus.xaml", UriKind.Relative));
        }

        private void aboutbtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            newsnavi.Begin();
            navi = 4;
            //NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative));
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
       

        private void image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            animation_fb.Begin();
        }

        private async void animation_fb_Completed(object sender, EventArgs e)
        {
            fac();
        }

        private void tw2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            animation_tw.Begin();
        }

        private async void animation_tw_Completed(object sender, EventArgs e)
        {
            Twitter();
        }

        private void yt2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            animation_yt.Begin();
        }

        private async void animation_yt_Completed(object sender, EventArgs e)
        {
            Youtube();
        }

      

       
    
    }
}