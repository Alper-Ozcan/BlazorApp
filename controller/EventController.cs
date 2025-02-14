using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetAllEvent()
    {
        var data = await Task.Run(() => EventData.Events);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Menu>> GetEventById(int Id)
    {
        var data = await Task.Run(() => EventData.Events.FirstOrDefault(u => u.Id == Id));
        if (data == null)
        {
            return NotFound();
        }
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateEvent(Event newEvent)
    {
        var data = await Task.Run(() => EventData.Events);
        newEvent.Id = data.Count + 1;
        //newMenu.IsAdminOnly = false;
        //newMenu.IsAuthorized = true;
        EventData.Events.Add(newEvent);
        return Ok(newEvent);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEvent(int Id, Event updatedEvent)
    {
        if (Id != updatedEvent.Id)
        {
            return BadRequest();
        }
        var existingEvent = await Task.Run(() => EventData.Events.FirstOrDefault(u => u.Id == Id));
        if (existingEvent == null) return NotFound();

        existingEvent.Date = updatedEvent.Date;
        existingEvent.Name = updatedEvent.Name;
        existingEvent.Location = updatedEvent.Location;

        //EventData.Events.Update(existingEvent);

        return Ok(existingEvent);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int Id)
    {
        var Event = await Task.Run(() => EventData.Events.FirstOrDefault(u => u.Id == Id));
        if (Event == null) return NotFound();

        EventData.Events.Remove(Event);
        return Ok();
    }
}

