using AutoMapper;
using ProDigiMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVm : IMapFrom<IMapFrom<ProDigiMVC.Domain.Model.Customer>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string CEOFullName { get; set; }
        public string FirstLineContactInformation { get; set; }
        public List<AddressForListVm> Addresses { get; set; }
        public List<ContactDetailListVm> Emails { get; set; }
        public List<ContactDetailListVm> PhoneNumbers { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProDigiMVC.Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(c => c.CEOFullName,
                opt => opt.MapFrom(cd => cd.CEOFirstName + " " + cd.CEOLastName))
                //.ForMember(c => c.FirstLineContactInformation,
                //opt => opt.MapFrom(cd => cd.CustomerContactInformation.FirstName +
                //" " + cd.CustomerContactInformation.LastName))
                .ForMember(c=>c.FirstLineContactInformation, opt => opt.Ignore()) /// zmienić jak się uda ogarnąć
                .ForMember(c => c.Emails, opt => opt.Ignore())
                .ForMember(c => c.Addresses, opt => opt.Ignore())
                .ForMember(c => c.PhoneNumbers, opt => opt.Ignore());
        }
    }
}
