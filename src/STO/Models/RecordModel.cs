using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class RecordModel
    {
        public string Id { get; set; }
        public string STOId { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string FIO { get; set; }
        public string ModelCar { get; set; }
        public RecordModel()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
