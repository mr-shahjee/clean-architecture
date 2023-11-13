using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries
{
    public class GetAllPatientQuery: IRequest<IEnumerable<Domain.Entities.Patient>>
    {
        internal class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, IEnumerable<Domain.Entities.Patient>>
        {
            public async Task<IEnumerable<Domain.Entities.Patient>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
            {

                var list = new List<Domain.Entities.Patient>();
                for (int i = 0; i < 100; i++)
                {
                    var patient = new Domain.Entities.Patient();
                    patient.Name = "Shah";
                    patient.Cnic = "12345-1234567-5";
                    patient.Gender = "Male";
                    patient.Age = "24";
                    patient.Contact = "+92-321112311";
                    patient.Comment = "Good person";
                    list.Add(patient);       
                }
                return list;
            }
        }
    }

}
