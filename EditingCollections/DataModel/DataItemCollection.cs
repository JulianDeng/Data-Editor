// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EditingCollections.Enum;
using System;
using System.Collections.ObjectModel;

namespace EditingCollections.DataModel
{
    public class DataItemCollection : ObservableCollection<DataItem>
    {
        public DataItemCollection()
        {

        }

        public void generateRandomItems()
        {
            Add((new DataItem("Snowboard and bindings", "120", MyType.Currency))); ;
            Add((new DataItem("Inside C#, second edition", "10", MyType.Percentage)));
            Add((new DataItem("Laptop - only 1 year old", "499.99", MyType.Currency)));
            Add((new DataItem("Set of 6 chairs", "120", MyType.Percentage)));
            Add((new DataItem("My DVD Collection", "15", MyType.Percentage)));
            Add((new DataItem("TV Drama Series", "39.985", MyType.Currency)));
            Add((new DataItem("Squash racket", "60", MyType.String)));

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[8];
            var random = new Random();
            var name = "";
            var value = 0.00;
            MyType[] types = { MyType.String, MyType.Percentage, MyType.Currency };


            for (int i = 0; i < 2000000; i++)
            {
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }

                value = random.NextDouble() * (10000 - 0) + 200;

                Add(new DataItem(new string(stringChars), value.ToString(), types[random.Next(types.Length)]));
            }
        }
    }
}