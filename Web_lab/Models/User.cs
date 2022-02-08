using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_lab.Models
{
    public enum TypeUser
    {
        executor, customer
    }
    public class User
    {  
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NunberOrders { get; set; }
        public TypeUser Type { get; set; }
    }
}
