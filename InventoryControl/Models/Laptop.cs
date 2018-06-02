using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryControl.Models
{
    public class Laptop
    {
        [Key]
        public int Laptop_ID { get; set; }
        public Category CATEGORY { get; set; }
        public string Name { get; set; }
        public string CUP { get; set; }
        public string RAM { get; set; }
        public string CPU_MODEL { get; set; }
        public string STORAGE { get; set; }
        public string SCREEN { get; set; }
        public string OS { get; set; }
        public string OTHER_SPEC { get; set; }

        [DisplayName("Price ($)")]
        public int PRICE { get; set; }

    }

    public enum Category
    {
        Macbook,
        HP,
        Acer,
        Lenovo,
        Dell,
        Asus
    }
}