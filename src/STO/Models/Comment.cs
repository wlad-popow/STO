using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Comment
    {
        public string Coment { get; set; }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string STOId { get; set; }
        public Comment()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
