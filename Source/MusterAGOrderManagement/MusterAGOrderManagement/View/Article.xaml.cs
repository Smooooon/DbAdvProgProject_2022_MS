using MusterAGOrderManagement.Article.ViewModel;
using System.Windows.Controls;

namespace MusterAGOrderManagement.View
{
    /// <summary>
    /// Interaction logic for Article.xaml
    /// </summary>
    public partial class Article : UserControl
    {
        public Article()
        {
            DataContext = new ArticleViewModel();
            InitializeComponent();
        }
    }
}
