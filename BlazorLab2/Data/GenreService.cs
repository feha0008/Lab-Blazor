using System;
using BlazorLab2.Models;
using System.Net.Http.Json;
using BlazorLab2.Pages;


namespace BlazorLab2.Data
{
	public class GenreService
    {
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDataFromApiAsync(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle the error or throw an exception.
                return null;
            }
        }



    }
}

