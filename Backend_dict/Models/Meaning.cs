using System.ComponentModel.DataAnnotations;

namespace Backend_dict.Models;

public class Meaning
{
    [Key]
    public int Id { get; set; }
    public int WordId { get; set; }
    public string MeaningName { get; set; }
    public Word Word { get; set; } = null!;
    
}