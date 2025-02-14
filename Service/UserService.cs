public class UserService : IUserDataService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("http://localhost:5500/");
    }

    public async Task<List<User>> GetAllUserAsync()
    {
        var data = await _httpClient.GetFromJsonAsync<List<User>>("api/User");
        if (data == null)
        {
            throw new InvalidOperationException("Data cannot be null.");
        }
        return data;
    }
    public async Task<User> GetUserByIdAsync(int Id)
    {
        var data = await _httpClient.GetFromJsonAsync<User>($"api/User/{Id}");
        if (data == null)
        {
            throw new InvalidOperationException("{Id} numaralı kullanıcı bulunamadı.");
        }
        return data;
    }
    public async Task<User> CreateUserAsync(User newUser)
    {
        var data = await _httpClient.PostAsJsonAsync("api/User", newUser);
        if (data == null)
        {
            throw new InvalidOperationException("Kullanıcı Ekleme İşlemi Başarısız.");
        }
        return newUser;
    }
    public async Task<User> UpdateUserAsync(int Id, User updatedUser)
    {
        var data = await _httpClient.PutAsJsonAsync($"api/User/{Id}", updatedUser);
        if (data == null)
        {
            throw new InvalidOperationException("Kullanıcı Düzeltme İşlemi Başarısız.");
        }
        return updatedUser;
    }
    public async Task DeleteUserAsync(int Id)
    {
        var data =await _httpClient.DeleteAsync($"api/User/{Id}");
        data.EnsureSuccessStatusCode();
    }
}
