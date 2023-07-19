using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAsset
    {
        List<Activo> GetAssets();
        List<Activo> GetAssetsUnused();
        int SetAssetAsUSed(int id);
        int SetAssetAsUnuSed(int id);
        int CreateAssets(Activo activo);
        Activo GetAsset(int id);
        int UpdateAssets(Activo activo);
        int DeleteAssets(Activo activo);
    }
}
