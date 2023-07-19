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
    public class AssetEmployeService : IAssetEmploye
    {
        private ILogger<AssetEmployeService> _logger;
        private readonly AssetEmployeRepository assetEmployeRepository;

        public AssetEmployeService(ILogger<AssetEmployeService> logger, ApplicationDBContext context)
        {
            _logger = logger;
            assetEmployeRepository = new AssetEmployeRepository(context);
        }
        public int CreateAssetsEmployes(Activo_Empleado activoEmpleado)
        {
            int succes = 0;
            try
            {
                succes = assetEmployeRepository.Create(activoEmpleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return succes;
        }

        public List<Activo_Empleado> GetAssetsEmployes()
        {
            List<Activo_Empleado> activoEmpleados = new List<Activo_Empleado>();

            try
            {
                activoEmpleados = assetEmployeRepository.GetAssetsEmployes();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activoEmpleados;
        }

        public Activo_Empleado GetAssetEmploye(int id)
        {
            Activo_Empleado activoEmpleado = new Activo_Empleado();

            try
            {
                activoEmpleado = assetEmployeRepository.GetById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activoEmpleado;
        }

        public int UpdateAssetsEmployes(Activo_Empleado activoEmpleado)
        {
            int succes = 0;
            try
            {
                succes = assetEmployeRepository.Update(activoEmpleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }

        public int DeleteAssetsEmployes(Activo_Empleado activoEmpleado)
        {
            int succes = 0;
            try
            {
                succes = assetEmployeRepository.Delete(activoEmpleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }

        public List<Activo_Empleado> GetEmployeById(int id)
        {
            List<Activo_Empleado> activoEmpleados = new List<Activo_Empleado>();

            try
            {
                activoEmpleados = assetEmployeRepository.GetEmployedoById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activoEmpleados;
        }
    }
}
