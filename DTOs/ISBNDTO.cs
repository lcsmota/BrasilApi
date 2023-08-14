namespace BrasilAPI.DTOs;

public class ISBNDTO
{
    public string? Isbn { get; set; }
    public string? Title { get; set; }
    public string? Synopsis { get; set; }
    public int? Year { get; set; }
    public int? PageCount { get; set; }
    public string? Publisher { get; set; }
    public List<string>? Authors { get; set; }
    public List<string>? Subjects { get; set; }
}
