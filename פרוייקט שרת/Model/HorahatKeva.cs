//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HorahatKeva
    {
        public int HorahatKevaID { get; set; }
        public int PaymentAccountsID { get; set; }
        public Nullable<int> BankNumber { get; set; }
        public Nullable<int> AccountNumber { get; set; }
        public Nullable<int> BranchNumber { get; set; }
        public string NameAccountHolders { get; set; }
        public Nullable<System.TimeSpan> MonthlyBillingDate { get; set; }
    }
}
