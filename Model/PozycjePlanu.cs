using System;

namespace LasotaProjekt.Model
{
    public class PozycjePlanu
    {
        public int Id { get; set; }
        public Przedmiot Przedmiot { get; set; }
        public Grupa Grupa { get; set; }

        public DateTime Dzien { get; set; }
        public string GodzinaOd { get; set; }
        public string GodzinaDo { get; set; }
        public string Sala { get; set; }
    }
}
