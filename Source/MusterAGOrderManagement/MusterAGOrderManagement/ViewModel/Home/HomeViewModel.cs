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
    internal class HomeViewModel : BaseViewModel
    {
        HomeModel _homeModel = new HomeModel();

        public HomeViewModel()
        {
            IsDatabaseConnected = false;

            InstallNewestMigration();
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

        private void InstallNewestMigration()
        {
            HomeDomain homeDomain = new HomeDomain();
            homeDomain.InstallNewestMigration();
        }
    }
}
