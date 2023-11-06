using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLab2.Models
{
	public class Album
	{

		public int Id { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }

		public List<Artist>? Artists { get; set; }

		[NotMapped]
        public int ArtistId { get; set; }


        public Album()
		{
		}
	}
}

