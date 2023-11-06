using System;
using BlazorLab2.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorLab2.Pages
{
	public partial class EditArtist
	{

        [Parameter]
        public int Id { get; set; }
        private Artist artist = new Artist();
        private List<Album> albums = new List<Album>();

        private async void UpdateArtist()
        {
            await artistService.SaveUpdatedArtist(artist);
            NavigationManager.NavigateTo("/artists");
        }


        protected override async Task OnInitializedAsync()
        {
            albums = await albumService.GetAlbumList();
            if (Id != 0)
            {
                artist = await artistService.GetArtist(Id);

            }
        }
        
	}
}

