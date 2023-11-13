using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientEntity: BaseEntity
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public DateTime Date { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Comment { get; set; }
    }
}
