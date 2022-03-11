using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAGOrderManagement.Model.Article
{
    internal class ArticleModel : BaseModel
    {
        private ObservableCollection<ArticleItemModel>? _articles { get; set; }
        public ObservableCollection<ArticleItemModel> Articles
        {
            get { return _articles; }
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }
        private ArticleItemModel _selectedItem { get; set; }
        public ArticleItemModel SelectedItem
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
