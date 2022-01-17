using Projekt.Helpers;
using Projekt.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Projekt.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;    
        private ObservableCollection<WorkSpaceViewModel> _Workspaces;
        #endregion

        #region ToolBarComands

        private BaseCommand getCommand(BaseCommand _command, WorkSpaceViewModel _workspase)
        {
            if (_command == null)
                _command = new BaseCommand(() => Create(_workspase));
            return _command;
        }

        private BaseCommand _CreateKadryCommand;
        public ICommand CreateKadryCommand
        {
            get
            {
                return getCommand(_CreateKadryCommand, new KadryViewModel());
            }
        }
        private BaseCommand _CreatePlaceCommand;
        public ICommand CreatePlaceCommand
        {
            get
            {
                return getCommand(_CreatePlaceCommand, new PlaceViewModel());
            }
        }
        private BaseCommand _CreateWlascicielCommand;
        public ICommand CreateWlascicielCommand
        {
            get
            {
                return getCommand(_CreateWlascicielCommand, new WlascicielViewModel());
            }
        }
        private BaseCommand _CreateZusCommand;
        public ICommand CreateZusCommand
        {
            get
            {
                return getCommand(_CreateZusCommand, new PrzelewZUSViewModel());
            }
        }
        private BaseCommand _CreateNewKadryCommand;
        public ICommand CreateNewKadryCommand
        {
            get
            {
                return getCommand(_CreateNewKadryCommand, new KadryNewAddView());
            }
        }
        #endregion
        #region NewWindow

        #endregion
        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel("Kadry",new BaseCommand(()=>this.Create(new KadryViewModel()))), //
                //new CommandViewModel("Wszystkie towary",new BaseCommand(()=>this.ShowAllTowar())), //          
            };
        }
        #endregion
        #region Workspaces
        public ObservableCollection<WorkSpaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkSpaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkSpaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkSpaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkSpaceViewModel workspace = sender as WorkSpaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region PrivateHelpers
        private void Create(WorkSpaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        
        private void SetActiveWorkspace(WorkSpaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion
        #region CommentsCode
        //private BaseCommand _ShowDostawyCommand;
        /*public ICommand ShowDostawyCommand
        {
            get
            {
                if (_ShowDostawyCommand == null)
                    _ShowDostawyCommand = new BaseCommand(() => ShowAllDostawy());
                return _ShowDostawyCommand;
            }
        }*/
        /* private void ShowAllDostawy()
        {
            ZestawieniaDostawViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is ZestawieniaDostawViewModel) as ZestawieniaDostawViewModel;
            if (workspace == null)
            {
                workspace = new ZestawieniaDostawViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }*/
        /*private void ShowAllFaktura()
        {
            WszystkieFakturyViewModel workspace =
                 this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }*/
        /* private void ShowAllTowar()
         {

             WszystkieTowaryViewModel workspace =
                 this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;

             if (workspace == null)
             {

                 workspace = new WszystkieTowaryViewModel();
                 this.Workspaces.Add(workspace);
             }
             this.SetActiveWorkspace(workspace);
         }*/
        #endregion
    }
}
