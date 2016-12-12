using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class Evaluation
    {
        public string Id { get; set; }
        public string STOId { get; set; }
        public string UserId { get; set; }
        public int Eval { get; set; }

        public Evaluation()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
