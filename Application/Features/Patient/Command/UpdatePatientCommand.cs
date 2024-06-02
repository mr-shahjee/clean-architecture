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
    public class UpdatePatientCommand : IRequest<ApiResponse<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnic { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Contact { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Comment { get; set; }
    }

    internal class UpdateProductCommandHandler : IRequestHandler<UpdatePatientCommand, ApiResponse<int>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<int>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {

            var patient = await _context.Patients.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (patient != null)
            {
                patient.Name = request.Name;
                patient.Cnic = request.Cnic;
                patient.Gender = request.Gender;
                patient.Age = request.Age;
                patient.Contact = request.Contact;
                patient.AppointmentDate = request.AppointmentDate;
                patient.Comment = request.Comment;
 
                await _context.SaveChangesAsync();
                //return patient.Id;
                return new ApiResponse<int>(patient.Id, "Record Updated Successfully!");

            }
            else
            {
                //return default;
                throw new ApiExceptions("Product not found!");
            }
        }
    }
}
