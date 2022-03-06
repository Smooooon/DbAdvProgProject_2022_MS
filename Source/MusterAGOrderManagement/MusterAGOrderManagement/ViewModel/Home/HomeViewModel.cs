using MusterAG.BusinessLogic.Domain;
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
