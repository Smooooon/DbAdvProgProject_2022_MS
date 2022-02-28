using Caliburn.Micro;
using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Article;
using MusterAGOrderManagement.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MusterAGOrderManagement.Model.Home;

namespace MusterAGOrderManagement.ViewModel.Home
{
    internal class HomeViewModel
    {
        HomeModel _homeModel = new HomeModel();

        public HomeViewModel()
        {
            IsDatabaseConnected = false;
        }

        public bool IsDatabaseConnected
        {
            get { return _homeModel.IsDatabaseConnected; }
            set
            {
                _homeModel.IsDatabaseConnected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
