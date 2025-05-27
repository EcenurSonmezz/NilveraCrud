using MediatR;

namespace Nilvera.Application.Features.Firma.Commands
{
    public class CreateFirmaCommand : IRequest<int>
    {
        public string FirmaAdi { get; set; }
        public string VknTc { get; set; }
        public string KullaniciAdi { get; set; }
        public bool AktifMi { get; set; }
        public string Adres { get; set; }
        public string Ilce { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public string PostaKodu { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string WebSitesi { get; set; }
        public string Eposta { get; set; }
        public string VergiDairesi { get; set; }
    }
}
