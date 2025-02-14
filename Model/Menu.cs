using System.ComponentModel.DataAnnotations;
public class Menu
{
    public int Id { get; set; } 
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Url is required.")]
    public string Url { get; set; }
    public bool IsAuthorized { get; set; }
    public bool IsAdminOnly { get; set; }
}