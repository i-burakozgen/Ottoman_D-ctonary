namespace Backend_dict.Dto;

public class PersianTransliterationDto
{
    public class PersianTransliterationsDto
    {
        public string WordName { get; set; }
        public string PersianTransliterationName { get; set; }
        public List<string> Meanings { get; set; }
        public List<string> Variations { get; set; }
    
    }
}