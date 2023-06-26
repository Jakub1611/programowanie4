using System.Collections.Generic;

namespace LasotaProjekt.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko {get; set;}
        public string NrIndeksu { get; set; }
        public int Rocznik { get; set; }

        public virtual ICollection<Grupa> GrupyStudenta { get; set; }
    }
}
