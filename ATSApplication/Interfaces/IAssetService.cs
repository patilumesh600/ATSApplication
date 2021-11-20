using ATSApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSApplication.Interfaces
{
    public interface IAssetService
    {
        List<Asset_VM> GetAll();
        string Delete(int ID);
        string AddOrUpdate(Asset_VM Asset);
    }
}
