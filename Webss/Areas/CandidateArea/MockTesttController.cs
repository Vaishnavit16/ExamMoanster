using Infras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Webss.Areas.CandidateArea
{
    public class MockTesttController : Controller
    { Context cc;
        public MockTesttController(Context cc)
        {  this.cc = cc; }

       
        
            public IActionResult Index()
            {
                ViewBag.mocktestsubject = new SelectList(cc.mockTestSubjects.ToList(), "MockTestSubjectID", "SubjectTitle");
                return View(cc.mockTests.ToList());
           }
        
    }
}
