﻿using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Command
{
    public class CreatePatientCommand : IRequest<ApiResponse<int>>
    {
        public string Name {get; set;}
        public string Cnic {get; set;}
        public string Gender {get; set;}
        public string Age {get; set;}
        public string Contact {get; set;}
        public DateTime AppointmentDate {get; set;}
        public string Comment {get; set;}
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreatePatientCommand, ApiResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse<int>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            //var patient = new Domain.Entities.Patient();
            //patient.Name = request.Name;
            //patient.Cnic = request.Cnic;
            //patient.Gender = request.Gender;
            //patient.Age = request.Age;
            //patient.Contact = request.Contact;
            //patient.AppointmentDate = request.AppointmentDate;
            //patient.Comment = request.Comment;

            var patient = _mapper.Map<Domain.Entities.Patient>(request);
             
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return new ApiResponse<int>(patient.Id, "Record Created Successfully!");
           // return patient.Id;
        }
    }
}
