using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSimpCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string city { get; set; }
        public bool Isactive { get; set; }
    }
}