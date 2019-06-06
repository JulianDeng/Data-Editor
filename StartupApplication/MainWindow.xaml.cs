﻿using EditingCollections.View;
using EditingCollections.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataEditorViewModel Model { get { return DataContext as DataEditorViewModel; } }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataEditorViewModel();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            DataEditorMainWindow win = new DataEditorMainWindow();
            win.LaunchWindow();
        }
    }
}
