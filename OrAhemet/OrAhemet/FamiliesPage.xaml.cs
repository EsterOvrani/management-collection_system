using Microsoft.Toolkit.Uwp.UI;
using Microsoft.Toolkit.Uwp.UI.Controls;
using OrAhemet.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OrAhemet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FamiliesPage : Page
    {
        //private Random _random = new Random();
        public List<NameValueItem> Items { get; set; } = new List<NameValueItem>();
        Service1Client Client = new Service1Client();
        List<Family> lstFamily = null;
        public FamiliesPage()
        {
            this.InitializeComponent();



            //aaa.Children.Add(dataGrid1);
            //aaa.Children.Add(dataGrid1);

            Items.Add(new NameValueItem { Name = "אלעד", Value = 10 });
            Items.Add(new NameValueItem { Name = "ירושלים", Value = 45 });
            Items.Add(new NameValueItem { Name = "כרמיאל", Value = 5 });
            Items.Add(new NameValueItem { Name = "ביתר", Value = 25 });
            Items.Add(new NameValueItem { Name = "בני ברק", Value = 35 });

            // this.DataContext = this;
            this.DataContext = Global.currentUser;

        }




        private async void Page_Loading(FrameworkElement sender, object args)
        {

            // Loud data form DataBase.
            Global.currentFamilies = await Global.client.GetFamilyTableAsync();
            Global.transactions = await Global.client.GetTransactionsWithDebtsAsync();

            //transactions.ForEach(async transaction => transaction.Charges = await Global.client.GetChargeByIDAsync(transaction.ChargesID));
            foreach (var transaction in Global.transactions)
            {
                transaction.Charge = await Global.client.GetChargeByIDAsync((int)transaction.ChargesID);
            }
            Global.transactions.ForEach(async transaction => transaction.Charge.TypeCharge = await Global.client.GetTypeChargeByIDAsync(transaction.Charge.TypeChargeID));
            Global.transactions.ForEach(async transaction => transaction.Charge.Family = await Global.client.GetFamilyByIDAsync(transaction.Charge.FamilyID));

            //Biding UI - Data from DataBase
            dgFamily.ItemsSource = new ObservableCollection<Family>(Global.currentFamilies);
            dgTransactions.ItemsSource = new ObservableCollection<Transaction>(Global.transactions);


            // Loud UI acroiding UserType. 
            if (Global.currentUser != null && Global.currentUser.UserType != "מנהל")
            {
                btnAddUser.Visibility = Visibility.Collapsed;
            }
            if (Global.currentUser != null && Global.currentUser.UserType == "מערכת גביה")
            {
                rbDebt.IsChecked = true;
            }
            else if (Global.currentUser != null && Global.currentUser.UserType == "מזכירה")
            {
                rbFamily.IsChecked = true;
            }
            else if (Global.currentUser.UserType == "מנהל")
            {
                rbFamily.IsChecked = true;
                FilterDisplay.Visibility = Visibility.Visible;
            }

            //acv.Source = await Global.client.GetFamilyTableAsync();
            //acv.Filter = family => (family as Family).LastName.Contains(this.txtSearchText.Text);
            //dgFamily.ItemsSource = acv;

            //dgFamily.ItemsSource = await Global.client.GetFamilyTableAsync();
        }

        private void txtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((Global.currentUser.UserType == "מזכירה") || (Global.currentUser.UserType == "מנהל" && rbFamily.IsChecked == true))
            {
                ObservableCollection<Family> filter = new ObservableCollection<Family>(); ;
                foreach (Family family in Global.currentFamilies)
                {
                    if (family.LastName.Contains(this.txtSearchText.Text))
                    {
                        filter.Add(family);
                    }
                }
                dgFamily.ItemsSource = filter;
            }
            else
            {
                ObservableCollection<Transaction> filter = new ObservableCollection<Transaction>(); ;
                foreach (Transaction transaction in Global.transactions)
                {
                    if (transaction.Charge.Family.LastName.Contains(this.txtSearchText.Text))
                    {
                        filter.Add(transaction);
                    }
                }
                dgTransactions.ItemsSource = filter;
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.currentFamily = new Family();
            this.Frame.Navigate(typeof(familyDetailPage));
        }
        private async void btDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete from Server - DataBase            
            await Global.client.DeleteFamilyAsync(Global.currentFamily.FamilyID);

            // Remove form DataGrid
            ObservableCollection<Family> families = (ObservableCollection<Family>)dgFamily.ItemsSource;
            families.Remove(Global.currentFamily);

            // Reset currentFamily - null
            Global.currentFamily = null;
        }

        private void dgFamily_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Global.currentFamily = ((Family)((DataGrid)sender).SelectedItem);
            this.Frame.Navigate(typeof(familyDetailPage));
        }
        private void dgTransactions_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (((DataGrid)sender).CurrentColumn is DataGridCheckBoxColumn)
                return;
            Global.currentFamily = ((Transaction)((DataGrid)sender).SelectedItem).Charge.Family;
            this.Frame.Navigate(typeof(familyDetailPage));
        }

        private void dgFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Global.currentFamily = (Family)((DataGrid)sender).SelectedItem;
        }
        private void dgTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Global.currentFamily = ((Transaction)((DataGrid)sender).SelectedItem).Charge.Family;
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new MessageDialog("Hi!");
            //await dialog.ShowAsync();


            //ContentDialog noWifiDialog = new ContentDialog()
            //{
            //    Title = "No wifi connection",
            //    Content = "Check connection and try again.",
            //    CloseButtonText = "Ok"

            //};
            Nav_Pop.IsOpen = true;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Global.UserStatus = 3;
            this.Frame.Navigate(typeof(LoginPage));
        }
        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            Global.UserStatus = 2;
            this.Frame.Navigate(typeof(LoginPage));
        }
        private void btnExitUser_Click(object sender, RoutedEventArgs e)
        {
            Global.UserStatus = 1;
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void rbFamily_Checked(object sender, RoutedEventArgs e)
        {
            dgTransactions.Visibility = Visibility.Collapsed;
            dgFamily.Visibility = Visibility.Visible;
            btAdd.Visibility = Visibility.Visible;
            btDelete.Visibility = Visibility.Visible;
        }
        private void rbDebt_Checked(object sender, RoutedEventArgs e)
        {
            dgFamily.Visibility = Visibility.Collapsed;
            btAdd.Visibility = Visibility.Collapsed;
            btDelete.Visibility = Visibility.Collapsed;
            dgTransactions.Visibility = Visibility.Visible;
            btSaveTransactions.Visibility = Visibility.Visible;

        }

        private void btSaveTransactions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

public class NameValueItem
{
    public string Name { get; set; }
    public int Value { get; set; }
}
