using System.ComponentModel.DataAnnotations;

namespace Backend_dict.Models;

public class Word
{
    [Key]
    public int Id { get; set; }
    public string WordName { get; set; }
    public ICollection<Variation> Variations { get; set; }
    public ICollection<Meaning> Meanings { get; set; }
    public ICollection<PersianTransliteration> PersianTransliterations { get; set; }
}



