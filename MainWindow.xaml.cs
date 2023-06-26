using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using LasotaProjekt.Model;

namespace LasotaProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private PlanContext context;

        public ObservableCollection<Student> Studenci
        {
            get
            {
                return new ObservableCollection<Student>(context.Studenci);
            }
        }

        public ObservableCollection<Przedmiot> Przedmioty
        {
            get
            {
                return new ObservableCollection<Przedmiot>(context.Przedmioty);
            }
        }

        public ObservableCollection<Grupa> Grupy
        {
            get
            {
                return new ObservableCollection<Grupa>(context.Grupy);
            }
        }

        public ObservableCollection<PozycjePlanu> PozycjePlanu
        {
            get
            {
                return new ObservableCollection<PozycjePlanu>(context.PozycjePlanu);
            }
        }

        public Student NowyStudent { get; set; }
        public Przedmiot NowyPrzedmiot { get; set; }
        public Grupa NowaGrupa { get; set; }
        public PozycjePlanu NowaPozycjaPlanu { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            context = new PlanContext();
           //dodawanie danych testowych
           /* Student s1 = new() { Imie = "Bonifacy Janusz", Nazwisko = "Korwin", NrIndeksu = "2137", Rocznik = 5 };
            Przedmiot p1 = new()
            {
                NazwaPrzedmiotu = "Bajo Jajo",
                KodPrzedmiotu = "ABC",
                Godziny = 30,
                Kierunek = "Informatyka",
                Semestr = 4,
                TrybStud = "Dzienne",
                Stopien = "I",
                RokAkademicki = 2
            };
            Grupa g1 = new()
            {
                KodGrupy = "XYZ",
                TypGrupy = "Labolatoryjna",
                Kierunek = "Informatyka",
                Semestr = 4,
                TrybStud = "Dzienne",
                Stopien = "I"
            };
            PozycjePlanu pp1 = new()
            {
                Przedmiot = p1,
                Grupa = g1,
                Dzien = new DateTime(2023, 6, 12),
                GodzinaOd = "10:00",
                GodzinaDo = "11:30",
                Sala = "A123"
            };

            context.Studenci.Add(s1);
            context.Przedmioty.Add(p1);
            context.Grupy.Add(g1);
            context.PozycjePlanu.Add(pp1);

            context.SaveChanges(); */

            NowyStudent = new();
            NowyPrzedmiot = new();
            NowaGrupa = new();
            NowaPozycjaPlanu = new(){Dzien = DateTime.Today};

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NowyStudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Studenci.Add(new()
                {
                    Imie = NowyStudent.Imie,
                    Nazwisko = NowyStudent.Nazwisko,
                    NrIndeksu = NowyStudent.NrIndeksu,
                    Rocznik = NowyStudent.Rocznik
                });
                context.SaveChanges();

                OnPropertyChanged(nameof(Studenci));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void NowyPrzedmiotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Przedmioty.Add(new()
                {
                    NazwaPrzedmiotu = NowyPrzedmiot.NazwaPrzedmiotu,
                    KodPrzedmiotu = NowyPrzedmiot.KodPrzedmiotu,
                    Godziny = NowyPrzedmiot.Godziny,
                    Kierunek = NowyPrzedmiot.Kierunek,
                    Semestr = NowyPrzedmiot.Semestr,
                    TrybStud = NowyPrzedmiot.TrybStud,
                    Stopien = NowyPrzedmiot.Stopien,
                    RokAkademicki = NowyPrzedmiot.RokAkademicki
                });
                context.SaveChanges();

                OnPropertyChanged(nameof(Przedmioty));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void NowaGrupaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Grupy.Add(new()
                {
                    KodGrupy = NowaGrupa.KodGrupy,
                    TypGrupy = NowaGrupa.TypGrupy,
                    Kierunek = NowaGrupa.Kierunek,
                    Semestr = NowaGrupa.Semestr,
                    TrybStud = NowaGrupa.TrybStud,
                    Stopien = NowaGrupa.Stopien,

                });
                context.SaveChanges();

                OnPropertyChanged(nameof(Grupy));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void NowaPozycjaPlanuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.PozycjePlanu.Add(new()
                {
                    Przedmiot = NowaPozycjaPlanu.Przedmiot,
                    Grupa = NowaPozycjaPlanu.Grupa,
                    Dzien = NowaPozycjaPlanu.Dzien,
                    GodzinaOd = NowaPozycjaPlanu.GodzinaOd,
                    GodzinaDo = NowaPozycjaPlanu.GodzinaDo,
                    Sala = NowaPozycjaPlanu.Sala
                });
                context.SaveChanges();

                OnPropertyChanged(nameof(PozycjePlanu));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void UsunStudentaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(StudentIdTextBox.Text);
                var student = context.Studenci.FirstOrDefault(s => s.Id == id);

                context.Studenci.Remove(student);
                context.SaveChanges();

                OnPropertyChanged(nameof(Studenci));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void UsunGrupeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(GrupaIdTextBox.Text);
                var grupa = context.Grupy.FirstOrDefault(s => s.Id == id);

                context.Grupy.Remove(grupa);
                context.SaveChanges();

                OnPropertyChanged(nameof(Grupy));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void UsunPrzedmiotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(PrzedmiotIdTextBox.Text);
                var przedmiot = context.Przedmioty.FirstOrDefault(s => s.Id == id);

                context.Przedmioty.Remove(przedmiot);
                context.SaveChanges();

                OnPropertyChanged(nameof(Przedmioty));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void UsunPozycjePlanuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(PozycjaPlanuIdTextBox.Text);
                var pozycjaPlanu = context.PozycjePlanu.FirstOrDefault(s => s.Id == id);

                context.PozycjePlanu.Remove(pozycjaPlanu);
                context.SaveChanges();

                OnPropertyChanged(nameof(PozycjePlanu));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void AktualizujStudentaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(StudentIdTextBox.Text);
                var student = context.Studenci.FirstOrDefault(s => s.Id == id);

                student.Imie = NowyStudent.Imie;
                student.Nazwisko = NowyStudent.Nazwisko;
                student.NrIndeksu = NowyStudent.NrIndeksu;
                student.Rocznik = NowyStudent.Rocznik;

                context.Studenci.Update(student);
                context.SaveChanges();

                OnPropertyChanged(nameof(Studenci));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void AktualizujGrupeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(GrupaIdTextBox.Text);
                var grupa = context.Grupy.FirstOrDefault(s => s.Id == id);

                grupa.KodGrupy = NowaGrupa.KodGrupy;
                grupa.TypGrupy = NowaGrupa.TypGrupy;
                grupa.Kierunek = NowaGrupa.Kierunek;
                grupa.Semestr = NowaGrupa.Semestr;
                grupa.TrybStud = NowaGrupa.TrybStud;
                grupa.Stopien = NowaGrupa.Stopien;

                context.Grupy.Update(grupa);
                context.SaveChanges();

                OnPropertyChanged(nameof(Grupy));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void AktualizujPrzedmiotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(PrzedmiotIdTextBox.Text);
                var przedmiot = context.Przedmioty.FirstOrDefault(s => s.Id == id);

                przedmiot.NazwaPrzedmiotu = NowyPrzedmiot.NazwaPrzedmiotu;
                przedmiot.KodPrzedmiotu = NowyPrzedmiot.KodPrzedmiotu;
                przedmiot.Godziny = NowyPrzedmiot.Godziny;
                przedmiot.Kierunek = NowyPrzedmiot.Kierunek;
                przedmiot.Semestr = NowyPrzedmiot.Semestr;
                przedmiot.TrybStud = NowyPrzedmiot.TrybStud;
                przedmiot.Stopien = NowyPrzedmiot.Stopien;
                przedmiot.RokAkademicki = NowyPrzedmiot.RokAkademicki;

                context.Przedmioty.Update(przedmiot);
                context.SaveChanges();

                OnPropertyChanged(nameof(Przedmioty));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }

        private void AktualizujPozycjePlanuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = int.Parse(PozycjaPlanuIdTextBox.Text);
                var pozycjaPlanu = context.PozycjePlanu.FirstOrDefault(s => s.Id == id);

                pozycjaPlanu.Przedmiot = NowaPozycjaPlanu.Przedmiot;
                pozycjaPlanu.Grupa = NowaPozycjaPlanu.Grupa;
                pozycjaPlanu.Dzien = NowaPozycjaPlanu.Dzien;
                pozycjaPlanu.GodzinaOd = NowaPozycjaPlanu.GodzinaOd;
                pozycjaPlanu.GodzinaDo = NowaPozycjaPlanu.GodzinaDo;
                pozycjaPlanu.Sala = NowaPozycjaPlanu.Sala;

                context.PozycjePlanu.Update(pozycjaPlanu);
                context.SaveChanges();

                OnPropertyChanged(nameof(PozycjePlanu));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wystąpił Błąd!\nSprawdź dane.");
            }
        }
    }
}
