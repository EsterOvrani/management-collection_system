using Microsoft.Toolkit.Uwp.UI;
using OrAhemet.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class familyDetailPage : Page
    {
        public familyDetailPage()
        {
            this.InitializeComponent();
            this.DataContext = Global.currentFamily;
        }
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            var family = Global.currentFamily;
            var childern = await Global.client.GetChildrenByFamilyIDAsync(family);
            var charges = await Global.client.GetChargesByFamilyIDAsync(family);
            var paymentAccounts = await Global.client.GetPaymentAccountsByFamilyIDAsync(family);
            //family.ChildName = new List<string>();

            //childern.ForEach(child => family.ChildName.Add(child.ChildName));
            //// child to parent
            //childern.ForEach(child =>
            //{
            //    child.Family = family;
            //});

            //charges.ForEach(charge => charge.Family = family);
            //charges.ForEach(async charge => charge.Child = await Global.client.GetChildByIDAsync(charge.ChildID));
            //charges.ForEach(async charge => charge.TypeCharge = await Global.client.GetTypeChargeByIDAsync(charge.TypeChargeID));
            // charges.ForEach(async charge => charge.Family.TotalFamilyDebts += charge.TypeCharge.AmountToPay);

            //charge to family, child, typeCharge
            foreach (var charge in charges)
            {
                charge.Family = family;
                charge.Child = await Global.client.GetChildByIDAsync((int)charge.ChildID);
                charge.TypeCharge = await Global.client.GetTypeChargeByIDAsync(charge.TypeChargeID);
                charge.Family.TotalFamilyDebts += charge.TypeCharge.AmountToPay;
            }
            paymentAccounts.ForEach(async payment =>
            {
                switch (payment.PeymentType)
                {
                    case 1: // credit card
                        payment.CreditCard = await Global.client.GetCreditCardByPaymentAccountIDAsync(payment.PaymentAccountsID);
                        break;
                    case 2: // Horahat Keva
                        payment.HorahatKeva = await Global.client.GetHorahatKevaByPaymentAccountIDAsync(payment.PaymentAccountsID);
                        break;
                    default:
                        break;
                }
            });
            ObservableCollection<PaymentAccount> creditCards = new ObservableCollection<PaymentAccount>(paymentAccounts.Where(x => x.PeymentType == 1));
            ObservableCollection<PaymentAccount> horotKeva = new ObservableCollection<PaymentAccount>(paymentAccounts.Where(x => x.PeymentType == 2));


            //family to LstPaymentAccounts
            //family.PaymentAccounts = paymentAccounts;
            //family.CreditCards = paymentAccounts.Where(x => x.PeymentType == 1).ToList();
            //family.HorahatKeva = paymentAccounts.Where(x => x.PeymentType == 2).ToList();


            dgChildren.ItemsSource = new ObservableCollection<Child>(childern);
            dgCharges.ItemsSource = new ObservableCollection<Charge>(charges);
            dgCreditCards.ItemsSource = creditCards;
            dgHorahatKeva.ItemsSource = horotKeva;
            //a.ItemsSource = new ObservableCollection<string>(family.ChildName);
            if (Global.currentUser.UserType == "מערכת גביה")
            {
                piChargesDitels.IsEnabled = false;
                piChildrenDitels.IsEnabled = false;
                btnSaveFamily.IsEnabled = false;
                btDeleteCreditCard.IsEnabled = false;
                btAddHoraotKeva.IsEnabled = false;
                btAddCreditCard.IsEnabled = false;
                btDeleteHoraotKeva.IsEnabled = false;
            }


        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btForward_Click(object sender, RoutedEventArgs e)
        {
            Global.currentFamily = null;
            this.Frame.Navigate(typeof(FamiliesPage));
        }

        //CurrentFamily
        private async void btnSaveFamily_Click(object sender, RoutedEventArgs e)
        {
            if (Global.currentFamily.FamilyID == 0)
            {
                Global.currentFamily.FamilyID = await Global.client.InsertFamilyAsync(Global.currentFamily);
            }
            else
            {
                await Global.client.UpdateFamilyAsync(Global.currentFamily);
            }
        }

        //dgChildren
        private void btAddChild_Click(object sender, RoutedEventArgs e)
        {
            // Add Line(child) to dgChildren
            ObservableCollection<Child> Child = (ObservableCollection<Child>)dgChildren.ItemsSource;
            Child child = new Child
            {
                FamilyID = Global.currentFamily.FamilyID,
                ChildName = "ילד חדש",
                IsChanged = true
            };
            Child.Add(child);
        }
        private async void btSaveChild_Click(object sender, RoutedEventArgs e)
        {
            foreach (Child Child in dgChildren.ItemsSource)
            {
                if (Child.IsChanged == true)
                {
                    //Insert
                    if (Child.ChildID == 0)
                    {
                        Child.ChildID = await Global.client.InsertChildAsync(Child);
                    }
                    // Update
                    else
                    {
                        await Global.client.UpdateChildAsync(Child);
                    }

                    // Reset
                    Child.IsChanged = false;
                }
            }
        }
        private async void btDeleteChild_Click(object sender, RoutedEventArgs e)
        {
            // Delete from Server - DataBase
            Child child = (Child)dgChildren.SelectedItem;
            await Global.client.DeleteChildAsync(child.ChildID);

            // Remove form DataGrid
            ObservableCollection<Child> Childs = (ObservableCollection<Child>)dgChildren.ItemsSource;
            Childs.Remove((Child)dgChildren.SelectedItem);
        }

        //DgCharges
        private void btAddCharge_Click(object sender, RoutedEventArgs e)
        {
            // Add Line(charge) to DgCharges
            ObservableCollection<Charge> charges = (ObservableCollection<Charge>)dgCharges.ItemsSource;
            Charge charge = new Charge
            {
                FamilyID = Global.currentFamily.FamilyID,
                IsChanged = true
            };
            charges.Add(charge);
        }
        private async void btDeleteCharge_Click(object sender, RoutedEventArgs e)
        {
            // Delete from Server - DataBase
            Charge charge = (Charge)dgCharges.SelectedItem;
            await Global.client.DeleteChargeAsync(charge.ChargeID);

            // Remove form DataGrid
            ObservableCollection<Charge> charges = (ObservableCollection<Charge>)dgCharges.ItemsSource;
            charges.Remove((Charge)dgCharges.SelectedItem);
        }
        private async void btSaveCharge_Click(object sender, RoutedEventArgs e)
        {
            foreach (Charge charge in dgCharges.ItemsSource)
            {
                if (charge.IsChanged == true)
                {
                    //Insert
                    if (charge.ChargeID == 0)
                    {
                        charge.ChargeID = await Global.client.InsertChargeAsync(charge);
                    }
                    // Update
                    else
                    {
                        await Global.client.UpdateChargeAsync(charge);
                    }

                    // Reset
                    charge.IsChanged = false;
                }
            }
        }

        //dgCreditCards
        private void btAddCreditCard_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<PaymentAccount> pCreditCards = (ObservableCollection<PaymentAccount>)dgCreditCards.ItemsSource;
            // Add Line(CreditCard) to dgCreditCards
            PaymentAccount paymentAccounts = new PaymentAccount
            {
                FamilyID = Global.currentFamily.FamilyID,
                PeymentType = 1,
                CreditCard = new CreditCard(),
                IsActive = true,
                IsChanged = true
            };
            pCreditCards.Add(paymentAccounts);
        }
        private async void btDeleteCreditCard_Click(object sender, RoutedEventArgs e)
        {
            // Delete from Server - DataBase
            PaymentAccount paymentAccount = (PaymentAccount)dgCreditCards.SelectedItem;
            await Global.client.DeletePayment_CreditCardAsync(paymentAccount.PaymentAccountsID, paymentAccount.CreditCard.CreditCardID);
            //Global.client.DeleteCreditCardAsync(paymentAccount.CreditCard);
            //Global.client.DeletePaymentAccountsAsync(paymentAccount);

            // Remove form DataGrid
            ObservableCollection<PaymentAccount> pCreditCards = (ObservableCollection<PaymentAccount>)dgCreditCards.ItemsSource;
            pCreditCards.Remove((PaymentAccount)dgCreditCards.SelectedItem);
        }

        //dgHorahatKeva
        private void btAddHoraotKeva_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<PaymentAccount> pHorahatKevas = (ObservableCollection<PaymentAccount>)dgHorahatKeva.ItemsSource;
            // Add Line(HorahatKeva) to dgHorahatKeva
            PaymentAccount paymentAccounts = new PaymentAccount
            {
                FamilyID = Global.currentFamily.FamilyID,
                HorahatKeva = new HorahatKeva(),
                PeymentType = 2,
                IsActive = true,
                IsChanged = true
            };
            pHorahatKevas.Add(paymentAccounts);
        }
        private async void btDeleteHoraotKeva_Click(object sender, RoutedEventArgs e)
        {
            // Delete from Server - DataBase
            PaymentAccount paymentAccount = (PaymentAccount)dgHorahatKeva.SelectedItem;
            await Global.client.DeletePayment_HOKAsync(paymentAccount.PaymentAccountsID, paymentAccount.HorahatKeva.HorahatKevaID);
            //Global.client.DeleteHorahatKevaAsync(paymentAccount.HorahatKeva);
            //Global.client.DeletePaymentAccountsAsync(paymentAccount);

            // Remove form DataGrid
            ObservableCollection<PaymentAccount> pHorahatKevas = (ObservableCollection<PaymentAccount>)dgHorahatKeva.ItemsSource;
            pHorahatKevas.Remove((PaymentAccount)dgHorahatKeva.SelectedItem);
        }

        private async void btSavePaymentAccounts_Click(object sender, RoutedEventArgs e)
        {
            foreach (PaymentAccount pCreditCard in dgCreditCards.ItemsSource)
            {
                if (pCreditCard.IsChanged == true)
                {
                    //Insert
                    if (pCreditCard.PaymentAccountsID == 0)
                    {
                        pCreditCard.PaymentAccountsID = await Global.client.InsertPaymentAsync(pCreditCard);
                        //Global.client.InsertPaymentAccountsAsync(pCreditCard);
                        //Global.client.InsertCreditCardAsync(pCreditCard.CreditCard);
                    }
                    // Update
                    else
                    {
                        await Global.client.UpdateCreditCardAsync(pCreditCard.CreditCard);
                    }

                    // Reset
                    pCreditCard.IsChanged = false;
                }
            }

            foreach (PaymentAccount pHorahatKeva in dgHorahatKeva.ItemsSource)
            {
                if (pHorahatKeva.IsChanged == true)
                {
                    //Insert
                    if (pHorahatKeva.PaymentAccountsID == 0)
                    {
                        pHorahatKeva.PaymentAccountsID = await Global.client.InsertPaymentAsync(pHorahatKeva);
                        //Global.client.InsertPaymentAccountsAsync(pHorahatKeva);
                        //Global.client.InsertHorahatKevaAsync(pHorahatKeva.HorahatKeva);
                    }
                    // Update
                    else
                    {
                        await Global.client.UpdateHorahatKevaAsync(pHorahatKeva.HorahatKeva);
                    }

                    // Reset
                    pHorahatKeva.IsChanged = false;
                }
            }
        }
    }

}




