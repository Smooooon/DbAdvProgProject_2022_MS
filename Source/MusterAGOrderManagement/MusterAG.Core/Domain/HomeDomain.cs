using DataAccessLayer.Services;
using MusterAG.DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.BusinessLogic.Domain
{
    public class HomeDomain
    {
        private HomeDataService _homeDataService = new HomeDataService();

        public void InstallNewestMigration()
        {
            _homeDataService.InstallNewestMigration();
        }
    }
}
