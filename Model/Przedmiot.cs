namespace LasotaProjekt.Model
{
    public class Przedmiot
    {
        public int Id { get; set; }
        public string NazwaPrzedmiotu { get; set; }
        public string KodPrzedmiotu { get; set; }
        public int Godziny { get; set; }
        public string Kierunek { get; set; }
        public int Semestr { get; set; }
        public string TrybStud { get; set; }
        public string Stopien { get; set; }
        public int RokAkademicki { get; set; }

        public override string ToString()
        {
            return $"{NazwaPrzedmiotu}, {KodPrzedmiotu}";
        }
    }
}
