using NextBus.App.Persistence;

namespace NextBus.App;

public class BusStopsQuery : IBusStopsQuery
{
    public IEnumerable<BusStop> GetStopsInRadius(double lat, double lon, double radius)
    {
        var repo = new BusStopsFileRepository();
        var first = repo.Stops.First();
        return new BusStop[] { new BusStop(first.Latitude.ToString(), first.Longitude.ToString(), "Not Yet", Enumerable.Empty<string>()) };
    }
}

public record struct BusStop(string ShortName, string LongName, string Next, IEnumerable<string> NextOccurances);

public interface IBusStopsQuery
{
    IEnumerable<BusStop> GetStopsInRadius(double lat, double lon, double radius);
}
