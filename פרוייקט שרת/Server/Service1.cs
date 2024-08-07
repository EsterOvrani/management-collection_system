using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public OhrHaemetEntities MyDB { get; set; } = new OhrHaemetEntities();


        #region Login Page
        //שליפה
        public List<User> GetUserTable()
        {
            var users =  MyDB.User.ToList();
            return users;
        }
        #endregion

        #region Family Page
        //לבדוק עם טבלת משפחות????
        //שליפה
        public List<Family> GetFamilyTable()
        {
            return MyDB.Family.ToList();
        }
        public List<Transaction> GetTransactionsWithDebts()
        {
            return MyDB.Transaction.Where(x => x.Status == true).ToList();
        }
        public List<Transaction> GetTransactionsWithoutDebts()
        {
            return MyDB.Transaction.Where(x => x.Status == false).ToList();
        }
        public Charge GetChargeByID(int chargesID)
        {
            return MyDB.Charge.FirstOrDefault(x => x.ChargeID == chargesID);
        }
        //משתמש
        public int InsertUser(User user)
        {
            MyDB.User.Add(user);
            MyDB.SaveChanges();
            return user.UserID;
        }
        public void UpdateUser(User user)
        {
            MyDB.User.Attach(user);
            MyDB.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            MyDB.DeleteUser(userId);
        }
        //משפחה
        public int InsertFamily(Family family)
        {
            MyDB.Family.Add(family);
            MyDB.SaveChanges();
            return family.FamilyID;
        }
        public void DeleteFamily(int familyId)
        {
            MyDB.DeleteFamily(familyId);
        }
        #endregion

        #region Details Family Page
        //שליפה
        public Family GetFamilyByID(int FamilyID)
        {
            return MyDB.Family.FirstOrDefault(x=>x.FamilyID == FamilyID);
        }
        public Child GetChildByID(int childID)
        {
            return MyDB.Child.FirstOrDefault(x=>x.ChildID == childID);
        }
        public TypeCharge GetTypeChargeByID(int typeChargeID)
        {
            return MyDB.TypeCharge.FirstOrDefault(x => x.TypeChargesID == typeChargeID);
        }
        public List<Child> GetChildrenByFamilyID(Family family)
        {
            return MyDB.Child.Where(x => x.FamilyID == family.FamilyID).ToList();
        }
        public List<PaymentAccount> GetPaymentAccountsByFamilyID(Family family)
        {
            return MyDB.PaymentAccount.Where(x => x.FamilyID == family.FamilyID).ToList();
        }
        public CreditCard GetCreditCardByPaymentAccountID(int paymentAccountID)
        {
            return MyDB.CreditCard.FirstOrDefault(x => x.PaymentAccountsID == paymentAccountID);
        }
        public CreditCard GetCreditCardByID(int creditCardID)
        {
            return MyDB.CreditCard.FirstOrDefault(x => x.CreditCardID == creditCardID);
        }
        public HorahatKeva GetHorahatKevaByID(int horahatKevaID)
        {
            return MyDB.HorahatKeva.FirstOrDefault(x => x.HorahatKevaID == horahatKevaID);
        }
        public HorahatKeva GetHorahatKevaByPaymentAccountID(int paymentAccountID)
        {
            return MyDB.HorahatKeva.FirstOrDefault(x => x.PaymentAccountsID == paymentAccountID);
        }
        public List<Charge> GetChargesByFamilyID(Family family)
        {
            return MyDB.Charge.Where(x => x.FamilyID == family.FamilyID).ToList();
        }


        //עידכון, מחיקה, הוספה
        //ילדים
        public int InsertChild(Child child)
        {
            MyDB.Child.Add(child);
            MyDB.SaveChanges();
            return child.ChildID;
        }
        public void UpdateChild(Child child)
        {
            MyDB.Child.Attach(child);
            MyDB.SaveChanges();
        }
        public void DeleteChild(int childId)
        {
            MyDB.DeleteChild(childId);
        }
        //משפחה
        public void UpdateFamily(Family family)
        {
            MyDB.Family.Attach(family);
            MyDB.SaveChanges();
        }
        //תנועה
        public int InsertTransaction(Transaction transaction)
        {
            MyDB.Transaction.Add(transaction);
            MyDB.SaveChanges();
            return transaction.TransactionsID;
        }
        public void UpdateTransaction(Transaction transaction)
        {
            MyDB.Transaction.Attach(transaction);
            MyDB.SaveChanges();
        }
        //חיובים
        public int InsertCharge(Charge charge)
        {
            MyDB.Charge.Add(charge);
            MyDB.SaveChanges();
            return charge.ChargeID;
        }
        public void UpdateCharge(Charge charge)
        {
            MyDB.Charge.Attach(charge);
            MyDB.SaveChanges();
        }
        public void DeleteCharge(int chargeId)
        {
            MyDB.DeleteCharge(chargeId);
        }
        //כרטיס אשראי
        public int InsertCreditCard(CreditCard creditCard)
        {
            MyDB.CreditCard.Add(creditCard);
            MyDB.SaveChanges();
            return creditCard.CreditCardID;
        }
        public void UpdateCreditCard(CreditCard creditCard)
        {
            MyDB.CreditCard.Attach(creditCard);
            MyDB.SaveChanges();
        }
        public void DeleteCreditCard(int creditCardId)
        {
            MyDB.DeleteCreditCard(creditCardId);
        }
        //הוראת קבע
        public int InsertHorahatKeva(HorahatKeva horahatKeva)
        {
            MyDB.HorahatKeva.Add(horahatKeva);
            MyDB.SaveChanges();
            return horahatKeva.HorahatKevaID;
        }
        public void UpdateHorahatKeva(HorahatKeva horahatKeva)
        {
            MyDB.HorahatKeva.Attach(horahatKeva);
            MyDB.SaveChanges();
        }
        public void DeleteHorahatKeva(int horahatKevaId)
        {
            MyDB.DeleteHorahatKeva(horahatKevaId);
        }

        //אמצעי תשלום
        public int  InsertPaymentAccounts(PaymentAccount paymentAccounts)
        {
            MyDB.PaymentAccount.Add(paymentAccounts);
            MyDB.SaveChanges();
            return paymentAccounts.PaymentAccountsID;
        }
        public void DeletePaymentAccounts(int  paymentAccountsId)
        {
            MyDB.DeletePaymentAccount(paymentAccountsId);
            
        }

        public int InsertPayment(PaymentAccount paymentAccounts)
        {
            InsertPaymentAccounts(paymentAccounts);
            if (paymentAccounts.CreditCard != null)
            {
                paymentAccounts.CreditCard.PaymentAccountsID = paymentAccounts.PaymentAccountsID;
                paymentAccounts.CreditCard.CreditCardID = paymentAccounts.PaymentAccountsID;
                InsertCreditCard(paymentAccounts.CreditCard);
            }
            else if (paymentAccounts.HorahatKeva != null)
            {
                paymentAccounts.HorahatKeva.PaymentAccountsID = paymentAccounts.PaymentAccountsID;
                paymentAccounts.HorahatKeva.HorahatKevaID = paymentAccounts.PaymentAccountsID;
                InsertHorahatKeva(paymentAccounts.HorahatKeva);
            }


            return paymentAccounts.PaymentAccountsID;
        }
        public void DeletePayment_CreditCard(int paymentAccountsId, int creditCardId)
        {
            MyDB.DeletePaymentAccount(paymentAccountsId);
            MyDB.DeleteCreditCard(creditCardId);
        }
        public void DeletePayment_HOK(int paymentAccountsId, int hokId)
        {
            MyDB.DeletePaymentAccount(paymentAccountsId);
            MyDB.DeleteHorahatKeva(hokId);
        }




        #endregion

    }
}
