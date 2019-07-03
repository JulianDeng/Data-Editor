using EditingCollections.DataModel;
using EditingCollections.View;
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
        private MainWindowViewModel Model { get { return DataContext as MainWindowViewModel; } }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Model.IsBusy = true;

            var dispatcher = Application.Current.Dispatcher;
            DataEditorMainWindow win = new DataEditorMainWindow();
            Task.Factory.StartNew(() =>
            {
                DataEditorViewModel vm = new DataEditorViewModel();
                vm.DataItems.generateRandomItems();
                foreach(DataItem dItem in vm.DataItems)
                {
                    vm.ViewItems.Add(dItem);
                }
                dispatcher.Invoke(() =>
                {
                    win.DataContext = vm;
                    win.LaunchWindow();
                    Model.IsBusy = false;
                });
            });
        }
    }
}
