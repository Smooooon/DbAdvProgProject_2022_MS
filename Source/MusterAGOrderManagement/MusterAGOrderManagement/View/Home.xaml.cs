using MusterAGOrderManagement.ViewModel.Home;
using System.Windows;
using System.Windows.Controls;
using MusterAGOrderManagement.Article.ViewModel;
using MusterAGOrderManagement.ViewModel.ArticleGroup;
using MusterAGOrderManagement.ViewModel.Customer;
using MusterAGOrderManagement.ViewModel.Order;
using MusterAGOrderManagement.ViewModel.Position;
using MusterAGOrderManagement.ViewModel.Address;
using MusterAGOrderManagement.ViewModel.Bill;

namespace MusterAGOrderManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new HomeViewModel();
            InitializeComponent();
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                TabItem tabitem = e.AddedItems[0] as TabItem;
                if (tabitem == null)
                    return;

                //Daten des jeweiligen Tab aktualisieren
                switch (tabitem.Content)
                {
                    case View.ArticleGroup ag:
                        ArticleGroupViewModel articleGroupViewModel = (ArticleGroupViewModel)ag.DataContext;
                        articleGroupViewModel.RefreshData();
                        break;
                    case View.Article a:
                        ArticleViewModel articleViewModel = (ArticleViewModel)a.DataContext;
                        articleViewModel.RefreshData();
                        break;
                    case View.Order o:
                        OrderViewModel orderViewModel = (OrderViewModel)o.DataContext;
                        orderViewModel.RefreshData();
                        break;
                    case View.Position p:
                        PositionViewModel positionViewModel = (PositionViewModel)p.DataContext;
                        positionViewModel.RefreshData();
                        break;
                    case View.Customer c:
                        CustomerViewModel customerViewModel = (CustomerViewModel)c.DataContext;
                        customerViewModel.RefreshData();
                        break;
                    case View.Address a:
                        AddressViewModel addressViewModel = (AddressViewModel)a.DataContext;
                        addressViewModel.RefreshData();
                        break;
                    case View.Bill b:
                        BillViewModel billViewModel = (BillViewModel)b.DataContext;
                        billViewModel.RefreshData();
                        break;
                    default:
                        return;

                }
            }
        }

        private void Statistic_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
