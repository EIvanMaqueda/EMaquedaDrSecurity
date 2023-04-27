using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }
        public ActionResult Form(int? IdUsuario) {
            if (IdUsuario == null)
            {
                return View();
            }
            else { 
                
                ML.Usuario usuario=new ML.Usuario();
                ML.Result result=BL.Usuario.GetById(IdUsuario.Value);
                usuario = (ML.Usuario)result.Object;
                return View(usuario);
            }
            
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario) {
            ML.Result result= new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);
            }
            else { 
                result=BL.Usuario.Update(usuario);
            }
            ViewBag.Message = result.Message;
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUsuario,int IdDireccion) {
            ML.Result result = BL.Usuario.Delete(IdUsuario,IdDireccion);
            ViewBag.Message = result.Message;   
            return PartialView("Modal");
        }

        [HttpPost]
        public JsonResult CURP(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.CURP(usuario);
            return Json(result);
        }

    }
}