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
    
    public partial class Charge
    {
        public int ChargeID { get; set; }
        public int FamilyID { get; set; }
        public Nullable<int> ChildID { get; set; }
        public int TypeChargeID { get; set; }
        public Nullable<System.TimeSpan> BillingDate { get; set; }
        public Nullable<System.TimeSpan> DatePayment { get; set; }
        public int PaymentAccountsID { get; set; }
    }
}
