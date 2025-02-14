using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

public class UserEventService : IUserEventDataService
{
    private readonly HttpClient _httpClient;
    public UserEventService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("http://localhost:5500/");
    }

    public async Task<List<UserEvent>> GetAllUserEventAsync()
    {
        var data = await _httpClient.GetFromJsonAsync<List<UserEvent>>("api/UserEvent");
        if (data == null)
        {
            throw new InvalidOperationException("Data cannot be null.");
        }
        return data;
    }

    public async Task<UserEvent> GetUserEventByIdAsync(int id)
    {
        var data = await _httpClient.GetFromJsonAsync<UserEvent>($"api/UserEvent/{id}");
        if (data == null)
        {
            throw new InvalidOperationException($"{id} numaralı katılım bulunamadı.");
        }
        return data;
    }

    public async Task<UserEvent> GetUserEventByFilter(int? userId, int? eventId)
    {
        var query = EventUserData.UserEvents.AsQueryable();
    
        if (userId.HasValue)
        {
            query = query.Where(e => e.UserID == userId.Value);
        }
    
        if (eventId.HasValue)
        {
            query = query.Where(e => e.EventId == eventId.Value);
        }
    
        var result = await Task.FromResult(query.FirstOrDefault());
    
        if (result == null)
        {
            throw new InvalidOperationException("No matching user event found.");
        }
    
        return result;
    }


    public async Task<UserEvent> CreateUserEventAsync(UserEvent newUserEvent)
    {
        var response = await _httpClient.PostAsJsonAsync("api/UserEvent", newUserEvent);
        response.EnsureSuccessStatusCode();

        var createdUserEvent = await response.Content.ReadFromJsonAsync<UserEvent>();
        if (createdUserEvent == null)
        {
            throw new InvalidOperationException("Katılım Ekleme İşlemi Başarısız.");
        }
        return createdUserEvent;
    }

    public async Task<UserEvent> UpdateUserEventAsync(int id, UserEvent updatedUserEvent)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/UserEvent/{id}", updatedUserEvent);
        response.EnsureSuccessStatusCode();

        var updatedEvent = await response.Content.ReadFromJsonAsync<UserEvent>();
        if (updatedEvent == null)
        {
            throw new InvalidOperationException("Katılım Düzeltme İşlemi Başarısız.");
        }
        return updatedEvent;
    }

    public async Task DeleteUserEventAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/UserEvent/{id}");
        response.EnsureSuccessStatusCode();
    }
}
