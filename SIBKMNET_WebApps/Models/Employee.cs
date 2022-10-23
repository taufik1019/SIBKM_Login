using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
