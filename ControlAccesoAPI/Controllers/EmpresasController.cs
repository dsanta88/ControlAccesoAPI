using System;
using System.Collections.Generic;
using System.Linq;
using ControlAccesoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlAccesoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        ControlAccesoContext db = new ControlAccesoContext();

        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                List<Empresas> list = db.Empresas.ToList();
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            Response response = new Response();
            try
            {
                Empresas list = db.Empresas.Find(id);
                response.IsSuccessful = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }


        [HttpPost]
        public IActionResult Add(Empresas model)
        {
            Response response = new Response();
            try
            {
                Empresas obj = new Empresas();
                obj.Nombre = model.Nombre;
                obj.Telefono = model.Telefono;
                obj.Direccion = model.Direccion;
                obj.Logo = model.Logo;
                db.Empresas.Add(obj);
                db.SaveChanges();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(Empresas model)
        {
            Response response = new Response();
            try
            {
                Empresas obj = db.Empresas.Find(model.Id);
                obj.Nombre = model.Nombre;
                obj.Telefono = model.Telefono;
                obj.Direccion = model.Direccion;
                obj.Logo = model.Logo;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Response response = new Response();
            try
            {
                Empresas obj = db.Empresas.Find(Id);
                db.Remove(obj);
                db.SaveChanges();
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
