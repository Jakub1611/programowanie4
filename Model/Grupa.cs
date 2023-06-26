namespace LasotaProjekt.Model
{
    public class Grupa
    {
        public int Id { get; set; }
        public string KodGrupy { get; set; }
        public string TypGrupy { get; set; }
        public string Kierunek { get; set; }
        public int Semestr { get; set; }
        public string TrybStud { get; set; }
        public string Stopien { get; set; }

        public override string ToString()
        {
            return $"{KodGrupy}, {TypGrupy}";
        }
    }
}
