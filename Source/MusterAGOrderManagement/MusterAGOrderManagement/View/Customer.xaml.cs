using MusterAGOrderManagement.ViewModel.Customer;
using System.Windows.Controls;

namespace MusterAGOrderManagement.View
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        public Customer()
        {
            DataContext = new CustomerViewModel();
            InitializeComponent();
        }
    }
}
