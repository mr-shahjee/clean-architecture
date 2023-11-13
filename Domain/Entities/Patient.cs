using Domain.Common;

namespace Domain.Entities
{
    public class Patient: BaseEntity
    {
        public string Name {get; set;}
        public string Cnic {get; set;}
        public string Gender {get; set;}
        public string Age {get; set;}
        public string Contact {get; set;}
        public DateTime AppointmentDate {get; set;}
        public string Comment {get; set;}

    }
}