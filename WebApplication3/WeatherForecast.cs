namespace WebApplication3;

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