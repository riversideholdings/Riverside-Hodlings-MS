//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Riverside_Hodlings___System01___Db2___Ent_Framework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENT_PAYMENTS
    {
        public int PAYMENT_ID { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string CLIENT_ID { get; set; }
    
        public virtual CLIENT CLIENT { get; set; }
    }
}