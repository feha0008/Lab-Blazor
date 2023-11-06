using System;
using BlazorLab2.Data;
using BlazorLab2.Models;

namespace BlazorLab2.Pages
{
	public partial class Instruments
	{
        public string Id { get; set; }
        private List<Instrument>? instrumentsList;
        private Instrument instrument = new Instrument();


        protected override async Task OnInitializedAsync()
        {
            instrumentsList = await instrumentService.GetInstrumentList();
        }



        private async void AddNewInstrument()
        {

            await instrumentService.AddInstrument(instrument);
            instrument = new Instrument();
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);

        }
    }
}

