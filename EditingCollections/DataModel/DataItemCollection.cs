// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.ObjectModel;

namespace EditingCollections.DataModel
{
    public class DataItemCollection : ObservableCollection<DataItem>
    {
        public DataItemCollection()
        {
            Add((new DataItem("Snowboard and bindings", 120)));
            Add((new DataItem("Inside C#, second edition", 10)));
            Add((new DataItem("Laptop - only 1 year old", 499.99)));
            Add((new DataItem("Set of 6 chairs", 120)));
            Add((new DataItem("My DVD Collection", 15)));
            Add((new DataItem("TV Drama Series", 39.985)));
            Add((new DataItem("Squash racket", 60)));
        }
    }
}