using System;

namespace HotDogReview.Core.Geocoding
{
    public struct GeoCoordinate : IEquatable<GeoCoordinate>
    {
        // Const fields.
        public static readonly GeoCoordinate Empty;

        // Fields.
        private readonly double _latitude;
        private readonly double _longitude;

        // Properties.
        public double Latitude { get { return _latitude; } }
        public double Longitude { get { return _longitude; } }

        // Constructors.
        public GeoCoordinate(double latitude, double longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }

        // Methods.
        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
        public string ToString(IFormatProvider provider)
        {
            return String.Format(provider, "{0},{1}", Latitude, Longitude);
        }

        // IEquatable members.
        public override bool Equals(Object other)
        {
            return other is GeoCoordinate && Equals((GeoCoordinate)other);
        }
        public bool Equals(GeoCoordinate other)
        {
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }
        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        // Operators.
        public static bool operator !=(GeoCoordinate a, GeoCoordinate b)
        {
            return !a.Equals(b);
        }
        public static bool operator ==(GeoCoordinate a, GeoCoordinate b)
        {
            return a.Equals(b);
        }
    }
}
