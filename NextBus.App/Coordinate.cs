namespace NextBus.App;

public record Coordinate(double Latitude, double Longitude)
{
  public double DistanceFrom(Coordinate other)
  {
    const double r = 6371d;

    var dLat = ToRadian(other.Latitude - Latitude);
    var dLon = ToRadian(other.Longitude - Longitude);
   
    var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(ToRadian(Latitude)) * Math.Cos(ToRadian(other.Latitude)) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

    return r * (double)(2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))) * 1000;

    double ToRadian(double angle)
    {
      return Math.PI * angle / 180d;
    }
  }
}
