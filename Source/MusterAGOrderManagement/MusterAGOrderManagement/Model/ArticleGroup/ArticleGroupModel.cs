using System.Collections.ObjectModel;

namespace MusterAGOrderManagement.Model.ArticleGroup
{
    internal class ArticleGroupModel : BaseModel
    {
        private ObservableCollection<ArticleGroupItemModel>? _articleGroups { get; set; }
        public ObservableCollection<ArticleGroupItemModel> ArticleGroups
        {
            get { return _articleGroups; }
            set
            {
                _articleGroups = value;
                OnPropertyChanged();
            }
        }
        private ArticleGroupItemModel _selectedItem { get; set; }
        public ArticleGroupItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
    }
}
