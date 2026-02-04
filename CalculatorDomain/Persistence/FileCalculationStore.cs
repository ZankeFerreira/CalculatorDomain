using System.Text.Json;
using CalculatorDomain.Domain;
using CalculatorDomain.Persistence;

namespace CalculatorDomain.Persistence
{
    public class FileCalculationStore : ICalculationStore
    {
        private readonly string _filePath;
        private readonly string _directoryPath;

        public FileCalculationStore(string directoryPath)
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, "calculations.json");
    }

    public async Task SaveAsync(Calculation calculation)
    {
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);

        var calculations = (await LoadAllAsync()).ToList();
        calculations.Add(calculation);

        var json = JsonSerializer.Serialize(calculations);
        await File.WriteAllTextAsync(_filePath, json);
    }
        public async Task<IReadOnlyList<Calculation>> LoadAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Calculation>();

            string json = await File.ReadAllTextAsync(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Calculation>();

            List<Calculation> calculations = JsonSerializer.Deserialize<List<Calculation>>(json)
            ?? new List<Calculation>();

            return calculations;
        }
    }
}