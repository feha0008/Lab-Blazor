using BlazorLab2.Data;
using BlazorLab2.Models;


namespace BlazorLab2.Pages
{
    public partial class AddArtist
    {
        private List<Artist>? artistsList;
        private Artist artist = new Artist();
        private List<Album> albums = new List<Album>();
        private List<int> selectedAlbumIds = new List<int>();

        private async void AddNewArtist()
        {

           artist.Albums = albums.Where(album => selectedAlbumIds.Contains(album.Id)).ToList();
 
           await artistService.AddArtist(artist);
           artist = new Artist();
           selectedAlbumIds.Clear();
           NavigationManager.NavigateTo("/artists");
        }

        //Gets the List of albums to show in the AddArtist page
        protected override async Task OnInitializedAsync()
        {
            albums = await albumService.GetAlbumList();

        }

    }
}
