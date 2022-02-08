using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_lab.Models
{
    public enum StatusOrder
    {
        open, work, close
    }

    public class Order
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Topic { get; set; }
        public StatusOrder Status { get; set; } 
        public string description { get; set; }
        [Required]
        public int Price { get; set; }
        public Guid IdExecuter { get; set; }
        public Guid IdCustomer { get; set; }
    }


}
