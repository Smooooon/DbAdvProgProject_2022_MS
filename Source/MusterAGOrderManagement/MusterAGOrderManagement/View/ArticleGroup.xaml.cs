using MusterAGOrderManagement.ViewModel.ArticleGroup;
using System.Windows.Controls;

namespace MusterAGOrderManagement.View
{
    /// <summary>
    /// Interaction logic for ArticleGroup.xaml
    /// </summary>
    public partial class ArticleGroup : UserControl
    {
        public ArticleGroup()
        {
            DataContext = new ArticleGroupViewModel();
            InitializeComponent();
        }
    }
}
