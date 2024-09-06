using System.ComponentModel.DataAnnotations;

namespace Backend_dict.Models;

public class Word
{
    [Key]
    public int Id { get; set; }
    public string WordName { get; set; }
    public IList<Variation> Variations { get; set; }
    public IList<Meaning> Meanings { get; set; }
    public IList<PersianTransliteration> PersianTransliterations { get; set; }
}



