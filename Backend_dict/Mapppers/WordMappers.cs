using Backend_dict.Dto;
using Backend_dict.Models;

namespace Backend_dict.Mapppers;

public static class WordMappers
{
    public static WordDto toWordDto(this Word wordModel)
    {
        return new WordDto
        {
            WordName = wordModel.WordName,
            Variations = wordModel.Variations?.Select(v => v.VariationName).ToList() ?? new List<string>(), // Assuming `VariationName` is a property in `Variation`
            Meanings = wordModel.Meanings?.Select(m => m.MeaningName).ToList() ?? new List<string>(), // Assuming `MeaningText` is a property in `Meaning`
            PersianTransliterations = wordModel.PersianTransliterations?.Select(p => p.PersiantransliterationName).ToList() ?? new List<string>(),
        };
    }
    
}