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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Riverside_HoldingsEntities1 : DbContext
    {
        public Riverside_HoldingsEntities1()
            : base("name=Riverside_HoldingsEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADMINISTRATOR> ADMINISTRATORS { get; set; }
        public virtual DbSet<CLIENT_PAYMENTS> CLIENT_PAYMENTS { get; set; }
        public virtual DbSet<CLIENT> CLIENTS { get; set; }
        public virtual DbSet<INVOICE_ITEM> INVOICE_ITEM { get; set; }
        public virtual DbSet<INVOICE_NOTES> INVOICE_NOTES { get; set; }
        public virtual DbSet<INVOICE> INVOICES { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
    }
}
