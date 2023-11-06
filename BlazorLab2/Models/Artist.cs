using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLab2.Models
{
	public class Artist
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }

		public List<Album>? Albums { get; set; }

		[NotMapped]
		public int AlbumId { get; set; }

		public Artist()
		{
		}
	}
}

