using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Command
{
    public class DeletePatientCommand : IRequest<ApiResponse<int>>
    {
        public int Id { get; set; }

    }

    internal class DeleteProductCommandHandler : IRequestHandler<DeletePatientCommand, ApiResponse<int>>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<int>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (patient == null)
            {
                throw new ApiExceptions("Product is not found!");
                //return default;
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            //return request.Id;
            return new ApiResponse<int>(patient.Id, "Record Deleted Successfully!");
        }
    }
}
