using Microsoft.Extensions.Options;

namespace ToDoApi
{
    public class RngApiOptions
    {
        public const string RngApiOptionsName = "RngApiOptions";
        public string RngApiUrl {get;set;} = string.Empty;
    }
    
    public class RngApiClient
    {
        private RngApiOptions _rngApiOptions;

        public RngApiClient(IOptions<RngApiOptions> rngApiOptions)
        {
            _rngApiOptions = rngApiOptions?.Value ?? throw new ArgumentNullException(nameof(rngApiOptions));
        }

        public async Task<Guid> GetGuidAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{_rngApiOptions.RngApiUrl}/rng");
                var result = await response.Content.ReadFromJsonAsync<Guid>();
                return result;
            }
        }
    }
}