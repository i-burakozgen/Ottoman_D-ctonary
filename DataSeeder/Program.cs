using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Backend_dict.Data;
using Backend_dict.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        // Create and configure the configuration object
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path for file resolution
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load configuration from appsettings.json
            .Build();

        // Configure DbContext options
        var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection")) // Use connection string from configuration
            .Options;

        // Using the DataContext to interact with the database
        using (var context = new DataContext(dbContextOptions))
        {
            // Ensure the database is created
            await context.Database.EnsureCreatedAsync();

            // Read and parse the JSON file asynchronously
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "processed_dict.json");
            var data = await LoadJsonDataAsync(jsonFilePath);

            // Populate the database with data from the JSON file
            foreach (var entry in data)
            {
                var wordText = entry.Key;
                var wordDetails = entry.Value;

                // Create a new Word entity
                var word = new Word
                {
                    WordName = wordText,
                    Meanings = wordDetails.GetProperty("meanings").EnumerateArray().Select(m => new Meaning
                    {
                        MeaningName = m.GetString()
                    }).ToList(),
                    Variations = wordDetails.GetProperty("variations").EnumerateArray().Select(v => new Variation
                    {
                        VariationName = v.GetString()
                    }).ToList(),
                    PersianTransliterations = wordDetails.GetProperty("persian_written_forms").EnumerateArray().Select(p => new PersianTransliteration
                    {
                        PersiantransliterationName = p.GetString()
                    }).ToList()
                };

                // Add the Word entity to the context and save changes asynchronously
                await context.Words.AddAsync(word);
            }

            await context.SaveChangesAsync();
        }

        Console.WriteLine("Database has been populated successfully!");
    }

    private static async Task<Dictionary<string, JsonElement>> LoadJsonDataAsync(string filePath)
    {
        var jsonData = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonData);
    }
}
