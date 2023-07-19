using Domain;
using Microsoft.Extensions.Logging;
using Repository.DAO;
using Repository.DBContext;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AssetService : IAsset
    {
        private ILogger<AssetService> _logger;
        private readonly AssetRepository assetRepository;

        public AssetService(ILogger<AssetService> logger, ApplicationDBContext context)
        {
            _logger = logger;
            assetRepository = new AssetRepository(context);
        }
        public int CreateAssets(Activo activo)
        {
            int succes = 0;
            try
            {
                succes = assetRepository.Create(activo);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return succes;
        }

        public List<Activo> GetAssets()
        {
            List<Activo> activos = new List<Activo>();

            try
            {
                activos = assetRepository.GetAssets();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activos;
        }

        public List<Activo> GetAssetsUnused() 
        {
            List<Activo> activos= new List<Activo>();
            try
            {
                activos = assetRepository.GetAssetsUnused();
            } 
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return activos;
        }


        public Activo GetAsset(int id)
        {
            Activo activo = new Activo();

            try
            {
                activo = assetRepository.GetAssetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activo;
        }

        public int UpdateAssets(Activo activo)
        {
            int succes = 0;
            try
            {
                succes = assetRepository.Update(activo);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }

        public int DeleteAssets(Activo activo)
        {
            int succes = 0;
            try
            {
                succes = assetRepository.Delete(activo);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }

        public int SetAssetAsUSed(int id)
        {
            int succes = 0;
            try
            {
                succes = assetRepository.SetAssetAsUsed(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }
        public int SetAssetAsUnuSed(int id)
        {
            int succes = 0;
            try
            {
                succes = assetRepository.SetAssetAsUnused(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }
    }
}
