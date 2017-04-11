using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Net.NetworkInformation;

namespace AFFv2
{
    public partial class Twitter : PhoneApplicationPage
    {
        public Twitter()
        {
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
            InitializeComponent();
        }
    }
}