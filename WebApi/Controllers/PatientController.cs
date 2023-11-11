using Application.Features.Patient.Queries;
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
    }
}
