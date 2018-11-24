using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryControl.Models
{
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}