using System.ComponentModel.DataAnnotations;

namespace Backend_dict.Models;

public class PersianTransliteration
{
    [Key]
    public int Id { get; set; }
    public int WordId { get; set; }
    public string PersiantransliterationName { get; set; }
    public Word Word { get; set; } = null!;
    
}