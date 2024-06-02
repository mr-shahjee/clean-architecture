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
    public class GetAllPatientQuery : IRequest<ApiResponse<IEnumerable<Domain.Entities.Patient>>>
    {
        internal class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, ApiResponse<IEnumerable<Domain.Entities.Patient>>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPatientQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ApiResponse<IEnumerable<Domain.Entities.Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
            {

                var result = await _context.Patients.ToListAsync<Domain.Entities.Patient>(cancellationToken);
                if (result == null)
                {
                    throw new ApiExceptions("Product not found!");
                }
                return new ApiResponse<IEnumerable<Domain.Entities.Patient>>(result, "Record Fetched Successfully!");
               // return result;

            }
        }
    }


}
