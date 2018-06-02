using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryControl.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public int Age { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phno { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}