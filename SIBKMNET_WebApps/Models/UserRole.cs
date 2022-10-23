using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Models
{
    public class UserRole
    {

        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}
