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
    
    public class GetPatientByIdQuery : IRequest<Domain.Entities.Patient>
    {
        public int Id {get; set;}
        internal class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Domain.Entities.Patient>
        {
            private readonly IApplicationDbContext _context;
            public GetPatientByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Domain.Entities.Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
            {

                var result = await _context.Patients.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return result;

            }
        }
    }


}
