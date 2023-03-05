using System.ComponentModel;

namespace ProDigiMVC.Web.Models
{
    public class Product : BaseModel
    {

        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("Wersja")]
        public string Version { get; set; }

        [DisplayName("Projektant")]
        public string Designer { get; set; }
    }
}