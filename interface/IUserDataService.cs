public interface IUserDataService
{
    Task<List<User>> GetAllUserAsync();
    Task<User> GetUserByIdAsync(int Id);
    Task<User> CreateUserAsync(User newUser);
    Task<User> UpdateUserAsync(int Id,User updatedUser);
    Task DeleteUserAsync(int Id);
}
