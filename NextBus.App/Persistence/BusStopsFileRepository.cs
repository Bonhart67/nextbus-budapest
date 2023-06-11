namespace NextBus.App.Persistence;

internal class BusStopsFileRepository : IBusStopsRepository
{
    private IEnumerable<Stop> _stops;
    private IEnumerable<StopTime> _stopTimes;
    private IEnumerable<Trip> _trips;
    private IEnumerable<CalendarDate> _dates;

    public IEnumerable<Stop> Stops => _stops ??= ReadStops();

    private IEnumerable<Stop> ReadStops()
    {
        return File.ReadAllLines("stops.txt").Select(l =>
        {
            var split = l.Split(',');
            var lat = double.Parse(split[2]);
            var lon = double.Parse(split[3]);
            return new Stop(lat, lon, split[0]);
        });
    }
}

internal record struct Stop(double Latitude, double Longitude, string StopId);
internal record struct StopTime(DateTime DepartureTime, string Headsign, string TripId, string StopId);
internal record struct Trip(string ServiceId, string TripId);
internal record struct CalendarDate(DateTime Date, string ServiceId);

internal interface IBusStopsRepository
{
    IEnumerable<Stop> Stops { get; }
}
