using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using CalculationModule;
using Package;

namespace Demostration
{
    /// <summary>
    /// Логика взаимодействия для Informator.xaml
    /// </summary>
    public partial class Informator : Window
    {
        internal ObservableCollection<DataGridCollectionItem> Items { get; private set; }
        public Informator()
        {
            InitializeComponent();
            Items = new ObservableCollection<DataGridCollectionItem>();
            DataGrid.ItemsSource = Items;
        }
    }

    internal class DataGridCollectionItem
    {
        public int DataID { get; set; }

        public decimal SolderID { get; set; }

        public string ValueName { get; set; }

        public string Value { get; set; }

        public string Rezult { get; set; }
    }
}
