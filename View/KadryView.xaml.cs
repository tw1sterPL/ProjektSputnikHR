using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt.View
{
    /// <summary>
    /// Interaction logic for KadryView.xaml
    /// </summary>
    public partial class KadryView : UserControl
    {
        public KadryView()
        {
            InitializeComponent();
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            KadryNewView kadryNewView = new KadryNewView();          
            kadryNewView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            kadryNewView.Show();
        }

        private void Label_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
