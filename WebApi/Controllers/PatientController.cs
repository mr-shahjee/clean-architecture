using Application.Features.Patient.Queries;
using Application.Features.Product.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public PatientController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients(CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new GetAllPatientQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPatientById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new GetPatientByIdQuery{Id = id}, cancellationToken);
            return Ok(result);
        }

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand createPatientCommand, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(createPatientCommand, cancellationToken);
            return Ok(result);
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand updatePatientCommand, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(updatePatientCommand, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id, CancellationToken cancellationToken)
        {
            var result = await _mediatR.Send(new DeletePatientCommand{Id = id}, cancellationToken);
            return Ok(result);
        }
        
    }
}
