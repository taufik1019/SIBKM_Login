using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        

    }
}
