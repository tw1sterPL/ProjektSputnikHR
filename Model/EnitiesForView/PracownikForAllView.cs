using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1.Model.EnitiesForView
{
    //to jest klasa zamiast kluczów obcych wyswietla wybrane elementy
    public class PracownikForAllView
    {
        public int IdPracownika { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Wydzial { get; set; }
        public string Stanowisko { get; set; }
    }
}
