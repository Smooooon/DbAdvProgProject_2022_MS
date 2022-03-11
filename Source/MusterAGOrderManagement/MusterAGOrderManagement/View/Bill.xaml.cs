using MusterAGOrderManagement.ViewModel.Bill;
using System.Windows.Controls;

namespace MusterAGOrderManagement.View
{
    /// <summary>
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : UserControl
    {
        public Bill()
        {
            DataContext = new BillViewModel();
            InitializeComponent();
        }
    }
}
