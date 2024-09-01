using System.ComponentModel.DataAnnotations;

namespace Backend_dict.Models;

public class Variation
{
    [Key]
    public int Id { get; set; }
    public int WordId { get; set; }
    public string VariationName { get; set; }
    public Word Word { get; set; } = null!;
    
    
}