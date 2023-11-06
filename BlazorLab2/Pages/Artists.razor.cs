using System;
using System.Reflection.Metadata;
using BlazorLab2.Data;
using BlazorLab2.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorLab2.Pages
{
	public partial class Artists
	{

		private List<Artist>? artistsList;
		private Artist artist = new Artist();

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
		{
			artistsList = await artistService.GetArtistList();
		}


        private async void DeleteArtist(int Id)
		{
            await artistService.DeleteArtist(Id);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
	}
}

