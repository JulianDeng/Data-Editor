// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.ObjectModel;

namespace EditingCollections
{
    public class DataItemCollection : ObservableCollection<DataItem>
    {
        public DataItemCollection()
        {
            Add((new DataItem("Snowboard and bindings", 120, new DateTime(2009, 1, 1))));
            Add((new DataItem("Inside C#, second edition", 10, new DateTime(2009, 2, 2))));
            Add((new DataItem("Laptop - only 1 year old", 499.99, new DateTime(2009, 2, 28))));
            Add((new DataItem("Set of 6 chairs", 120, new DateTime(2009, 2, 28))));
            Add((new DataItem("My DVD Collection", 15, new DateTime(2009, 1, 1))));
            Add((new DataItem("TV Drama Series", 39.985, new DateTime(2009, 1, 1))));
            Add((new DataItem("Squash racket", 60, new DateTime(2009, 2, 28))));
        }
    }
}