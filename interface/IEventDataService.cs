public interface IEventDataService
{
    Task<List<Event>> GetAllEventAsync();
    Task<Event> GetEventByIdAsync(int Id);
    Task<Event> CreateEventAsync(Event newEvent);
    Task<Event> UpdateEventAsync(int Id,Event updatedEvent);
    Task DeleteEventAsync(int Id);
}
