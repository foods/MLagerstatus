namespace MLagerstatus.Models.LagerStatus
{
    public class Reservation
    {
        public string kund { get; set; }
        public string artikel { get; set; }
        public string hylla { get; set; }
        public uint beställtAntal { get; set; }
        public uint plockatAntal { get; set; }
    }
}
