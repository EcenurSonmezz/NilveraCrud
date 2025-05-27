using MediatR;
using Nilvera.Domain.Entities;
using Nilvera.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Nilvera.Application.Features.Firma.Commands
{
    public class CreateFirmaCommandHandler : IRequestHandler<CreateFirmaCommand, int>
    {
        private readonly IFirmaRepository _repository;

        public CreateFirmaCommandHandler(IFirmaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateFirmaCommand request, CancellationToken cancellationToken)
        {
            var firma = new Nilvera.Domain.Entities.Firma
            {
                FirmaAdi = request.FirmaAdi,
                VknTc = request.VknTc,
                KullaniciAdi = request.KullaniciAdi,
                AktifMi = request.AktifMi,
                Adres = request.Adres,
                Ilce = request.Ilce,
                Sehir = request.Sehir,
                Ulke = request.Ulke,
                PostaKodu = request.PostaKodu,
                Telefon = request.Telefon,
                Faks = request.Faks,
                WebSitesi = request.WebSitesi,
                Eposta = request.Eposta,
                VergiDairesi = request.VergiDairesi
            };

            return await _repository.InsertAsync(firma);
        }
    }
}
