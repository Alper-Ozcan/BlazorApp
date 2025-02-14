public interface IMenuDataService
{
    Task<List<Menu>> GetAllMenuAsync();
    Task<Menu> GetMenuByIdAsync(int Id);
    Task CreateMenuAsync(Menu newMenu);
    Task UpdateMenuAsync(int Id, Menu updatedMenu);
    Task DeleteMenuAsync(int Id);
}
