using MusterAGOrderManagement.ViewModel.Address;
using System.Windows.Controls;

namespace MusterAGOrderManagement.View
{
    /// <summary>
    /// Interaction logic for Address.xaml
    /// </summary>
    public partial class Address : UserControl
    {
        public Address()
        {
            DataContext = new AddressViewModel();
            InitializeComponent();
        }
    }
}
