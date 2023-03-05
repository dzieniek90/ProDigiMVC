using System.ComponentModel;

namespace ProDigiMVC.Web.Models
{
    public class Order : BaseModel
    {
        [DisplayName("Typ zlecenia")]
        public string OrderType { get; set; }

        [DisplayName("Nazwa produktu")]
        public string ProductName { get; set; }

        [DisplayName("Zamówiona liczba")]
        public int Quantity { get; set; }

        [DisplayName("Firma zlecająca")]
        public string Company { get; set; }

        [DisplayName("Status zlecenia")]
        public string Status { get; set; }
    }
}