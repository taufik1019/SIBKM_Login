using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }
    }
}
