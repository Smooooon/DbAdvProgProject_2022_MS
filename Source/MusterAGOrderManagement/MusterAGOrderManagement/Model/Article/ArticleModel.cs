using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAGOrderManagement.Model.Article
{
    internal class ArticleModel
    {
        public ObservableCollection<ArticleItemModel>? Articles { get; set; }
        public ArticleItemModel SelectedItem { get; set; }
        public ArticleItemModel NewItem { get; set; }
    }
}
