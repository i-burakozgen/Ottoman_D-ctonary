using Backend_dict.Models;

namespace Backend_dict.Interfaces;

public interface IWordRepository
{
    ICollection<Word> getAllWords(int limit);
    Word getWordById(int wordId);
    Word getWordByName(string wordName);

}
