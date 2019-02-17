using System.Collections.Generic;

namespace MLagerstatus.Models.Views
{
    public class ProduktIndexView
    {
        public ProduktIndexView()
        {
            Produkter = new List<ProduktView>();
        }
        public List<ProduktView> Produkter { get; set; }
    }

    public class ProduktView
    {
        public string ProduktNamn { get; set; }
        public uint LagerStatus { get; set; }
    }
}
