using Domain;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class AssetRepository
    {
        private readonly ApplicationDBContext _context;

        public AssetRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Activo> GetAssets()
        {
            return _context.Activos.ToList();
        }

        public int Create(Activo activo)
        {
            _context.Activos.Add(activo);
            return _context.SaveChanges();
        }

        public Activo GetAssetById(int id)
        {
            return _context.Activos.FirstOrDefault(e => e.Id == id);
        }

        public List<Activo> GetAssetsUnused()
        {
            return _context.Activos.Where(e => e.Estatus == false).ToList();
        }

        public int SetAssetAsUsed(int id)
        {
            var result = _context.Activos.FirstOrDefault(e => e.Id == id);
            result.Estatus = true;
            _context.Activos.Update(result);
            return _context.SaveChanges();
        }

        public int SetAssetAsUnused(int id)
        {
            var result = _context.Activos.FirstOrDefault(e => e.Id == id);
            result.Estatus = false;
            _context.Activos.Update(result);
            return _context.SaveChanges();
        }

        public int Update(Activo activo)
        {
            _context.Activos.Update(activo);
            return _context.SaveChanges();
        }

        public int Delete(Activo activo)
        {
            _context.Activos.Remove(activo);
            return (_context.SaveChanges());
        }
    }
}
