
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryControl.Models
{
    public class Orders
    {
        [Key]
        public int Order_ID { get; set; }

        [DisplayName("Order No#")]
        public string Order_NO { get; set; }
        
        [DisplayName("Purchased On")]
        public string Purchased_On { get; set; }

        [DisplayName("Ship to Name")]
        public string Customer_Name { get; set; }

        [DisplayName("Ship to Address")]
        public string Customer_Address { get; set; }        

        [DisplayName("Charges")]
        public float Charges { get; set; }

        [DisplayName("Orders Items")]
        public string Order_Items { get; set; }
    }

  
}