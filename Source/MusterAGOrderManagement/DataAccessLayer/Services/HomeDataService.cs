using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusterAG.DataAccessLayer.Services
{
    public class HomeDataService
    {
        public void InstallNewestMigration()
        {
            using (DataContext context = new DataContext())
            {
                context.Database.Migrate(); //Datenbank wird aktualisiert sofern Migrationsdateien vorhanden
            }
        }
    }
}
