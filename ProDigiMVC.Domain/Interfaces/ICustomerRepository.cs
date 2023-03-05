using ProDigiMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        void EditCustomer(Customer editedCustomer);

        Customer GetCustomer(int customerId);

        IQueryable<Customer> GetAllCustomers();

        void DeleteCustomer(int customerId);
        IQueryable<ContactDetailType> GetAllContactDetailTypes();
        IQueryable<Customer> GetAllActiveCustomers();
    }
}
