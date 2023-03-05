using ProDigiMVC.Domain.Interfaces;
using ProDigiMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context db;
        public CustomerRepository(Context context)
        {
            db = context;
        }
         public int AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.Id;
        }
        public void EditCustomer(Customer editedCustomer)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == editedCustomer.Id);
            customer = editedCustomer;
            db.SaveChanges();
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == customerId);
            return customer;
        }
        
        public IQueryable<Customer> GetAllCustomers()
        {
            var customers = db.Customers;
            return customers;
        }
        
        public IQueryable<Customer> GetAllActiveCustomers()
        {
            var customers = db.Customers.Where(c=>c.IsActive == true);
            return customers;
        }
        
        public void DeleteCustomer(int customerId)
        {
            var customer = db.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
        public IQueryable<ContactDetailType> GetAllContactDetailTypes()
        {
            return db.ContactDetailTypes;
        }
    }
}
