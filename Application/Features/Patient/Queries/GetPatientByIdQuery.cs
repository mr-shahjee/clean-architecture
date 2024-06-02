using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
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
    
    public class GetPatientByIdQuery : IRequest<ApiResponse<Domain.Entities.Patient>>
    {
        public int Id {get; set;}
        internal class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, ApiResponse<Domain.Entities.Patient>>
        {
            private readonly IApplicationDbContext _context;
            public GetPatientByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ApiResponse<Domain.Entities.Patient>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
            {

                var result = await _context.Patients.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new ApiExceptions("Product not found!");
                }
                return new ApiResponse<Domain.Entities.Patient>(result, "Record Fetched Successfully!");

            }
        }
    }


}
