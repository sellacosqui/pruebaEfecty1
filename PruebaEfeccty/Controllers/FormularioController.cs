using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEfeccty.Data;
using PruebaEfeccty.Models;
using System.Diagnostics;
using System.Linq;

namespace PruebaEfeccty.Controllers
{
    public class FormularioController : Controller
    {
        private readonly ILogger<FormularioController> _logger;
        private readonly ApplicationDbContext _context;

        public FormularioController(ILogger<FormularioController> logger , ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Formulario> forms = new List<Formulario>();
            forms = _context.Formulario.Include(f=>f.Tipo_Identificacionmodel).ToList();
            return View(forms);
        }
        public IActionResult Data()
        {
            List<Formulario> forms = new List<Formulario>();
            forms = _context.Formulario.Include(f => f.Tipo_Identificacionmodel).ToList();
            return View(forms);
        }
        public List<Tipo_Identificacion> Tipo_Identificacion()
        {
            List<Tipo_Identificacion> forms = new List<Tipo_Identificacion>();
            forms = _context.Tipo_Identificacion.ToList();
            return forms;
        }
        [HttpPost]
        public JsonResult Create([FromBody] Formulario Formulario)
        {
            var eventId = Guid.NewGuid().ToString();
            try
            {
                var response = new Response
                {
                    IsSuccess = true,
                    Result = null,
                    Message = "Guardar"
                };

                
                var model = _context.Formulario.Add(Formulario);
                _context.SaveChanges();
                     
                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    IsSuccess = true,
                    Result = null,
                    Message = "error al guardar" + ex.Message
                };
                return Json(response);
            }
        }

        [HttpGet]
        public JsonResult Edit(int id)
        {
            try
            {
                Formulario model = _context.Formulario.Where(f=> f.Id == id).First();

                var response = new Response
                {
                    IsSuccess = true,
                    Result = model
                };
                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    IsSuccess = false,
                    Result = null,
                    Message = "error"
                };
                return Json(response);
            }
        }

        [HttpPost]
        public JsonResult Edit([FromBody] Formulario Formulario)
        {
            var eventId = Guid.NewGuid().ToString();
            try
            {
                var response = new Response
                {
                    IsSuccess = true,
                    Result = null,
                    Message = "modificar"
                };

                
                    var model = _context.Formulario.Update(Formulario);
                    _context.SaveChanges();
                    if (model == null)
                    {
                        response.IsSuccess = false;
                        response.Message = "Error";
                    }
               
                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    IsSuccess = true,
                    Result = null,
                    Message = "error"
                };
                return Json(response);
            }
        }

        
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var eventId = Guid.NewGuid().ToString();
            try
            {
                var response = new Response
                {
                    IsSuccess = true,
                    Result = null,
                    Message = "eliminar"
                };

                var model = _context.Formulario.Where(f => f.Id == id).First();
                if (model == null)
                {
                    response.IsSuccess = false;
                    response.Message = "error";
                }
                else
                {
                    _context.Formulario.Remove(model);
                    _context.SaveChanges();
                }

                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    IsSuccess = true,
                    Result = null,
                    Message = "error" + ex.Message
                };
                return Json(response);
            }
        }
    }
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Redirect { get; set; }
        public object Result { get; set; }
        public IQueryable<object> ListResult { get; set; }
    }
}