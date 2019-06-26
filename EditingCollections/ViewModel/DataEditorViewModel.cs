using EditingCollections.DataModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EditingCollections.ViewModel
{
    public class DataEditorViewModel : BindableBase
    {
        private DataItemCollection _dataItems;
        private DataItemCollection _viewItems;
        private bool _isBusy;
        private bool _isEnabled;
        private string _nameSearch;

        public DataEditorViewModel()
        {
            _dataItems = new DataItemCollection();
            _viewItems = new DataItemCollection();
            _isEnabled = true;
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

        public bool IsAdminUser
        {
            get { return ConfigurationManager.AppSettings.Get("adminUser").Contains(Environment.UserName); }
        }

        public bool IsBusy
        {
            get { return this._isBusy ; }
            set
            {
                this._isBusy = value;
                this.OnPropertyChanged(() => IsBusy);
            }
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set
            {
                this._isEnabled = value;
                this.OnPropertyChanged(() => IsEnabled);
            }
        }

        public string NameSearch
        {
            get { return this._nameSearch; }
            set
            {
                this._nameSearch = value;
                this.OnPropertyChanged(() => NameSearch);
                OnSearchTextChanged();
            }
        }

        internal void OnSearchTextChanged()
        {
            ViewItems.Clear();
            foreach(DataItem dItem in DataItems)
            {
                if (Regex.IsMatch(dItem.Description, NameSearch == null ? "" : NameSearch, RegexOptions.IgnoreCase))
                {
                    ViewItems.Add(dItem);
                }
            }
        }
    }
}
