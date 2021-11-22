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
        Asset_VM GetAssetDetails(Int64 AssetId);
        string AddOrUpdate(Asset_VM Asset);
        string EnabledAsset(Int64 AssetId);
        string DisabledAsset(Int64 AssetId);
    }
}
