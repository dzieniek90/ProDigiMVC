using ProDigiMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNo, string searchString);
        int AddCustomer(NewCustomerVm customer);

        CustomerDetailsVm GetCustomerDetails(int customerId);
    }
}
