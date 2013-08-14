namespace HotDogReview.Core.Geocoding
{
    public interface IGeocodingService
    {
        GeoCoordinate GetCoordinate(string address);
    }
}
