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
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Rate { get; set; }
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            // logic
            return 1;
        }
    }
}
