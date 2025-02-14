public class MenuService : IMenuDataService
{
    private readonly HttpClient _httpClient;
    public MenuService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("http://localhost:5500/");
    }
    public async Task<List<Menu>> GetAllMenuAsync()
    {
        /* if (_httpClient.BaseAddress == null)
        {
            throw new InvalidOperationException("BaseAddress cannot be null.");
        } */
        var data = await _httpClient.GetFromJsonAsync<List<Menu>>("http://localhost:5500/api/Menu");
        if (data == null)
        {
            throw new InvalidOperationException("Data cannot be null.");
        }
        return data;
    }

    public async Task<Menu> GetMenuByIdAsync(int id)
    {
        if (_httpClient.BaseAddress == null)
        {
            throw new InvalidOperationException("BaseAddress cannot be null.");
        }
        var data = await _httpClient.GetFromJsonAsync<Menu>("http://localhost:5500/" + $"api/Menu/{id}");
        if (data == null)
        {
            throw new InvalidOperationException("Data cannot be null.");
        }
        return data;
    }


    public async Task CreateMenuAsync(Menu newMenu)
    {
        await _httpClient.PostAsJsonAsync("api/Menu", newMenu);
    }

    public async Task UpdateMenuAsync(int id, Menu updatedMenu)
    {
        await _httpClient.PutAsJsonAsync($"api/Menu/{id}", updatedMenu);
    }

    public async Task DeleteMenuAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Menu/{id}");
    }
}
