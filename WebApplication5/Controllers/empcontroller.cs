using demo.bl.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class empcontroller : Controller
    {
        private readonly iemployeeservice _empservice;

        public empcontroller(iemployeeservice empservice)
        {
            _empservice = empservice;
        }

        public IActionResult Index()
        {
            var emp = _empservice.getallemp();
            return View(emp);
        }
    }

}
