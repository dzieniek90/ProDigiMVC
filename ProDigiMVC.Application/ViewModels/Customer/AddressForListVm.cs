namespace ProDigiMVC.Application.ViewModels.Customer
{
    public class AddressForListVm
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuldingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
    }
}