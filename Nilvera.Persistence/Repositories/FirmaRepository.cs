using Dapper;
using Nilvera.Domain.Entities;
using Nilvera.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Nilvera.Persistence.Repositories
{
    public class FirmaRepository : IFirmaRepository
    {
        private readonly IDbConnection _dbConnection;

        public FirmaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> InsertAsync(Firma firma)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirmaAdi", firma.FirmaAdi);
            parameters.Add("@VknTc", firma.VknTc);
            parameters.Add("@KullaniciAdi", firma.KullaniciAdi);
            parameters.Add("@AktifMi", firma.AktifMi);
            parameters.Add("@Adres", firma.Adres);
            parameters.Add("@Ilce", firma.Ilce);
            parameters.Add("@Sehir", firma.Sehir);
            parameters.Add("@Ulke", firma.Ulke);
            parameters.Add("@PostaKodu", firma.PostaKodu);
            parameters.Add("@Telefon", firma.Telefon);
            parameters.Add("@Faks", firma.Faks);
            parameters.Add("@WebSitesi", firma.WebSitesi);
            parameters.Add("@Eposta", firma.Eposta);
            parameters.Add("@VergiDairesi", firma.VergiDairesi);

            // OUTPUT parametresi
            parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbConnection.ExecuteAsync("sp_InsertFirma", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("@NewId");
        }

        public async Task<Firma> GetByIdAsync(int id)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Firma>(
                "sp_GetFirmaById",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Firma>> GetAllAsync()
        {
            return await _dbConnection.QueryAsync<Firma>("sp_GetAllFirmas", commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Firma firma)
        {
            return await _dbConnection.ExecuteAsync("sp_UpdateFirma", firma, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbConnection.ExecuteAsync("sp_DeleteFirma", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
