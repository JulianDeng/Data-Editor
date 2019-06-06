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
            : this("New item", 0)
        {

        }

        public DataItem(string desc, double price)
        {
            GuidID = Guid.NewGuid();
            Description = desc;
            Price = price;
            Type = MyType.None;
            LastTime = DateTime.Now;
            LastPrices = new LinkedList<double>();
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

        public double Price
        {
            get { return _currentData.Price; }
            set
            {
                if (_currentData.Price != value)
                {
                    _currentData.Price = value;
                    NotifyPropertyChanged("Price");
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

        public LinkedList<double> LastPrices
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

        public override string ToString() => $"{Description}, {Price:c}, {LastTime:D}";

        private struct ItemData
        {
            internal Guid GuidID;
            internal string Description;
            internal double Price;
            internal MyType Type;
            internal DateTime LastTime;
            internal LinkedList<double> LastPrices;
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