using Microsoft.AspNetCore.Mvc;
using IG.DevIO.UI.ViewModels;
using Interfaces;
using AutoMapper;
using Models;

namespace Controllers
{


    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SuppliersController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<IEnumerable<SupplierViewModel>>(await supplierRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
                return View(supplierViewModel);

            var supplier = mapper.Map<Supplier>(supplierViewModel);
            await supplierRepository.Create(supplier);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierProductAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }
            return View(supplierViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(supplierViewModel);

            var supplier = mapper.Map<Supplier>(supplierViewModel);
            await supplierRepository.Update(supplier);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
                return NotFound();

            await supplierRepository.Remove(id);

            return RedirectToAction("Index");
        }

        private async Task<SupplierViewModel> GetSupplierAddress(Guid id)
        {
            return mapper.Map<SupplierViewModel>(await supplierRepository.GetSupplierAddress(id));
        }

        private async Task<SupplierViewModel> GetSupplierProductAddress(Guid id)
        {
            return mapper.Map<SupplierViewModel>(await supplierRepository.GetSupplierProductAddress(id));
        }
    }
}
