using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patient.Queries
{
    public class GetAllPatientQuery : IRequest<IEnumerable<Domain.Entities.Patient>>
    {
        internal class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, IEnumerable<Domain.Entities.Patient>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPatientQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Domain.Entities.Patient>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
            {

                var result = await _context.Patients.ToListAsync<Domain.Entities.Patient>(cancellationToken);
                return result;

            }
        }
    }


}
