using System.Net.Http;
using System.Net.Http.Headers;

namespace GroundHogDayApi
{
    public class GroundHogDay
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://groundhog-day.com/api/v1";
        
        public GroundHogDay()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetGroundHogs()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/groundhogs");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetGroundHog(string slug)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/groundhog/{slug}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPredictions(int year)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/predictions?year={year}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
