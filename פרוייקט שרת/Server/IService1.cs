using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
         #region Login Page
        //שליפה
        [OperationContract]
        List<User> GetUserTable();
        #endregion

         #region Family Page
        //שליפה
        [OperationContract]
        List<Family> GetFamilyTable();
        [OperationContract]
        List<Transaction> GetTransactionsWithDebts();
        [OperationContract]
        List<Transaction> GetTransactionsWithoutDebts();
        [OperationContract]
        Charge GetChargeByID(int chargesID);

        //עידכון, מחיקה, הוספה
        //משתמש
        [OperationContract]
        int InsertUser(User user);
        [OperationContract]
        void UpdateUser(User user);
        [OperationContract]
        void DeleteUser(int userId);
        //משפחה
        [OperationContract]
        int InsertFamily(Family family);
        [OperationContract]
        void DeleteFamily(int familyId);
        #endregion

         #region Details Family Page
        //שליפה
        [OperationContract]
        Family GetFamilyByID(int FamilyID);
        [OperationContract]
        List<Child> GetChildrenByFamilyID(Family family);
        [OperationContract]
        List<PaymentAccount> GetPaymentAccountsByFamilyID(Family family);
        [OperationContract]
        CreditCard GetCreditCardByID(int creditCardID);
        [OperationContract]
        CreditCard GetCreditCardByPaymentAccountID(int paymentAccountID);
        [OperationContract]
        HorahatKeva GetHorahatKevaByID(int horahatKevaID);
        [OperationContract]
        HorahatKeva GetHorahatKevaByPaymentAccountID(int paymentAccountID);
        [OperationContract]
        List<Charge> GetChargesByFamilyID(Family family);
        [OperationContract]
        Child GetChildByID(int childID);
        [OperationContract]
        TypeCharge GetTypeChargeByID(int typeChargeID);

        //עידכון, מחיקה, הוספה
        //ילדים
        [OperationContract]
        int InsertChild(Child child);
        [OperationContract]
        void UpdateChild(Child child);
        [OperationContract]
        void DeleteChild(int childId);
        //משפחה
        [OperationContract]
        void UpdateFamily(Family family);
        //תנועות
        [OperationContract]
        int InsertTransaction(Transaction transaction);
        [OperationContract]
        void UpdateTransaction(Transaction transaction);
        //חיובים
        [OperationContract]
        int InsertCharge(Charge charge);
        [OperationContract]
        void UpdateCharge(Charge charge);
        [OperationContract]
        void DeleteCharge(int chargeId);
        //כרטיס אשראי
        [OperationContract]
        int InsertCreditCard(CreditCard creditCard);
        [OperationContract]
        void UpdateCreditCard(CreditCard creditCard);
        [OperationContract]
        void DeleteCreditCard(int creditCardId);
        //הוראת קבע
        [OperationContract]
        int InsertHorahatKeva(HorahatKeva horahatKeva);
        [OperationContract]
        void UpdateHorahatKeva(HorahatKeva horahatKeva);
        [OperationContract]
        void DeleteHorahatKeva(int horahatKevaId);
        //אמצעי תשלום
        [OperationContract]
        int InsertPaymentAccounts(PaymentAccount paymentAccounts);
        [OperationContract]
        int InsertPayment(PaymentAccount paymentAccounts);
        //[OperationContract]
        //void DeletePayment(int paymentAccountsId);
        [OperationContract]
        void DeletePayment_CreditCard(int paymentAccountsId, int creditCardId);
        [OperationContract]
        void DeletePayment_HOK(int paymentAccountsId, int hokId);

        [OperationContract]
        void DeletePaymentAccounts(int paymentAccountsId);


        #endregion
    }
}
