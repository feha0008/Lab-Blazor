using System;
using BlazorLab2.Models;
using BlazorLab2.Pages;
using Microsoft.EntityFrameworkCore;

namespace BlazorLab2.Data
{
	public class AlbumService
	{

        ArtistContext context = new ArtistContext();

        public async Task AddAlbum(Album album)
        {

            Artist selectedArtist = context.Artists.Find(album.ArtistId);
            if (selectedArtist != null)
            {
                album.Artists.Add(selectedArtist);

            }
          
            context.Albums.Add(album);
            await context.SaveChangesAsync();
        }

        public async Task<Album?> GetAlbum(int Id)
        {
            var album = context.Albums.Where(a => a.Id==Id).FirstOrDefault();
            return await Task.FromResult(album);
        }


        public async Task<List<Album>> GetAlbumList()
        {
            var album = new List<Album>();
            album = context.Albums.Include(a=>a.Artists).ToList();


            return await Task.FromResult(album);
        }



        public async Task SaveUpdatedAlbum(Album album)
        {
            Album? albumInDb = context.Albums.Find(album.Id);
            Artist selectedArtist = context.Artists.Find(album.ArtistId);

            if (albumInDb != null)
            {
                albumInDb.Title = album.Title;
                albumInDb.Year = album.Year;
                albumInDb.Id = album.Id;

                if (selectedArtist != null)
                {
                    album.Artists.Add(selectedArtist);
                }

                context.Albums.Update(album);
                await context.SaveChangesAsync();

            }

        }


        public async Task DeleteAlbum(int albumId)
        {
            Album? albumInDb = context.Albums.Find(albumId);

            if (albumInDb != null)
            {
                context.Albums.Remove(albumInDb);
                await context.SaveChangesAsync();
            }
            
        }
    }
}

