using AdventurousContactsMVC5.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdventurousContactsMVC5.Models.Repositories
{
    public class Repository : IRepository
    {
        private AdventureWorksEntities _entities = new AdventureWorksEntities();

        public void Add(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }

        public IQueryable<Contact> FindAllContacts()
        {
            return _entities.Contacts.AsQueryable();
        }

        public Contact GetContactById(int contactId)
        {
            return _entities.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            return _entities.Contacts.OrderByDescending(contact => contact.ContactID).Take(count).ToList();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Update(Contact contact)
        {
            // If the object is not tracked.
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                // Track reference to object.
                _entities.Contacts.Attach(contact);
            }

            // The object is modified.
            _entities.Entry(contact).State = EntityState.Modified;
        }

        public void Delete(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }

            _entities.Contacts.Remove(contact);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _entities.Dispose();                   
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // If the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}