using MongoDB.Driver;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;

namespace RegistroTramitesOplagestTrifinio.Services.Implementaciones
{
    public class InstructivosService : IInstructivosService
    {
        private readonly IMongoCollection<InstructivoModel> _collection;

        public InstructivosService(IMongoCollection<InstructivoModel> collection)
        {
            _collection = collection;
        }

        public Task Create(InstructivoModel instructivo)
        {
            return _collection.InsertOneAsync(instructivo);
        }

        public Task Delete(string instructivoId)
        {
            return _collection.DeleteOneAsync(i => i.InstructivoId == instructivoId);
        }

        public Task<InstructivoModel> GetInstructivo(string instructivoId)
        {
            return _collection.FindAsync(i => i.InstructivoId == instructivoId).Result.FirstOrDefaultAsync();
        }

        public Task<List<InstructivoModel>> GetInstructivos()
        {
            throw new NotImplementedException();
        }

        public Task Update(InstructivoModel instructivo)
        {
            return _collection.ReplaceOneAsync(i => i.InstructivoId == instructivo.InstructivoId, instructivo);
        }
    }
}