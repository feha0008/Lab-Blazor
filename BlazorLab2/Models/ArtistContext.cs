using System;
using Microsoft.EntityFrameworkCore;

namespace BlazorLab2.Models
{
	public class ArtistContext: DbContext 
	{
		public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			options.UseSqlite(@"DataSource= ArtistDB.db");
        }
       public ArtistContext()
		{
		}

		public ArtistContext(DbContextOptions options): base(options)
		{

		}
	}
}

