using Projekt.Helpers;
using Projekt.ViewModel;
using Projekt1.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt1.ViewModel.Abstract
{
    //dziedziczą wszystkie modele z scenariuszem wszystkie
    // klasa działa na typie generycznym T pod którym w przypadku wyświetlania towaru podstawiane sa towary, zamowien - zamowienia
    public abstract class WszystkieViewModel<T> : WorkSpaceViewModel
    {
        #region Fields
        protected readonly SputnikkEntities sputnikEntities; //SputnikkEntities odpowiada klasa za komunikację z DB
        private BaseCommand _LoadCommand; // to jest komenda która podepniemy pod przycisk i ta komenda wywoła funkcję. 
        private ObservableCollection<T> _List; //tu będą przechowywani wszyscy pracownicy z baz danych
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
        public ObservableCollection<T> List
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
        #endregion
        #region Constructor
        public WszystkieViewModel(String displayName)
        {
            base.DisplayName = displayName;
            //tworze obiekt bazy danych
            this.sputnikEntities = new SputnikkEntities();
        }
        #endregion
        #region LoadFunctions
        public abstract void load();
        #endregion
    }
}
