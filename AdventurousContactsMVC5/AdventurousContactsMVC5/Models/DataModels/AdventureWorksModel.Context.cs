﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdventurousContactsMVC5.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdventureWorksEntities : DbContext
    {
        public AdventureWorksEntities()
            : base("name=AdventureWorksEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contact> Contacts { get; set; }
    
        public virtual int uspAddContact(string firstName, string lastName, string emailAddress, ObjectParameter contactID)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddContact", firstNameParameter, lastNameParameter, emailAddressParameter, contactID);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspAddContactEF(string firstName, string lastName, string emailAddress)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspAddContactEF", firstNameParameter, lastNameParameter, emailAddressParameter);
        }
    
        public virtual int uspAddContact_OUTPUT(string firstName, string lastName, string emailAddress, ObjectParameter contactID)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddContact_OUTPUT", firstNameParameter, lastNameParameter, emailAddressParameter, contactID);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspAddContact_SELECT(string firstName, string lastName, string emailAddress)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspAddContact_SELECT", firstNameParameter, lastNameParameter, emailAddressParameter);
        }
    
        public virtual ObjectResult<uspGetContact_Result> uspGetContact(Nullable<int> contactID)
        {
            var contactIDParameter = contactID.HasValue ?
                new ObjectParameter("ContactID", contactID) :
                new ObjectParameter("ContactID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetContact_Result>("uspGetContact", contactIDParameter);
        }
    
        public virtual int uspRemoveContact(Nullable<int> contactID)
        {
            var contactIDParameter = contactID.HasValue ?
                new ObjectParameter("ContactID", contactID) :
                new ObjectParameter("ContactID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspRemoveContact", contactIDParameter);
        }
    
        public virtual int uspUpdateContact(Nullable<int> contactID, string firstName, string lastName, string emailAddress)
        {
            var contactIDParameter = contactID.HasValue ?
                new ObjectParameter("ContactID", contactID) :
                new ObjectParameter("ContactID", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateContact", contactIDParameter, firstNameParameter, lastNameParameter, emailAddressParameter);
        }
    }
}
