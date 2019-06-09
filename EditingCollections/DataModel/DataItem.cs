// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EditingCollections.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EditingCollections.DataModel
{
    public class DataItem : INotifyPropertyChanged, IEditableObject
    {
        private ItemData _copyData;
        private ItemData _currentData;

        public DataItem()
            : this("New item", "Enter value")
        {

        }

        public DataItem(string desc, string value)
        {
            GuidID = Guid.NewGuid();
            Description = desc;
            Value = value;
            Type = MyType.None;
            LastTime = DateTime.Now;
            LastPrices = new LinkedList<string>();
            LastRecordGuids = new LinkedList<Guid>();
        }

        public Guid GuidID
        {
            get { return _currentData.GuidID; }
            set
            {
                if (_currentData.GuidID != value)
                {
                    _currentData.GuidID = value;
                    NotifyPropertyChanged("GuidID");
                }
            }
        }

        public string Description
        {
            get { return _currentData.Description; }
            set
            {
                if (_currentData.Description != value)
                {
                    _currentData.Description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public string Value
        {
            get { return _currentData.Value; }
            set
            {
                if (_currentData.Value != value)
                {
                    _currentData.Value = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }

        public MyType Type
        {
            get { return _currentData.Type; }
            set
            {
                if (_currentData.Type != value)
                {
                    _currentData.Type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }

        public DateTime LastTime
        {
            get { return _currentData.LastTime; }
            set
            {
                if (value != _currentData.LastTime)
                {
                    _currentData.LastTime = value;
                    NotifyPropertyChanged("LastTime");
                }
            }
        }

        public LinkedList<string> LastPrices
        {
            get { return _currentData.LastPrices; }
            set
            {
                if (value != _currentData.LastPrices)
                {
                    _currentData.LastPrices = value;
                    NotifyPropertyChanged("LastPrices");
                }
            }
        }

        public LinkedList<Guid> LastRecordGuids
        {
            get { return _currentData.LastRecordGuids; }
            set
            {
                if (value != _currentData.LastRecordGuids)
                {
                    _currentData.LastRecordGuids = value;
                    NotifyPropertyChanged("LastRecordGuids");
                }
            }
        }

        public override string ToString() => $"{Description}, {Value:c}, {LastTime:D}";

        private struct ItemData
        {
            internal Guid GuidID;
            internal string Description;
            internal string Value;
            internal MyType Type;
            internal DateTime LastTime;
            internal LinkedList<string> LastPrices;
            internal LinkedList<Guid> LastRecordGuids;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion

        #region IEditableObject Members

        public void BeginEdit()
        {
            _copyData = _currentData;
        }

        public void CancelEdit()
        {
            _currentData = _copyData;
            NotifyPropertyChanged("");
        }

        public void EndEdit()
        {
            _copyData = new ItemData();
        }

        #endregion
    }
}