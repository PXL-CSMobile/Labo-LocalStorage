using PieShop.App.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace PieShop.App.Services
{
    internal class PieApiRepository : IPieRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public PieApiRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Pie>> GetAllPies()
        {
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                    return new List<Pie>();

                var pies = await _client.GetFromJsonAsync<List<Pie>>("pies", _jsonOptions);
                return pies ?? new List<Pie>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Er ging iets mis bij het ophalen van de data.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("De server stuurde onverwachte data terug.", ex);
            }
        }

        //Deze methode gebruikt _client.GetStringAsync
        //public async Task<List<Pie>> GetAllPies()
        //{
        //    try
        //    {
        //        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        //            return new List<Pie>();

        //        string result = await _client.GetStringAsync("pies");

        //        var pies = JsonSerializer.Deserialize<List<Pie>>(result, _jsonOptions);
        //        return pies ?? new List<Pie>();
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw new Exception("Er ging iets mis bij het ophalen van de data.", ex);
        //    }
        //}

        //Deze methode gebruikt _client.GetAsync()
        //public async Task<List<Pie>> GetAllPies()
        //{
        //    if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        //        return new List<Pie>();

        //    HttpResponseMessage result = await _client.GetAsync("pies");

        //    if(result.IsSuccessStatusCode)
        //    {
        //        string content = await result.Content.ReadAsStringAsync();
        //        var pies = JsonSerializer.Deserialize<List<Pie>>(content, _jsonOptions);
        //        return pies ?? new List<Pie>();
        //    }
        //    else
        //    {
        //        return new List<Pie>();
        //    }
        //}

        public async Task<Pie?> GetPie(Guid id)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                    return null;

                Pie? pie = await _client.GetFromJsonAsync<Pie>("pies");
                return pie;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Er ging iets mis bij het ophalen van de data.", ex);
            }
            catch (JsonException ex)
            {
                // De API stuurde geen geldige JSON terug, of het model klopt niet
                throw new Exception("De server stuurde onverwachte data terug.", ex);
            }
        }

        public async Task AddPie(Pie pie)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                    return;

                HttpResponseMessage response = await _client.PostAsJsonAsync<Pie>("pies", pie);
                response.EnsureSuccessStatusCode();

                Pie? pieCreated = await response.Content.ReadFromJsonAsync<Pie>();
                pie.Id = pieCreated?.Id ?? Guid.Empty;
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Er ging iets mis bij het wegschrijven van de data.", ex);
            }
            catch (JsonException ex)
            {
                // De API stuurde geen geldige JSON terug, of het model klopt niet
                throw new Exception("De server stuurde onverwachte data terug.", ex);
            }
        }



        public async Task UpdatePie(Pie pie)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                    return;

                HttpResponseMessage response = await _client.PutAsJsonAsync<Pie>("pies", pie);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Er ging iets mis bij het wegschrijven van de data.", ex);
            }
            catch (JsonException ex)
            {
                // De API stuurde geen geldige JSON terug, of het model klopt niet
                throw new Exception("De server stuurde onverwachte data terug.", ex);
            }
        }
    }
}
