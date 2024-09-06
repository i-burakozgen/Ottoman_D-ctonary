using Backend_dict.Models;

namespace Backend_dict.Interfaces;

public interface IPersianTransliterationRepository
{
    PersianTransliteration getPersiantransliterationName(string name);
    bool transliterationExists(string name);

}