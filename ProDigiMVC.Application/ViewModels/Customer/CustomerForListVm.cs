using AutoMapper;
using ProDigiMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Application.ViewModels.Customer
{
    public class CustomerForListVm : IMapFrom<ProDigiMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProDigiMVC.Domain.Model.Customer, CustomerForListVm>();          
        }
    }
}
