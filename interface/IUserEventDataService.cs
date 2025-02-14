public interface IUserEventDataService
{
    Task<List<UserEvent>> GetAllUserEventAsync();
    Task<UserEvent> GetUserEventByIdAsync(int Id);
    Task<UserEvent> GetUserEventByFilter(int? userId,int? eventId);
    Task<UserEvent> CreateUserEventAsync(UserEvent newUserEvent);
    Task<UserEvent> UpdateUserEventAsync(int Id,UserEvent updatedUserEvent);
    Task DeleteUserEventAsync(int Id);
}
