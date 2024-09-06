using Backend_dict.Dto;
using Backend_dict.Interfaces;
using Backend_dict.Mapppers;
using Backend_dict.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_dict.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordController : Controller
{
    private readonly IWordRepository _wordRepository;

    public WordController(IWordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Word>))]
    public IActionResult GetAllWords(int limit = 3)
    {
        const int maxLimit = 5;
        if (limit > maxLimit || limit < 1)
        {
            return BadRequest("limit must be greater than or equal to 1 and less than or equal to 5");
        }

        var words = _wordRepository.getAllWords(limit);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(words);
    }

    [HttpGet("{wordId}")]
    [ProducesResponseType(statusCode: 200, Type = typeof(Word))]
    [ProducesResponseType(400)]
    public IActionResult GetWordById(int wordId)
    {
        var word = _wordRepository.getWordById(wordId);

        if (word == null)
        {
            return NotFound();
        }

        var wordDto = word.toWordDto();

        return Ok(wordDto);
    }
    
    [HttpGet("byname/{wordName}/")]
    [ProducesResponseType(statusCode: 200, Type = typeof(Word))]
    [ProducesResponseType(400)]
    public IActionResult getWordByName(string wordName)
    {
        var word = _wordRepository.getWordByName(wordName);
        if (word == null)
        {
            return NotFound();
        }
        return Ok(word);
    }
}



