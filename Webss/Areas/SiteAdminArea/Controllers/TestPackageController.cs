using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class TestPackageController : Controller
    {
        ITestPackage repo;
        public TestPackageController(ITestPackage repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }


        [HttpGet]
        public async Task<ActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(TestPackageDTO rec)
        {


            if (ModelState.IsValid)
            {
                await this.repo.Add(rec);

                return RedirectToAction("Index");

            }
            return View(rec);


        }


        [HttpGet]
        public async Task<IActionResult> Edit(Int64 id)
        {
            var test = await repo.GetAllTestpackagedets();
            var testDto = test.FirstOrDefault(t => t.TestPackageID == id);



            return View(testDto);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(Int64 id, TestPackageDTO testDto)
        {


            if (ModelState.IsValid)
            {
                await repo.Edit(testDto);
                return RedirectToAction(nameof(Index));
            }
            return View(testDto);
        }
        public async Task<IActionResult> Delete(long id)
        {

            var tests = await repo.GetAllTestpackagedets();
            var testDto = tests.FirstOrDefault(t => t.TestPackageID == id);
            await repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Deatils( Int64 id)
        {
            var res = await this.repo.Get(id);
            return View(res);
        }

    }
}
