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
using Windows.Phone.Speech.Recognition;

namespace AFFv2
{
    public partial class feedback : PhoneApplicationPage
    {
        bool sidebar_ = false;
        public feedback()
        {
            InitializeComponent();
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
            //newsnavi.Begin();
            //navi = 2;
            NavigationService.Navigate(new Uri("/newspage.xaml", UriKind.Relative));
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
        private void Send_Click(object sender, EventArgs e)
        {

            if (txtfeedback.Text =="")
            {
                MessageBox.Show("Please Write your feedback before send mail ");

            }
            else
            {
                EmailComposeTask emailComposeTask = new EmailComposeTask();

                emailComposeTask.Subject = "Academic AppFactory Feedback";
                emailComposeTask.Body = txtfeedback.Text;
                emailComposeTask.To = "academic_appfactory@outlook.com";


                emailComposeTask.Show();
            }
        }

        private async void talk_Click(object sender, EventArgs e)
        {
            SpeechRecognizerUI reco = new SpeechRecognizerUI();
            SpeechRecognitionUIResult result = await reco.RecognizeWithUIAsync();
            txtfeedback.Text = result.RecognitionResult.Text;

        }
    }
}