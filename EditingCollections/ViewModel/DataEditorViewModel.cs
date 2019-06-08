﻿using EditingCollections.DataModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EditingCollections.ViewModel
{
    public class DataEditorViewModel : BindableBase
    {
        private DataItemCollection _dataItems;
        private DataItemCollection _viewItems;
        private bool _isEnabled;

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

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set
            {
                this._isEnabled = value;
                this.OnPropertyChanged(() => IsEnabled);
            }
        }

        internal void ViewItemsContextSwitch(string text)
        {
            ViewItems.Clear();
            foreach(DataItem dItem in DataItems)
            {
                if (dItem.Description.Contains(text))
                {
                    ViewItems.Add(dItem);
                }
            }
        }
    }
}
