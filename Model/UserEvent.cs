using System.ComponentModel.DataAnnotations;

public class UserEvent
{
    public int UEId { get; set; }
    public int UserID { get; set; }
    public string UserName { get; set; }
    public int EventId { get; set; }
    public string EventName { get; set; }
    public DateTime EventDate { get; set; }
    public string EventLocation { get; set; }
}
