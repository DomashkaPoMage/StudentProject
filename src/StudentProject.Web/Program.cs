using StudentProject.Web.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    title = "Каталог автозапчастей Student Project",
    status = "ready"
}));

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.MapGet("/cart/total", (decimal price, int quantity) =>
    Results.Ok(new { total = OrderCalculator.CalculateTotal(price, quantity) }));

app.Run();

public partial class Program
{
}
