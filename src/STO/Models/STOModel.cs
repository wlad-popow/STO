using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class STOModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Services { get; set; }
        public string Adres { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public string Description { get; set; }
        public string Contacts { get; set; }
        public string Rajon { get; set; }        
    }
}
