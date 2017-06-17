namespace NearbyFriends.Entities
{
    public class Friend
    {
        private readonly Position _position;
        private string _name;

        public Friend(Position position)
        {
            _position = position;
        }

        public Friend(string name, Position position)
        {            
            _name = name;
            _position = position;
        }

        public Position Position
        {
            get { return _position; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id { get; set; }
    }
}
