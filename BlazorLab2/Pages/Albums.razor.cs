using System;
using BlazorLab2.Data;
using System.Reflection.Metadata;
using BlazorLab2.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorLab2.Pages
{
    public partial class Albums
    {

        private List<Album>? albumsList;
        private Album album = new Album();

        [Parameter]
        public int Id { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            albumsList = await albumService.GetAlbumList();
        }
      

        private async Task DeleteAlbum(int Id)
        {
            await albumService.DeleteAlbum(Id);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
    }
}

