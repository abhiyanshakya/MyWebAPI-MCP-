namespace Api.Models;

public class Book
{
    public int Id { get; set; }
    public String Title { get; set; } = string.Empty;
    public String Author { get; set; } = string.Empty;
    public int YearPublished { get; set; }
}