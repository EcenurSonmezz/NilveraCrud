using MediatR;
using Nilvera.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilvera.Application.Features.Firma.Commands
{
    public class DeleteFirmaCommandHandler : IRequestHandler<DeleteFirmaCommand, int>
    {
        private readonly IFirmaRepository _repository;

        public DeleteFirmaCommandHandler(IFirmaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteFirmaCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
