﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public partial class PaymentAccount : BaseEntity
    {
        public CreditCard CreditCard { get; set; }
        public HorahatKeva HorahatKeva { get; set; }
    }
}