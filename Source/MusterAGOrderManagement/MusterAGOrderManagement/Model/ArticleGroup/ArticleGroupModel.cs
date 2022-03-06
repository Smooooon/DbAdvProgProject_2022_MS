using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.ArticleGroup
{
    internal class ArticleGroupModel
    {
        public ObservableCollection<ArticleGroupItemModel>? ArticleGroups { get; set; }
        public ArticleGroupItemModel SelectedItem { get; set; }
    }
}
