using EditingCollections.DataModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditingCollections.ViewModel
{
    public class DataEditorViewModel : BindableBase
    {
        private DataItemCollection _dataItems;
        private DataItemCollection _viewItems;

        public DataEditorViewModel()
        {
            _dataItems = new DataItemCollection();
            _viewItems = new DataItemCollection();
        }

        public DataItemCollection DataItems
        {
            get { return this._dataItems; }
            set
            {
                this._dataItems = value;
                this.OnPropertyChanged(() => DataItems);
            }
        }

        public DataItemCollection ViewItems
        {
            get { return this._viewItems; }
            set
            {
                this._viewItems = value;
                this.OnPropertyChanged(() => ViewItems);
            }
        }
    }
}
