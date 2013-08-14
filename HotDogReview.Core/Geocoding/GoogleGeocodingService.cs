using System;
using System.Globalization;
using System.Net;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;

namespace HotDogReview.Core.Geocoding
{
    public class GoogleGeocodingService : IGeocodingService
    {
        // Fields.
        private const string _baseUrl = "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true";

        // IGeocodingService members.
        public GeoCoordinate GetCoordinate(string address)
        {
            if (String.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException(address);

            address = HttpUtility.UrlEncode(address);
            
            var client = new WebClient();
            var result = client.DownloadString(String.Format(_baseUrl, address));
            var xml = XDocument.Parse(result);

            var responseStatus =
                xml.XPathSelectElement("//GeocodeResponse/status").Value;

            switch (responseStatus)
            {
                case "ZERO_RESULTS":
                    return GeoCoordinate.Empty;

                case "OVER_QUERY_LIMIT":
                case "REQUEST_DENIED":
                case "INVALID_REQUEST":
                case "UNKNOWN_ERROR":
                    throw new Exception(responseStatus);
            }

            var coordinate = new GeoCoordinate(
                Double.Parse(xml.XPathSelectElement("//geometry/location/lat").Value, CultureInfo.InvariantCulture),
                Double.Parse(xml.XPathSelectElement("//geometry/location/lng").Value, CultureInfo.InvariantCulture));

            return coordinate;
        }
    }
}
