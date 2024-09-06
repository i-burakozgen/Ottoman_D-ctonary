using Backend_dict.Data;
using Backend_dict.Interfaces;
using Backend_dict.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_dict.Repository;

public class WordRepository: IWordRepository
{
    private readonly DataContext _context;
    public WordRepository(DataContext context)
    {
        _context = context;
        
    }

    public ICollection<Word> getAllWords(int limit)
    {
        return _context.Words
            .Include(w=>w.Variations)
            .Include(w=>w.PersianTransliterations)
            .Include(w=>w.Meanings)
            .OrderBy(w=>w.Id)
            .Take(limit)
            .ToList();

    }

    public Word getWordById(int wordId)
    {
        return _context.Words
            .Include(w=>w.Variations)
            .Include(w=>w.PersianTransliterations)
            .Include(w=>w.Meanings)
            .Where(w=>w.Id == wordId)
            .FirstOrDefault();
    }

    public Word getWordByName(string wordName)
    {
        return _context.Words
            .Include(w => w.Variations)
            .Include(w => w.PersianTransliterations)
            .Include(w => w.Meanings)
            .Where(w => w.WordName == wordName)
            .FirstOrDefault();
    }

    
}