using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCproject.Models
{
    public class ClientMVC
    {
        public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "Too many chars")]
        [StringLength(10, ErrorMessage = "Too many chars")]
        public string Name { get; set; }
    }
}