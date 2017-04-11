﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.Phone.Tasks;
using Windows.Networking.Connectivity;
using Microsoft.Phone.Net.NetworkInformation;

namespace AFFv2
{
    public partial class WinphoneApps : PhoneApplicationPage
    {
       // public WinphoneApps()
         bool sidebar_ = false;
         public static  MobileServiceCollection<AFFv2.AAFWP,AFFv2.AAFWP> MYAzure;
         private IMobileServiceTable<AAFWP> todoTable = App.MobileService.GetTable<AAFWP>();
        public WinphoneApps()
        {
            InitializeComponent();

            if (NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.None)
            {
                CustomMessageBox cmb = new CustomMessageBox()
                {
                    Content = "\n No Internet Connection \n Please check your connection !",
                    Height = 200,
                    Opacity = 0.9,
                    FontSize = 20,


                    LeftButtonContent = "Check"
                    ,

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
        

            
            else
            {
                RefreshTodoItems();
            } 
            AAFv2.DataFill df = new AAFv2.DataFill();
            df.WpData();
            Top.ItemsSource = df.Data;

           
        }
      
        private async void RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;

            try
            {

                MYAzure = await todoTable.Where(todoItem => todoItem.Complete == false).ToCollectionAsync();
                progbar.IsIndeterminate = false;
                txtload.Visibility = Visibility.Collapsed;
                progbar.Visibility = Visibility.Collapsed;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
               MessageBox.Show( "Internet Problem");
            }
            else
            {

                MM.ItemsSource = MYAzure;
                Data.Source = MYAzure;
            }
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

        #region Slide Bar
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
            if (navi == 1)
            { NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); }
            else if (navi == 2)
            { NavigationService.Navigate(new Uri("/newspage.xaml", UriKind.Relative)); }
            else if (navi == 3)
            { NavigationService.Navigate(new Uri("/contactus.xaml", UriKind.Relative)); }
            else if (navi == 4)
            { NavigationService.Navigate(new Uri("/aboutpage.xaml", UriKind.Relative)); }

        }
        #endregion

        #region App Bar
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
        #endregion

        public static int PublicId;
        void MM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PublicId= MM.SelectedIndex;
          
            NavigationService.Navigate(new Uri("/AppWPDis.xaml", UriKind.Relative));

        }

   
        public static bool TeamMemberClickedFromMainPage;

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel s = (StackPanel)sender;
            int id = int.Parse(s.Tag.ToString());
            NavigationService.Navigate(new Uri("/TopWp.xaml?pram=" + id, UriKind.Relative));
        }

        

        }
}