using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace BlazorLab2.Models
{
	public class Instrument
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string InstrumentName { get; set; } = null!;

        public string Category { get; set; } = null!;

      
    }
}

