using System.ComponentModel.DataAnnotations;
public class Event
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
}
