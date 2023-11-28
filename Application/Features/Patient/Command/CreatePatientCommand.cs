using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Command
{
    public class CreatePatientCommand : IRequest<int>
    {
        public string Name {get; set;}
        public string Cnic {get; set;}
        public string Gender {get; set;}
        public string Age {get; set;}
        public string Contact {get; set;}
        public DateTime AppointmentDate {get; set;}
        public string Comment {get; set;}
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Domain.Entities.Patient();
            patient.Name = request.Name;
            patient.Cnic = request.Cnic;
            patient.Gender = request.Gender;
            patient.Age = request.Age;
            patient.Contact = request.Contact;
            patient.AppointmentDate = request.AppointmentDate;
            patient.Comment = request.Comment;

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient.Id;
        }
    }
}
