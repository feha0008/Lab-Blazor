using System;
using BlazorLab2.Models;

namespace BlazorLab2.Pages
{
	public partial class AddAlbum
	{
        private List<Album>? albumsList;
        private Album album = new Album();
        private List<Artist> artists = new List<Artist>();
        private List<int> selectedArtistIds = new List<int>();

        private async void AddNewAlbum()
        {
            album.Artists = artists.Where(artist => selectedArtistIds.Contains(artist.Id)).ToList();
            await albumService.AddAlbum(album);
            album = new Album();
            selectedArtistIds.Clear();
            NavigationManager.NavigateTo("/albums");
        }


        //Gets the List of artists to show in the AddAlbum page
        protected override async Task OnInitializedAsync()
        {
            artists = await artistService.GetArtistList();

        }
    }
}

