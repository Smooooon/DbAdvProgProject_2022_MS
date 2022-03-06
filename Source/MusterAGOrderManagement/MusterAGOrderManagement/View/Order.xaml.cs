using MusterAGOrderManagement.ViewModel.Order;
using System.Windows.Controls;

namespace MusterAGOrderManagement.View
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        public Order()
        {
            DataContext = new OrderViewModel();
            InitializeComponent();
        }
    }
}
