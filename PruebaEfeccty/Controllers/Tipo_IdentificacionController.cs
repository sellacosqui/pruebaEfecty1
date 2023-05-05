using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEfeccty.Data;
using PruebaEfeccty.Models;
using System.Diagnostics;

namespace PruebaEfeccty.Controllers
{
    public class Tipo_IdentificacionController : Controller
    {
        private readonly ILogger<Tipo_IdentificacionController> _logger;
        private readonly ApplicationDbContext _context;

        public Tipo_IdentificacionController(ILogger<Tipo_IdentificacionController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Tipo_Identificacion> tipos = new List<Tipo_Identificacion>();
            tipos = _context.Tipo_Identificacion.ToList();
            return View(tipos);
        }
        public IActionResult Data()
        {
            List<Tipo_Identificacion> tipos = new List<Tipo_Identificacion>();
            tipos = _context.Tipo_Identificacion.ToList();
            return View(tipos);
        }
        [HttpPost]
        public JsonResult Create([FromBody] Tipo_Identificacion Tipo_Identificacion)
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


                var model = _context.Tipo_Identificacion.Add(Tipo_Identificacion);
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
                Tipo_Identificacion model = _context.Tipo_Identificacion.Where(f => f.Id == id).First();

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
        public JsonResult Edit([FromBody] Tipo_Identificacion Tipo_Identificacion)
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


                var model = _context.Tipo_Identificacion.Update(Tipo_Identificacion);
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

                var model = _context.Tipo_Identificacion.Where(f => f.Id == id).First();
                if (model == null)
                {
                    response.IsSuccess = false;
                    response.Message = "error";
                }
                else
                {
                    _context.Tipo_Identificacion.Remove(model);
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
}