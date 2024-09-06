namespace Backend_dict.Dto;

public class MeaningDto
{
    
    public class MeaningsDto
    {
        public string MeaningName { get; set; }
        public string WordName { get; set; }
        public string PersianTransliterationName { get; set; }
        public List<string> PersianTransliterations { get; set; }
        public List<string> VariatiVariationsons { get; set; }
    }
}