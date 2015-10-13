using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DevHub.Model.ApiDoc.Item;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Animation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace DevHub.View.ApiDoc.Item
{
    public sealed partial class ApiItemDetailsPage : Page
    {
        private ApiItem SelectApiItem { set; get; }
        public ApiItemDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SelectApiItem = e.Parameter as ApiItem;
            // Register for hardware and software back request from the system
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MasterDetailSelection), "Delete", new EntranceNavigationTransitionInfo());
        }
    }
}
