using Projekt.Helpers;
using Projekt1.Model.EnitiesForView;
using Projekt1.Model.Entities;
using Projekt1.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Linq;

namespace Projekt.ViewModel
{
    public class KadryViewModel : WszystkieViewModel<PracownikForAllView>
    {
       /* #region Fields
        private readonly SputnikkEntities sputnikEntities; //SputnikkEntities odpowiada klasa za komunikację z DB
        private BaseCommand _LoadCommand; // to jest komenda która podepniemy pod przycisk i ta komenda wywoła funkcję. 
        private ObservableCollection<Pracownik> _List; //tu będą przechowywani wszyscy pracownicy z baz danych
        #endregion
        #region Properties
        //podpinany pod Load Command funkcję Load
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        public ObservableCollection<Pracownik> List
        {
            get
            {
                if (_List == null)
                {
                    load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        
        #endregion*/

        #region Constructor
       /* public KadryViewModel()
        {
            base.DisplayName = "Kadry";
            //tworze obiekt bazy danych
            this.sputnikEntities = new SputnikkEntities();
        }*/
        public KadryViewModel()
            :base("Kadry")
        {
        }

        #endregion
        #region LoadFunctions
        public override void load()
        {
            //do listy przekazuje z bazy danych wszystkie osoby używając dostępu przez entieties
            List = new ObservableCollection<PracownikForAllView>
            (
                from pracownik in sputnikEntities.Pracownik
                select new PracownikForAllView
                {
                    IdPracownika = pracownik.IdPracownika,
                    Nazwisko = pracownik.Nazwisko,
                    Imie = pracownik.Imie,
                    Wydzial = pracownik.Departament.NazwaDzial,
                    Stanowisko = pracownik.Stanowisko.NazwaStanowisko
                }
            );
        }
        #endregion

    }
}
