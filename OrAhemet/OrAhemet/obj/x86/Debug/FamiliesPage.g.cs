﻿#pragma checksum "C:\Users\אסתי\Desktop\אבא\SQL Based\Current\OrAhemet\OrAhemet\FamiliesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "95DC40DF360C9586CD9E13EF21942FCB2AE63A6631DC25D74820F4F2E7F11169"
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
    partial class FamiliesPage : 
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
            case 1: // FamiliesPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // FamiliesPage.xaml line 229
                {
                    this.btSaveTransactions = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btSaveTransactions).Click += this.btSaveTransactions_Click;
                }
                break;
            case 3: // FamiliesPage.xaml line 222
                {
                    this.btAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btAdd).Click += this.btAdd_Click;
                }
                break;
            case 4: // FamiliesPage.xaml line 225
                {
                    this.btDelete = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btDelete).Click += this.btDelete_Click;
                }
                break;
            case 5: // FamiliesPage.xaml line 115
                {
                    this.Nav_Pop = (global::Windows.UI.Xaml.Controls.Primitives.Popup)(target);
                }
                break;
            case 6: // FamiliesPage.xaml line 182
                {
                    this.dgTransactions = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.dgTransactions).DoubleTapped += this.dgTransactions_DoubleTapped;
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.dgTransactions).SelectionChanged += this.dgTransactions_SelectionChanged;
                }
                break;
            case 7: // FamiliesPage.xaml line 199
                {
                    this.dgFamily = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.dgFamily).DoubleTapped += this.dgFamily_DoubleTapped;
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.dgFamily).SelectionChanged += this.dgFamily_SelectionChanged;
                }
                break;
            case 8: // FamiliesPage.xaml line 147
                {
                    this.btnEditUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEditUser).Click += this.btnEditUser_Click;
                }
                break;
            case 9: // FamiliesPage.xaml line 158
                {
                    this.btnAddUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnAddUser).Click += this.btnAddUser_Click;
                }
                break;
            case 10: // FamiliesPage.xaml line 168
                {
                    this.btnExitUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnExitUser).Click += this.btnExitUser_Click;
                }
                break;
            case 11: // FamiliesPage.xaml line 89
                {
                    this.txtSearchText = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txtSearchText).TextChanged += this.txtSearchText_TextChanged;
                }
                break;
            case 12: // FamiliesPage.xaml line 97
                {
                    this.btnUser = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnUser).Click += this.btnUser_Click;
                }
                break;
            case 13: // FamiliesPage.xaml line 24
                {
                    this.FilterDisplay = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 14: // FamiliesPage.xaml line 30
                {
                    this.rbFamily = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rbFamily).Checked += this.rbFamily_Checked;
                }
                break;
            case 15: // FamiliesPage.xaml line 31
                {
                    this.rbDebt = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rbDebt).Checked += this.rbDebt_Checked;
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
