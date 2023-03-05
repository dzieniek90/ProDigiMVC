using System.ComponentModel;

namespace ProDigiMVC.Web.Models
{
    public class BaseModel
    {
        [DisplayName("Identyfikator")]

        public int Id { get; set; }
    }
}
