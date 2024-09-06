namespace Backend_dict.Dto;

public class VariationDto
{
    public class VariationsDto
    {
        public string VariationName { get; set; }
        public string WordName { get; set; }
        public List<string> PersianTransliterations { get; set; }
        public List<string> Meanings { get; set; }
    
    }
}