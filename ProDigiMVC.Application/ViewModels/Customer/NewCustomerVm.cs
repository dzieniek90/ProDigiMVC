using AutoMapper;
using FluentValidation;
using ProDigiMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<IMapFrom<ProDigiMVC.Domain.Model.Customer>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, ProDigiMVC.Domain.Model.Customer>();
        }

    }
    public class NewCustomerValidator : AbstractValidator<NewCustomerVm>
    {
        public NewCustomerValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.NIP).Length(10);
        }
    }
 
}
