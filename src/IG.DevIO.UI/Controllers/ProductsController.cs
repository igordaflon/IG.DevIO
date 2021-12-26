using Microsoft.AspNetCore.Mvc;
using IG.DevIO.UI.ViewModels;
using Interfaces;
using AutoMapper;
using Models;

namespace Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository productRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<IEnumerable<ProductViewModel>>(await productRepository.GetProductsSuppliers()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var productViewModel = await FillSuppliers(new ProductViewModel());
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await FillSuppliers(productViewModel);

            if (!ModelState.IsValid)
                return View(productViewModel);

            await productRepository.Create(mapper.Map<Product>(productViewModel));
            return View(productViewModel);

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
                return NotFound();

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(productViewModel);

            await productRepository.Update(mapper.Map<Product>(productViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var product = await GetProduct(Id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid Id)
        {
            var product = await GetProduct(Id);

            if (product == null)
                return NotFound();

            await productRepository.Remove(Id);

            return RedirectToAction("Index");
        }

        private async Task<ProductViewModel> GetProduct(Guid Id)
        {
            var product = mapper.Map<ProductViewModel>(await productRepository.GetProductSupplier(Id));
            product.Suppliers = mapper.Map<IEnumerable<SupplierViewModel>>(await supplierRepository.GetAll());

            return product;
        }

        private async Task<ProductViewModel> FillSuppliers(ProductViewModel product)
        {
            product.Suppliers = mapper.Map<IEnumerable<SupplierViewModel>>(await supplierRepository.GetAll());

            return product;
        }
    }
}
