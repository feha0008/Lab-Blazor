using System;
using BlazorLab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace BlazorLab2.Data
{
	public class InstrumentService
	{
        private readonly IMongoCollection<Instrument> _instrumentsCollection;


        public InstrumentService(
            IOptions<InstrumentDatabaseSettings> instrumentDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                instrumentDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                instrumentDatabaseSettings.Value.DatabaseName);

            _instrumentsCollection = mongoDatabase.GetCollection<Instrument>(
                instrumentDatabaseSettings.Value.InstrumentCollectionName);
        }


        public async Task AddInstrument(Instrument instrument)
        {

            await _instrumentsCollection.InsertOneAsync(instrument);
            
        }

        public async Task<Instrument?> GetInstrument(string Id)
        {
        
            return await _instrumentsCollection.Find(x => x.Id == Id).FirstOrDefaultAsync(); ;
        }

        public async Task<List<Instrument>> GetInstrumentList()
        {
            var instrument = new List<Instrument>();
            instrument = await _instrumentsCollection.Find(_ => true).ToListAsync();

            return await Task.FromResult(instrument);
        }

        //public async Task<List<Instrument>> GetAsync() =>
        //    await _instrumentsCollection.Find(_ => true).ToListAsync();

        //public async Task<Instrument?> GetAsync(string id) =>
        //    await _instrumentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //public async Task CreateAsync(Instrument newInstrument) =>
        //    await _instrumentsCollection.InsertOneAsync(newInstrument);

        //public async Task UpdateAsync(string id, Instrument updatedInstrument) =>
        //    await _instrumentsCollection.ReplaceOneAsync(x => x.Id == id, updatedInstrument);

        //public async Task RemoveAsync(string id) =>
        //    await _instrumentsCollection.DeleteOneAsync(x => x.Id == id);
    }		
}

