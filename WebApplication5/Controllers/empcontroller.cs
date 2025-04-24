using demo.bl.dto;
using demo.bl.services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using demo.datalayer.models.employeemodel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class empcontroller : Controller
    {
        private readonly iemployeeservice _empservice;
        private readonly ILogger<empcontroller> _logger;
        private readonly IWebHostEnvironment _environment;

        public empcontroller(iemployeeservice empservice, ILogger<empcontroller> logger, IWebHostEnvironment environment)
        {
            _empservice = empservice;
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            //binding through views dictionry:transfer data from action to view
            //1.view data
            ViewData["Message"] = "hello";
            //2.view bag
            ViewBag.Message = "hello view bag";
            var emp = _empservice.getallemp();
            return View(emp);
        }

        #region create employee
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(empviewmodel empdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp=new CreatedEmpDto() { 
                    Name = empdto.Name,
                    Address= empdto.Address,
                    Age= empdto.Age,
                    IsActive= empdto.IsActive,
                    Email= empdto.Email,
                    EmployeeType= empdto.EmployeeType,
                    Gender= empdto.Gender,
                    HiringDate= empdto.HiringDate,
                    PhoneNumber= empdto.PhoneNumber,
                    Salary= empdto.Salary,
                    };
                    int result = _empservice.createemp(emp);
                    //3.temp data
                    if (result > 0)
                    {
                        TempData["Message"] = "employee created succesfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = "employee created failed";
                        ModelState.AddModelError(string.Empty, "Employee not created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.EnvironmentName == "Development")
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        ModelState.AddModelError(string.Empty, "An error occurred while creating the employee.");
                    }
                }
            }

            return View(empdto);
        }
        #endregion
        #region details
        [HttpGet]
        public IActionResult details(int id) {
            if (id == 0) return BadRequest();
            var employee=_empservice.getempbyid(id);
            if(employee == null)return NotFound();
            return View(employee);
        }
        #endregion
        #region edit
        [HttpGet]
        public IActionResult edit(int? id) {
        if(id == 0) return BadRequest();
            var employee = _empservice.getempbyid(id.Value);
if(employee == null)return NotFound();
            var employeedto = new empviewmodel()
            {
              
                Name = employee.name,
                Address = employee.address,
                Age = employee.age,
                Email = employee.email,
                IsActive = employee.isactive,

                PhoneNumber = employee.phonenumber,
                Gender = Enum.Parse<empgender>(employee.gender),
                EmployeeType = Enum.Parse<emptype>(employee.employeetype)
            };
               return View(employeedto);
        }

        #endregion
        #region delete
        public IActionResult delete (int id)
        {
            if(id==0) return BadRequest();
            try
            {
                var deleted = _empservice.deletedemp(id);
                if (deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "employee not deleted");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                if (_environment.EnvironmentName == "Development")
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the employee.");
                }
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}

