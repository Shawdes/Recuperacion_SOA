using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAssetEmploye
    {
        List<Activo_Empleado> GetAssetsEmployes();
        List<Activo_Empleado> GetEmployeById(int id);
        int CreateAssetsEmployes(Activo_Empleado activoEmpleado);
        Activo_Empleado GetAssetEmploye(int id);
        int UpdateAssetsEmployes(Activo_Empleado activoEmpleado);
        int DeleteAssetsEmployes(Activo_Empleado activoEmpleado);
    }
}
