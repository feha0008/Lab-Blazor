using System;
using BlazorLab2.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorLab2.Pages
{
	public partial class EditAlbum
	{
        [Parameter]
        public int Id { get; set; }
        private Album album = new Album();
        private List<Artist> artists = new List<Artist>();

        private async void UpdateAlbum()
        {
            await albumService.SaveUpdatedAlbum(album);
            NavigationManager.NavigateTo("/albums");
        }

        protected override async Task OnInitializedAsync()
        {
            artists = await artistService.GetArtistList();
            if (Id != 0)
            {
                album = await albumService.GetAlbum(Id);

            }
        }
    }
}

