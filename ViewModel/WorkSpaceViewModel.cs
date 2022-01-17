using Projekt.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Projekt.ViewModel
{
    public abstract class WorkSpaceViewModel : BaseViewModel
    {
        #region Constructor
        public WorkSpaceViewModel() { }
        #endregion

        #region CloseCommand
        // komenda do zamykania zakładki
        private BaseCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(()=>this.OnRequestClose());// ta komenda wywoła metodę OnRequestClose
                return _CloseCommand;
            }
        }
        #endregion

        #region Helpers
        public event EventHandler RequestClose;
        private void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
    }
}
