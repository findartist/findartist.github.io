using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwoMinds.DAL;
using WebApplication2Minds.Models;
using WebApplication2Minds.Utilities;
using PagedList;
using System.Threading.Tasks;

namespace WebApplication2Minds.Controllers
{
    public class ProductController : Controller
    {
        IUnitOfWork _uow;
        IRepository<Product> _productRepository;

        public ProductController()
        {
            _uow = new UnitOfWork(new TwoMindsEntities());
            _productRepository = _uow.GetRepository<Product>();
        }

        // GET: Product
        public ActionResult Index(int? page)
        {
            var products = _productRepository.GetAll();
            
            var data = new PagingList<Product>(products.AsQueryable());
            data.PageSize = 10;
            data.PageNumber = page ?? 1;

            return View(data);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var prod = _productRepository.GetById(id);

            return View(prod);            
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                _productRepository.Add(product);
                await _uow.Commit();                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = _productRepository.GetById(id);

            return View(prod);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                _productRepository.Update(product);
                _uow.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var prod = _productRepository.GetById(id);
            return View(prod);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                var prod = _productRepository.GetById(id);
                _productRepository.Remove(prod);
                _uow.Commit();
                                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task< ActionResult> GenerateItems()
        {
            // Generating random values
            var products = DataMock.MockProducts(50000);

            // Deleting Data
            _productRepository.RemoveRange(_productRepository.GetAll());            
            await _uow.Commit();

            int i = 0;
            foreach (var product in products)
            {
                _productRepository.Add(product);

                i++;
                if (i % 100 == 0)
                    await _uow.Commit();
            }
            await _uow.Commit();

            return RedirectToAction("Index");
        }        
    }   
}
