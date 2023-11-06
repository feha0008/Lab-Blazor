using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorLab2.Pages
{
	public partial class CallAPI
	{
        private string genre;
        private List<string> genres = new List<string>();


        private async Task GetRandomGenres()
        {
            genres.Clear();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //displays 5 genres at a time
                    for (int i = 0; i < 5; i++)
                    {
                        var apiUrl = "v1/genre";


                        genre = await genreService.GetDataFromApiAsync(apiUrl);
                        genres.Add(genre);


                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions 
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

