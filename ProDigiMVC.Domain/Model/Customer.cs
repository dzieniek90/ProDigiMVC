using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProDigiMVC.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  NIP { get; set; }
        public string REGON { get; set; }
        public string CEOFirstName { get; set; }
        public string  CEOLastName { get; set; }
        public bool IsActive { get; set; }
        public byte[] LogoPicture { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        //public int CustomerContactInformationRef { get; set; }
        public CustomerContactInformation CustomerContactInformation { get; set; }
    }
}
