using STO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.ViewModels
{
    public class STOCardModel
    {
        public string Name { get; set; }
        public string Services { get; set; }
        public string Adres { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public string Description { get; set; }
        public string Contacts { get; set; }
        public double Rating { get; set; }
        public List<Comment> Coments{ get; set; }
    }
}
