public class EventService : IEventDataService
{
    private readonly HttpClient _httpClient;
    public EventService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("http://localhost:5500/");
    }

    public async Task<List<Event>> GetAllEventAsync()
    {
        var data = await _httpClient.GetFromJsonAsync<List<Event>>("api/Event");
        if (data == null)
        {
            throw new InvalidOperationException("Data cannot be null.");
        }
        return data;
    }
    public async Task<Event> GetEventByIdAsync(int Id)
    {
        var data = await _httpClient.GetFromJsonAsync<Event>($"api/Event/{Id}");
        if (data == null)
        {
            throw new InvalidOperationException("{Id} numaralı kullanıcı bulunamadı.");
        }
        return data;
    }
    public async Task<Event> CreateEventAsync(Event newEvent)
    {
        var data = await _httpClient.PostAsJsonAsync("api/Event", newEvent);
        if (data == null)
        {
            throw new InvalidOperationException("Kullanıcı Ekleme İşlemi Başarısız.");
        }
        return newEvent;
    }
    public async Task<Event> UpdateEventAsync(int Id, Event updatedEvent)
    {
        var data = await _httpClient.PutAsJsonAsync($"api/Event/{Id}", updatedEvent);
        if (data == null)
        {
            throw new InvalidOperationException("Kullanıcı Düzeltme İşlemi Başarısız.");
        }
        return updatedEvent;
    }
    public async Task DeleteEventAsync(int Id)
    {
        var data =await _httpClient.DeleteAsync($"api/Event/{Id}");
        data.EnsureSuccessStatusCode();
    }
}
