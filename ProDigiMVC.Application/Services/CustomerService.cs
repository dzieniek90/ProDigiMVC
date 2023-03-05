using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProDigiMVC.Application.Interfaces;
using ProDigiMVC.Application.Mapping;
using ProDigiMVC.Application.ViewModels.Customer;
using ProDigiMVC.Domain.Interfaces;
using ProDigiMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public int AddCustomer(NewCustomerVm customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            cust.IsActive = true;
            var id = _customerRepo.AddCustomer(cust);    
            return id;
        }

        public ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNo, string searchString)
        {
            var customers = _customerRepo.GetAllActiveCustomers()
                .Where(c=>c.Name.StartsWith(searchString))
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            //ProjectTo dla mapowania kolekcji
            var customersToShow = customers.Skip(pageSize * (pageNo -1)).Take(pageSize).ToList();

            var listCustomers = new ListCustomerForListVm()
            {
                Customers = customersToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = customers.Count
            };
            return listCustomers;
        }

        public CustomerDetailsVm GetCustomerDetails(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);
            // _mapper.Map dla pojedyńczych elementów

            // ogarnąć nested mapping dla reszty
            customerVm.Addresses = new List<AddressForListVm>();
            customerVm.PhoneNumbers = new List<ContactDetailListVm>();
            customerVm.Emails = new List<ContactDetailListVm>();

            //foreach (var address in customer.Addresses)
            //{
            //    var add = new AddressForListVm()
            //    {
            //        Id = address.Id,
            //        AddressType = address.AddressType,
            //        City = address.City,
            //        Street = address.Street,
            //        BuldingNumber = address.BuldingNumber,
            //        FlatNumber = address.FlatNumber,
            //        ZipCode = address.ZipCode,
            //        Country = address.Country,
            //    };
            //    customerVm.Addresses.Add(add);
            //}

            return customerVm;
        }
    }
}
