using System.Xml.Linq;
using StudentProject.Web.Domain;

var outputPath = args.FirstOrDefault() ?? "TestResults/test-results.xml";
var tests = new (string Name, Action Execute)[]
{
    ("Стоимость нескольких товаров", () =>
        AssertEqual(2500m, OrderCalculator.CalculateTotal(1250m, 2))),
    ("Пустая корзина", () =>
        AssertEqual(0m, OrderCalculator.CalculateTotal(1250m, 0))),
    ("Отрицательная цена отклоняется", () =>
        AssertThrows<ArgumentOutOfRangeException>(() =>
            OrderCalculator.CalculateTotal(-1m, 1)))
};

var results = new List<(string Name, bool Passed, string? Error)>();

foreach (var test in tests)
{
    try
    {
        test.Execute();
        results.Add((test.Name, true, null));
        Console.WriteLine($"PASS: {test.Name}");
    }
    catch (Exception exception)
    {
        results.Add((test.Name, false, exception.Message));
        Console.WriteLine($"FAIL: {test.Name} - {exception.Message}");
    }
}

var directory = Path.GetDirectoryName(outputPath);
if (!string.IsNullOrWhiteSpace(directory))
{
    Directory.CreateDirectory(directory);
}

var document = new XDocument(
    new XElement("test-run",
        new XAttribute("total", results.Count),
        new XAttribute("passed", results.Count(result => result.Passed)),
        new XAttribute("failed", results.Count(result => !result.Passed)),
        results.Select(result =>
            new XElement("test-case",
                new XAttribute("name", result.Name),
                new XAttribute("result", result.Passed ? "Passed" : "Failed"),
                result.Error is null ? null : new XElement("failure", result.Error)))));

document.Save(outputPath);

Console.WriteLine(
    $"Результат: {results.Count(result => result.Passed)}/{results.Count} тестов пройдено.");

return results.All(result => result.Passed) ? 0 : 1;

static void AssertEqual<T>(T expected, T actual) where T : IEquatable<T>
{
    if (!expected.Equals(actual))
    {
        throw new InvalidOperationException($"Ожидалось {expected}, получено {actual}.");
    }
}

static void AssertThrows<TException>(Action action) where TException : Exception
{
    try
    {
        action();
    }
    catch (TException)
    {
        return;
    }

    throw new InvalidOperationException(
        $"Ожидалось исключение {typeof(TException).Name}.");
}
