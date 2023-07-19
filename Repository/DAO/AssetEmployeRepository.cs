using Domain;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class AssetEmployeRepository
    {
        private readonly ApplicationDBContext _context;

        public AssetEmployeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Activo_Empleado> GetAssetsEmployes()
        {
            return _context.activo_Empleados.ToList();
        }

        public int Create(Activo_Empleado activoEmpleado)
        {
            _context.activo_Empleados.Add(activoEmpleado);
            return _context.SaveChanges();
        }

        public Activo_Empleado GetById(int id)
        {
            return _context.activo_Empleados.FirstOrDefault(e => e.Id == id);
        }

        public List<Activo_Empleado> GetEmployedoById(int id)
        {
            return _context.activo_Empleados.Where(e => e.Id_Empleado == id).ToList();
        }

        public int Update(Activo_Empleado activoEmpleado)
        {
            _context.activo_Empleados.Update(activoEmpleado);
            return _context.SaveChanges();
        }

        public int Delete(Activo_Empleado activoEmpleado)
        {
            _context.activo_Empleados.Remove(activoEmpleado);
            return _context.SaveChanges();
        }
    }
}
