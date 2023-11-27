using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Command
{
    public class DeletePatientCommand : IRequest<int>
    {
        public int Id { get; set; }

    }

    internal class DeleteProductCommandHandler : IRequestHandler<DeletePatientCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (patient == null)
            {
                return default;
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return request.Id;
        }
    }
}
