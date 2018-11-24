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
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public GENDER Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phno { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }

    public enum GENDER
    {
        Male,
        Female
    }
}