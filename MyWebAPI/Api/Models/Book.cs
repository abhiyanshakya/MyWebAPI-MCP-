namespace Api.Models;

public class Book
{
    //The following are the properties of the Book class -
    public int Id { get; set; }
    public String Title { get; set; } = string.Empty;
    public String Author { get; set; } = string.Empty;
    public int YearPublished { get; set; }
}