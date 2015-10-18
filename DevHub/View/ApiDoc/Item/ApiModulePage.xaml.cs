using DevHub.Model.ApiDoc.Item;
using DevHub.View.ApiDoc.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace DevHub.View.ApiDoc.Item
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ApiModulePage : Page
    {
        private ApiItem apiItem;

        private ObservableCollection<ApiModule> apiModules;

        public ApiModulePage()
        {
            this.InitializeComponent();
            this.Loaded += OnLoaded;

            // Get the apiModules from a Service
            // Remember to enable the NavigationCacheMode of this Page to avoid
            // load the data every time user navigates back and forward.    
            apiModules = new ApiModule().getApiModule(20);
            if (apiModules.Count > 0)
            {
                ApiModuleCVS.Source = apiModules;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Details view can remove an item from the list.
            if (e.Parameter as string == "Delete")
            {
                DeleteItem(null, null);
            }
            base.OnNavigatedTo(e);
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (apiItem == null && apiModules.Count > 0)
            {
                apiItem = apiModules[0].ApiItems[0];
                MasterListView.SelectedIndex = 0;
            }
            // If the app starts in narrow mode - showing only the Master listView - 
            // it is necessary to set the commands and the selection mode.
            if (PageSizeStatesGroup.CurrentState == NarrowState)
            {
                VisualStateManager.GoToState(this, MasterState.Name, true);
            }
            else if (PageSizeStatesGroup.CurrentState == WideState)
            {
                // In this case, the app starts is wide mode, Master/Details view, 
                // so it is necessary to set the commands and the selection mode.
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
                MasterListView.SelectionMode = ListViewSelectionMode.Extended;
                MasterListView.SelectedItem = apiItem;
            }
            else
            {
                new InvalidOperationException();
            }
        }
        private void OnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            bool isNarrow = e.NewState == NarrowState;
            if (isNarrow)
            {
                Frame.Navigate(typeof(ApiDetails), apiItem, new SuppressNavigationTransitionInfo());
            }
            else
            {
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
                MasterListView.SelectionMode = ListViewSelectionMode.Extended;
                MasterListView.SelectedItem = apiItem;
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(MasterListView, isNarrow);
           
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PageSizeStatesGroup.CurrentState == WideState)
            {
                if (MasterListView.SelectedItems.Count == 1)
                {
                    apiItem = MasterListView.SelectedItem as ApiItem;
                    this.frame.Navigate(typeof(ApiItemDetailsPage), apiItem, new DrillInNavigationTransitionInfo());
                }
                // Entering in Extended selection
                else if (MasterListView.SelectedItems.Count > 1
                     && MasterDetailsStatesGroup.CurrentState == MasterDetailsState)
                {
                    VisualStateManager.GoToState(this, ExtendedSelectionState.Name, true);
                }
            }
            // Exiting Extended selection
            if (MasterDetailsStatesGroup.CurrentState == ExtendedSelectionState &&
                MasterListView.SelectedItems.Count == 1)
            {
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
            }
        }
        // ItemClick event only happens when user is a Master state. In this state, 
        // selection mode is none and click event navigates to the details view.
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            // The clicked item it is the new selected contact
            apiItem = e.ClickedItem as ApiItem;
            if (PageSizeStatesGroup.CurrentState == NarrowState)
            {
                // Go to the details page and display the item 
                Frame.Navigate(typeof(ApiItemDetailsPage), apiItem, new DrillInNavigationTransitionInfo());
            }
            else
            {

                // Play a refresh animation when the user switches detail items.
                //EnableContentTransitions();
            }
        }

        #region Commands
        private void AddItem(object sender, RoutedEventArgs e)
        {
            //Contact c = Contact.GetNewContact();
            //apiModules.Add(c);

            //// Select this item in case that the list is empty
            //if (MasterListView.SelectedIndex == -1)
            //{
            //    MasterListView.SelectedIndex = 0;
            //    apiItem = MasterListView.SelectedItem as Contact;
            //    // Details view is collapsed, in case there is not items.
            //    // You should show it just in case. 
            //    DetailContentPresenter.Visibility = Visibility.Visible;
            //}
        }
        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (apiItem != null)
            {
                
                //apiModules.Remove(ApiItem);

                if (MasterListView.Items.Count > 0)
                {
                    MasterListView.SelectedIndex = 0;
                    apiItem = MasterListView.SelectedItem as ApiItem;
                }
                else
                {
                    // Details view is collapsed, in case there is not items.
                }
            }
        }
        private void DeleteItems(object sender, RoutedEventArgs e)
        {
            if (MasterListView.SelectedIndex != -1)
            {
                List<ApiModule> selectedItems = new List<ApiModule>();
                foreach (ApiModule contact in MasterListView.SelectedItems)
                {
                    selectedItems.Add(contact);
                }
                foreach (ApiModule contact in selectedItems)
                {
                    apiModules.Remove(contact);
                }
                if (MasterListView.Items.Count > 0)
                {
                    MasterListView.SelectedIndex = 0;
                    apiItem = MasterListView.SelectedItem as ApiItem;
                }
                else
                {
                }
            }
        }
        private void SelectItems(object sender, RoutedEventArgs e)
        {
            if (MasterListView.Items.Count > 0)
            {
                VisualStateManager.GoToState(this, MultipleSelectionState.Name, true);
            }
        }
        private void CancelSelection(object sender, RoutedEventArgs e)
        {
            if (PageSizeStatesGroup.CurrentState == NarrowState)
            {
                VisualStateManager.GoToState(this, MasterState.Name, true);
            }
            else
            {
                VisualStateManager.GoToState(this, MasterDetailsState.Name, true);
            }
        }
        private void ShowSliptView(object sender, RoutedEventArgs e)
        {
            // Clearing the cache
            int cacheSize = ((Frame)Parent).CacheSize;
            ((Frame)Parent).CacheSize = 0;
            ((Frame)Parent).CacheSize = cacheSize;

            MySamplesPane.SamplesSplitView.IsPaneOpen = !MySamplesPane.SamplesSplitView.IsPaneOpen;
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RepositoryPage) , new DrillInNavigationTransitionInfo());
        }
    }
}
