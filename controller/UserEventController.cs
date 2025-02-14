using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserEventController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserEvent>>> GetAllUserEvent()
    {
        var data = await Task.Run(() => EventUserData.UserEvents);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEvent>> GetUserEventById(int id)
    {
        var data = await Task.Run(() => EventUserData.UserEvents.FirstOrDefault(u => u.UEId == id));
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpGet("filter")]
    public ActionResult<List<UserEvent>> FilterUserEvents( [FromQuery] int? userId, [FromQuery] int? eventId)
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

        var filteredEvents = query.ToList();

        return Ok(filteredEvents);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUserEvent(UserEvent newUserEvent)
    {
        Console.WriteLine("Event User Data: " + newUserEvent.UserName);
        Console.WriteLine("Event Event Data " + newUserEvent.EventName);

        var data = await Task.Run(() => EventUserData.UserEvents);
        int maxId = data.Max(e => e.UEId)+1;
        var query=data.Where(e => e.UserID == newUserEvent.UserID && e.EventId == newUserEvent.EventId);
        if ( string.IsNullOrEmpty(newUserEvent.UserName) || string.IsNullOrEmpty(newUserEvent.EventName) || query.Count() > 0)
        {
            return BadRequest();
        }
        newUserEvent.UEId = maxId;
        EventUserData.UserEvents.Add(newUserEvent);
        return Ok(newUserEvent);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUserEvent(int id, UserEvent updatedUserEvent)
    {
        if (id != updatedUserEvent.UEId)
        {
            return BadRequest();
        }
        var existingUserEvent = await Task.Run(() => EventUserData.UserEvents.FirstOrDefault(u => u.UEId == id));
        if (existingUserEvent == null) return NotFound();

        existingUserEvent.UserID = updatedUserEvent.UserID;
        existingUserEvent.UserName = updatedUserEvent.UserName;
        existingUserEvent.EventId = updatedUserEvent.EventId;
        existingUserEvent.EventName = updatedUserEvent.EventName;
        existingUserEvent.EventDate = updatedUserEvent.EventDate;
        existingUserEvent.EventLocation = updatedUserEvent.EventLocation;
              

        return Ok(existingUserEvent);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserEvent(int id)
    {
        var userEvent = await Task.Run(() => EventUserData.UserEvents.FirstOrDefault(u => u.UEId == id));
        if (userEvent == null) return NotFound();

        EventUserData.UserEvents.Remove(userEvent);
        return Ok();
    }

}
