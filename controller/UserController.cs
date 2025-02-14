using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUser()
    {
        var data = await Task.Run(() => UserData.Users);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int Id)
    {
        var data = await Task.Run(() => UserData.Users.FirstOrDefault(u => u.Id == Id));
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(User newUser)
    {
        var data = await Task.Run(() => UserData.Users);
        if (newUser.Name ==null || newUser.Email == null || newUser.Name== null) 
        {
            return BadRequest();
        }
        newUser.Id = data.Count + 1;
        UserData.Users.Add(newUser);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int Id, User updatedUser)
    {
        if (Id != updatedUser.Id)
        {
            return BadRequest();
        }
        User existingUser = await Task.Run(() => UserData.Users.FirstOrDefault(u => u.Id == Id));
        if (existingUser == null) return NotFound();

        existingUser.Email = updatedUser.Email;
        existingUser.Name = updatedUser.Name;
        existingUser.Password = updatedUser.Password;
        existingUser.IsAdmin = updatedUser.IsAdmin;
        //UserData.Users.Update(existingUser);

        return Ok(existingUser);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int Id)
    {
        User user = await Task.Run(() => UserData.Users.FirstOrDefault(u => u.Id == Id));
        if (user == null) return NotFound();

        UserData.Users.Remove(user);
        return Ok();
    }
}

