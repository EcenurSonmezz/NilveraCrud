using MediatR;
using Nilvera.Application.Features.Firma.Queries;
using Nilvera.Domain.Entities;
using Nilvera.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;


namespace Nilvera.Application.Features.Firma.Handlers
{
    public class GetFirmaByIdQueryHandler : IRequestHandler<GetFirmaByIdQuery, Nilvera.Domain.Entities.Firma>
    {
        private readonly IFirmaRepository _firmaRepository;

        public GetFirmaByIdQueryHandler(IFirmaRepository firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }

        public async Task<Nilvera.Domain.Entities.Firma> Handle(GetFirmaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _firmaRepository.GetByIdAsync(request.Id);

        }
    }
}
