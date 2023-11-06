using System;
namespace BlazorLab2.Models
{
	public class InstrumentDatabaseSettings
	{
   
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string InstrumentCollectionName { get; set; } = null!;
    
}
}

