using Domain;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeService : IEmploye
    {
        private ILogger<EmployeService> _logger;
        private readonly EmployeRepository employeRepository;
        private readonly AssetEmployeRepository assetEmployeRepository;
        private readonly AssetRepository assetRepository;

        public EmployeService(ILogger<EmployeService> logger, ApplicationDBContext context)
        {
            _logger = logger;
            employeRepository = new EmployeRepository(context);
        }
        public int CreateEmployes(Empleado empleado)
        {
            int succes = 0;
            try
            {
                succes = employeRepository.Create(empleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return succes;
        }

        public List<Empleado> GetEmployes()
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                empleados = employeRepository.GetEmployes();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleados;

        }

        public Empleado GetEmploye(int id)
        {
            Empleado empleado = new Empleado();

            try
            {
                empleado = employeRepository.GetEmployeById(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleado;
        }

        public int UpdateEmployes(Empleado empleado)
        {
            int succes = 0;
            try
            {
                succes = employeRepository.Update(empleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }

        public int DeleteEmployes(Empleado empleado)
        {
            int succes = 0;
            try
            {
                succes = employeRepository.Delete(empleado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return succes;
        }
        public void DeleteEmployeeAndAssets(Empleado empleado)
        {
            List<Activo_Empleado> assignedAssets = assetEmployeRepository.GetEmployedoById(empleado.Id);

            employeRepository.Delete(empleado);

            foreach (var asset in assignedAssets)
            {
                var assetToUpdate = assetRepository.SetAssetAsUnused(asset.Id);
            }
        }
    }
}
