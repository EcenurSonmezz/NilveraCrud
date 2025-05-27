using System;
using MediatR;
using Nilvera.Domain.Entities;
using Nilvera.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilvera.Application.Features.Firma.Commands
{
    public class UpdateFirmaCommandHandler : IRequestHandler<UpdateFirmaCommand, int>
    {
        private readonly IFirmaRepository _repository;

        public UpdateFirmaCommandHandler(IFirmaRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateFirmaCommand request, CancellationToken cancellationToken)
        {
            var firma = new Nilvera.Domain.Entities.Firma
            {
                Id = request.Id,
                FirmaAdi = request.FirmaAdi,
                VknTc = request.VknTc,
                KullaniciAdi = request.KullaniciAdi,
                AktifMi = request.AktifMi,

                // Adres bilgileri
                Adres = request.Adres,
                Ilce = request.Ilce,
                Sehir = request.Sehir,
                Ulke = request.Ulke,
                PostaKodu = request.PostaKodu,

                // İletişim
                Telefon = request.Telefon,
                Faks = request.Faks,
                WebSitesi = request.WebSitesi,
                Eposta = request.Eposta,

                // Vergi
                VergiDairesi = request.VergiDairesi
            };
            return await _repository.UpdateAsync(firma);
        }
    }
}
