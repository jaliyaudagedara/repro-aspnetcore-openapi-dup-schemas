WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/openapi/v1.json", "My API");
});

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
    return Enumerable.Empty<WeatherForecast>();
})
.Produces<IEnumerable<WeatherForecast>>()
.WithName("GetWeatherForecasts");

app.MapPost("/weatherforecast", (WeatherForecast weatherForecast) =>
{
    return weatherForecast;
})
.Produces<WeatherForecast>()
.WithName("CreateWeatherForecast");

app.Run();

public class WeatherForecast
{
    public LocationDto Location { get; set; }
}

public class LocationDto
{
    public AddressDto Address { get; set; }
}

public class AddressDto
{
    public LocationDto RelatedLocation { get; set; }
}
