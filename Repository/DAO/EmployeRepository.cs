using Domain;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class EmployeRepository
    {
        private readonly ApplicationDBContext _context;

        public EmployeRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        //obtener lista de empleados

        public List<Empleado> GetEmployes()
        {
            return _context.Empleados.ToList();
        }

        public Empleado GetEmployeById(int id)
        {
            return _context.Empleados.FirstOrDefault(e => e.Id == id);
        }
        public int Create(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            return _context.SaveChanges();
        }

        public int Update(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            return _context.SaveChanges();
        }

        public int Delete(Empleado empleado)
        {
            _context.Empleados.Remove(empleado);
            return (_context.SaveChanges());
        }
    }
}
