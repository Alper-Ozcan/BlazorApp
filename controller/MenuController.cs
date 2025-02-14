using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Menu>>> GetAllMenu()
    {
        var data = await Task.Run(() => MenuData.Menus);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Menu>> GetMenuById(int Id)
    {
        var data = await Task.Run(() => MenuData.Menus.FirstOrDefault(u => u.Id == Id));
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMenu(Menu newMenu)
    {
        var data = await Task.Run(() => MenuData.Menus);
        newMenu.Id = data.Count + 1;
        //newMenu.IsAdminOnly = false;
        //newMenu.IsAuthorized = true;
        MenuData.Menus.Add(newMenu);
        return Ok(newMenu);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMenu(int Id, Menu updatedMenu)
    {
        if (Id != updatedMenu.Id)
        {
            return BadRequest();
        }
        var existingMenu = await Task.Run(() => MenuData.Menus.FirstOrDefault(u => u.Id == Id));
        if (existingMenu == null) return NotFound();

        existingMenu = updatedMenu;
        //MenuData.Menus.Update(existingMenu);
        return Ok(existingMenu);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMenu(int Id)
    {
        var menu = await Task.Run(() => MenuData.Menus.FirstOrDefault(u => u.Id == Id));
        if (menu == null) return NotFound();

        MenuData.Menus.Remove(menu);
        return Ok();
    }
}
