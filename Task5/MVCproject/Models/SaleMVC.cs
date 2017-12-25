using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCproject.Models
{
    public class SaleMVC
    {
        public int Id { get; set; }

        public DataType Date { get; set; }

        public decimal Sum { get; set; }

        public int ManagerId { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }
    }
}