﻿#pragma checksum "C:\Users\אסתי\Desktop\אבא\SQL Based\Current\OrAhemet\OrAhemet\familyDetailPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D44D6740222AF39DD0203E6EF47A854AB504F9CF3E5FC5D8169E289C5ED1F206"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrAhemet
{
    partial class familyDetailPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // familyDetailPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // familyDetailPage.xaml line 53
                {
                    this.rootPivot = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                }
                break;
            case 3: // familyDetailPage.xaml line 54
                {
                    this.piFamilyDitels = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 4: // familyDetailPage.xaml line 158
                {
                    this.piChildrenDitels = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 5: // familyDetailPage.xaml line 200
                {
                    this.piChargesDitels = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 6: // familyDetailPage.xaml line 243
                {
                    this.piPaymentAccountsDitels = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 7: // familyDetailPage.xaml line 255
                {
                    this.dgCreditCards = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 8: // familyDetailPage.xaml line 287
                {
                    this.btnsCreditCard = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 9: // familyDetailPage.xaml line 295
                {
                    this.dgHorahatKeva = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 10: // familyDetailPage.xaml line 327
                {
                    this.btnsHorahtKeva = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 11: // familyDetailPage.xaml line 328
                {
                    this.btAddHoraotKeva = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btAddHoraotKeva).Click += this.btAddHoraotKeva_Click;
                }
                break;
            case 12: // familyDetailPage.xaml line 331
                {
                    this.btDeleteHoraotKeva = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btDeleteHoraotKeva).Click += this.btDeleteHoraotKeva_Click;
                }
                break;
            case 13: // familyDetailPage.xaml line 334
                {
                    this.btSavePaymentAccounts = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btSavePaymentAccounts).Click += this.btSavePaymentAccounts_Click;
                }
                break;
            case 14: // familyDetailPage.xaml line 288
                {
                    this.btAddCreditCard = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btAddCreditCard).Click += this.btAddCreditCard_Click;
                }
                break;
            case 15: // familyDetailPage.xaml line 291
                {
                    this.btDeleteCreditCard = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btDeleteCreditCard).Click += this.btDeleteCreditCard_Click;
                }
                break;
            case 16: // familyDetailPage.xaml line 211
                {
                    this.dgCharges = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 17: // familyDetailPage.xaml line 230
                {
                    this.btAddCharge = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btAddCharge).Click += this.btAddCharge_Click;
                }
                break;
            case 18: // familyDetailPage.xaml line 233
                {
                    this.btDeleteCharge = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btDeleteCharge).Click += this.btDeleteCharge_Click;
                }
                break;
            case 19: // familyDetailPage.xaml line 236
                {
                    this.btSaveCharge = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btSaveCharge).Click += this.btSaveCharge_Click;
                }
                break;
            case 20: // familyDetailPage.xaml line 219
                {
                    this.a = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridComboBoxColumn)(target);
                }
                break;
            case 21: // familyDetailPage.xaml line 169
                {
                    this.dgChildren = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 22: // familyDetailPage.xaml line 188
                {
                    this.btAddChild = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btAddChild).Click += this.btAddChild_Click;
                }
                break;
            case 23: // familyDetailPage.xaml line 191
                {
                    this.btDeleteChild = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btDeleteChild).Click += this.btDeleteChild_Click;
                }
                break;
            case 24: // familyDetailPage.xaml line 194
                {
                    this.btSaveChild = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btSaveChild).Click += this.btSaveChild_Click;
                }
                break;
            case 25: // familyDetailPage.xaml line 146
                {
                    this.btnSaveFamily = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSaveFamily).Click += this.btnSaveFamily_Click;
                }
                break;
            case 26: // familyDetailPage.xaml line 44
                {
                    this.btForward = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btForward).Click += this.btForward_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

