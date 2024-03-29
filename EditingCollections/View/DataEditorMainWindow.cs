﻿// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EditingCollections.DataModel;
using EditingCollections.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace EditingCollections.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DataEditorMainWindow : Window
    {
        private DataEditorViewModel Model { get { return DataContext as DataEditorViewModel; } }

        public DataEditorMainWindow()
        {
            InitializeComponent();
        }

        public bool LaunchWindow()
        {
            return (bool)ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsControl.SelectedItem == null)
            {
                MessageBox.Show("No item is selected");
                return;
            }

            var editableCollectionView =
                ItemsControl.Items as IEditableCollectionView;

            // Create a window that prompts the user to edit an item.
            var win = new ChangeItem();
            editableCollectionView.EditItem(ItemsControl.SelectedItem);
            win.DataContext = ItemsControl.SelectedItem;

            // If the user submits the new item, commit the changes.
            // If the user cancels the edits, discard the changes. 
            if ((bool) win.ShowDialog())
            {
                editableCollectionView.CommitEdit();
            }
            else
            {
                editableCollectionView.CancelEdit();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var editableCollectionView = ItemsControl.Items as IEditableCollectionView;

            if (!editableCollectionView.CanAddNew)
            {
                MessageBox.Show("You cannot add items to the list.");
                return;
            }

            // Create a window that prompts the user to enter a new
            // item to sell.
            var win = new ChangeItem {DataContext = editableCollectionView.AddNew()};

            //Create a new item to be added to the collection.

            // If the user submits the new item, commit the new
            // object to the collection.  If the user cancels 
            // adding the new item, discard the new item.
            if ((bool) win.ShowDialog())
            {
                editableCollectionView.CommitNew();
            }
            else
            {
                editableCollectionView.CancelNew();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var item = ItemsControl.SelectedItem as DataItem;

            if (item == null)
            {
                MessageBox.Show("No Item is selected");
                return;
            }

            var editableCollectionView =
                ItemsControl.Items as IEditableCollectionView;

            if (!editableCollectionView.CanRemove)
            {
                MessageBox.Show("You cannot remove items from the list.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove " + item.Description,
                "Remove Item", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                editableCollectionView.Remove(ItemsControl.SelectedItem);
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SerializeJson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeserializeJson_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    // PurchaseItem implements INotifyPropertyChanged so that the 
    // application is notified when a property changes.  It 
    // implements IEditableObject so that pending changes can be discarded.
}