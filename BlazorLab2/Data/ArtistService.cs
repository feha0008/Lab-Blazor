using System;
using BlazorLab2.Models;
using BlazorLab2.Pages;
using Microsoft.EntityFrameworkCore;

namespace BlazorLab2.Data
{
	public class ArtistService
	{
        ArtistContext context = new ArtistContext();


        public async Task AddArtist(Artist artist)
        {
            Album selectedAlbum = context.Albums.Find(artist.AlbumId);

            //check if an album has been selected and if it should be added to artist.Albums
            if (selectedAlbum!=null)
            {
                 artist.Albums.Add(selectedAlbum);
            }

            context.Artists.Add(artist);
            await context.SaveChangesAsync();
        }

        public async Task<Artist?> GetArtist(int Id)
        {
            var artist = context.Artists.Where(a => a.Id == Id).FirstOrDefault();
            return await Task.FromResult(artist);
        }

        public async Task<List<Artist>> GetArtistList()
		{
			var artist = new List<Artist>();
			artist = context.Artists.Include(a => a.Albums).ToList();

			return await Task.FromResult(artist);
		}

       

        public async Task SaveUpdatedArtist(Artist artist)
        {
            Artist? artistInDb = context.Artists.Find(artist.Id);
            Album selectedAlbum = context.Albums.Find(artist.AlbumId);

            if (artistInDb != null)
            {
                artistInDb.Id = artist.Id;
                artistInDb.Name = artist.Name;
                artistInDb.Country = artist.Country;
                if (selectedAlbum!=null)
                {
                    artist.Albums.Add(selectedAlbum);

                }
                

                context.Artists.Update(artist);
                await context.SaveChangesAsync();

            }
            
        }
       

        public async Task DeleteArtist(int artistId)
		{
			Artist? artistInDb = context.Artists.Find(artistId);
          

            if (artistInDb!=null)
			{
                context.Artists.Remove(artistInDb);
                await context.SaveChangesAsync();
            }
			
		}

        
    }
}

