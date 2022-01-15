using Candidature.Data;
using Candidature.Models;
using Candidature.Models.Repositories;
using Candidature.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Candidature.Controllers
{
    public class ProductController : Controller
    {
        public IStoreRepository<Product> repository { get; }
        public IWebHostEnvironment hosting { get; }
        public ProductController(IStoreRepository<Product> Repository, IWebHostEnvironment webHost)
        {
            repository = Repository;
            hosting = webHost;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<Product> products = repository.GetAll();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null || id != 0)
            {
                Product p = repository.Find((int)id);
                return View(p);
            }
            else return NotFound();
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel pvm)
        {
            try
            {
                string imageName = "default-placeholder.png";
                if (pvm.Image != null)
                {
                    imageName = UploadFile(pvm.Image);
                }
                if (ModelState.IsValid)
                {
                    Product p = new Product()
                    {
                        Name = pvm.Name,
                        Description = pvm.Description,
                        ImageName = imageName,
                        InStock = pvm.InStock,
                        Price = pvm.Price,
                        Quantity = pvm.Quantity

                    };
                    repository.Add(p);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(pvm);
                }

            }
            catch (Exception ex)
            {
                return View(pvm);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = repository.Find(id);
            ProductViewModel pvm = new ProductViewModel() {
                Name = p.Name,
                Description = p.Description,
                Id = id,
                InStock=p.InStock,
                Price = p.Price,
                Quantity = p.Quantity
            };
            ViewBag.imgUrl = p.ImageName;
            return View(pvm);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel pvm)
        {
            try
            {
                ModelState["Image"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
                string imageName = repository.Find(pvm.Id).ImageName ?? "default-placeholder.png";
                if (pvm.Id == null || pvm.Id <= 0)
                {
                    NotFound();
                }
                if (pvm.Image != null)
                {
                    imageName = UploadFile(pvm.Image);
                }
                Product p = repository.Find(pvm.Id);
                if (ModelState.IsValid)
                {

                    p.Name = pvm.Name;
                    p.Description = pvm.Description;
                    p.ImageName = imageName;
                    p.InStock = pvm.InStock;
                    p.Price = pvm.Price;
                    p.Quantity = pvm.Quantity;
                    repository.Update(p);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(pvm);
                }
            }
            catch
            {
                return View(pvm);
            }

        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Find(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(repository.Find(id));
            }
        }

        string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uploadsFolder = Path.Combine(hosting.WebRootPath, "uploads");
                string filename = Guid.NewGuid().ToString() + file.FileName;
                string imagePath = Path.Combine(uploadsFolder, filename);
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
                return filename;
            }
            return null;
        }
    }
}
