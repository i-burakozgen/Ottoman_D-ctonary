using Backend_dict.Data;
using Backend_dict.Interfaces;
using Backend_dict.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_dict.Repository;

public class PersianTransliterationRepository : IPersianTransliterationRepository
{
    private readonly DataContext _context;

    public PersianTransliterationRepository(DataContext context)
    {
        _context = context;
    }
    
    public PersianTransliteration getPersiantransliterationName(string persianTransliterationName)
    {
        return _context.PersianTransliterations
            .Include(p => p.Word)
            .Include(p => p.Word.Meanings)
            .Include(p => p.Word.Variations)
            .FirstOrDefault(p => p.PersiantransliterationName == persianTransliterationName);
    }
    
    public bool transliterationExists(string name)
    {
        throw new NotImplementedException();
    }
}