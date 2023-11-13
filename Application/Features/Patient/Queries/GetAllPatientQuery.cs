using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries
{
    public class GetAllPatientQuery: IRequest<IEnumerable<PatientEntity>>
    {
        internal class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, IEnumerable<PatientEntity>>
        {
            public async Task<IEnumerable<PatientEntity>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
            {

                var list = new List<PatientEntity>();
                for (int i = 0; i < 100; i++)
                {
                    PatientEntity patient = new PatientEntity();
                    patient.Name = "Qasim";
                    patient.CNIC = "12312-51351231-2";
                    patient.Contact = "1812893298";
                    patient.Age = "21";
                    patient.Comment = "Hi Qasim how are you";
                    patient.Gender = "Male";
                    patient.Date = new DateTime();
                    list.Add(patient);       
                }
                return list;
            }
        }
    }


}
