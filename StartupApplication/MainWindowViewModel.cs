using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplication
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set
            {
                this._isBusy = value;
                this.OnPropertyChanged(() => IsBusy);
            }
        }
    }
}
