using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryControl.Models
{
    public class Student
    {
        [Key]
        public int Stu_ID { get; set; }
        public string Name { get; set; }
    }
}