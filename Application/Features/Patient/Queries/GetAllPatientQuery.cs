using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries
{
    public class GetAllPatientQuery: IRequest<IEnumerable<Patient>>
    {
        internal class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, IEnumerable<Patient>>
        {
            public async Task<IEnumerable<Patient>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
            {

                var list = new List<Patient>();
                for (int i = 0; i < 100; i++)
                {
                    Patient patient = new Patient();
                    patient.Name = "ToothBrush";
                    patient.Description = "Using Tooth Brush is good for teeth";
                    patient.Rate = 40 + i;

                    list.Add(patient);       
                }
                return list;
            }
        }
    }

    public class Patient
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Rate { get; set; }
    }

}
