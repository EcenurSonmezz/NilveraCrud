namespace Nilvera.Domain.Entities
{
    public class Firma
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string VknTc { get; set; }
        public string KullaniciAdi { get; set; }
        public bool AktifMi { get; set; }

        // Adres bilgileri
        public string Adres { get; set; }
        public string Ilce { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public string PostaKodu { get; set; }

        // İletişim
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string WebSitesi { get; set; }
        public string Eposta { get; set; }

        // Vergi
        public string VergiDairesi { get; set; }
    }
}
