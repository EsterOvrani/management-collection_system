using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrAhemet
{
    public class Global
    {
        public static ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public static ServiceReference1.Family currentFamily;
        public static List<ServiceReference1.Family>  currentFamilies;
        public static List<ServiceReference1.Transaction>  transactions;
        public static ServiceReference1.User currentUser;
        public static int UserStatus = 1; // 1. read  2.edit 3. add 
    }
}
