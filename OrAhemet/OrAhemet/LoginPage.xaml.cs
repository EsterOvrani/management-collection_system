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
using OrAhemet.ServiceReference1;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OrAhemet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public List<NameValueItem> Items { get; set; } = new List<NameValueItem>();
        List<User> lstUser = null;

        public LoginPage()
        {
            this.InitializeComponent();
            //ServiceReference.Service1Client proxy = new ServiceReference.Service1Client();
            //var lst = proxy.GetDataAsync(1);

        }
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            lstUser = await Global.client.GetUserTableAsync();

            switch (Global.UserStatus)
            {
                case 1:
                    btnEnter.Visibility = Visibility.Visible;
                    ////pass entering username and password
                    //Global.currentUser = lstUser.First(x => x.UserName == "אסתי");
                    //this.Frame.Navigate(typeof(FamiliesPage));
                    break;
                case 2:
                    txtName.Text = Global.currentUser.UserName;
                    txtPassWard.Password = Global.currentUser.UserCode;
                    btnSave.Visibility = Visibility.Visible;
                    btnCencelChange.Visibility = Visibility.Visible;
                    break;
                case 3:
                    btnAdd.Visibility = Visibility.Visible;
                    spUserType.Visibility = Visibility.Visible;
                    btnCencelAdd.Visibility = Visibility.Visible;
                    break;
            }

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            //בודק אם שם וסיסמה נכונים
            foreach (User user in lstUser)
            {
                if (user.UserName == txtName.Text && user.UserCode == txtPassWard.Password)
                {
                    Global.currentUser = user;
                    this.Frame.Navigate(typeof(FamiliesPage));
                    return;
                }

            }
            //אם זה לא נכון כותב שגיאה
            tbComment.Text = "שם המשתמש או הסיסמה אינם נכונים";
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserCode = txtPassWard.Password;
            user.UserName = txtName.Text;
            user.UserType = ((ComboBoxItem)cbUserType.SelectedItem).Content.ToString();
            user.UserID = await Global.client.InsertUserAsync(user);
            this.Frame.Navigate(typeof(FamiliesPage));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Global.currentUser.UserCode = txtPassWard.Password;
            Global.currentUser.UserName = txtName.Text;
            Global.client.UpdateUserAsync(Global.currentUser);
            this.Frame.Navigate(typeof(FamiliesPage));
        }

        private void btnCencel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FamiliesPage));
        }
    }
}
