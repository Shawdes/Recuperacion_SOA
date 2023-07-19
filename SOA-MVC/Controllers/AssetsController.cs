using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;
using Microsoft.AspNetCore.Authorization;

namespace SOA_MVC.Controllers
{
    [Authorize]
    public class AssetsController : Controller
    {

        private readonly IAsset _assetService;

        public AssetsController(IAsset asset)
        {
            _assetService = asset;
        }

        public IActionResult Index()
        {
            var lista = _assetService.GetAssets();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activo activo)
        {
            var result = _assetService.CreateAssets(activo);

            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(activo);
            }
        }

        public IActionResult Edit(int id)
        {

            Activo activo = _assetService.GetAsset(id);
            return View(activo);
        }
        [HttpPost]
        public IActionResult Edit(Activo activo)
        {
            var result = _assetService.UpdateAssets(activo);

            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(activo);
            }
        }

        [HttpPost]
        public IActionResult Delete(Activo activo)
        {
            var result = _assetService.DeleteAssets(activo);

            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");

            }
        }
    }
}
