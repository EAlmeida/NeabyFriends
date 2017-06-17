namespace NearbyFriends.Entities
{
    public class Position
    {
        private readonly int _latitude;
        private readonly int _longitude;

        public Position(int latitude, int longitude)
        {            
            _latitude = latitude;
            _longitude = longitude;
        }
                
        public int Latitude
        {
            get { return _latitude; }
        }

        public int Longitude
        {
            get { return _longitude; }
        }

    }
}
