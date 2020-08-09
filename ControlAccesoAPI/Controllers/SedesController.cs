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
    public class SedesController : ControllerBase
    {
        ControlAccesoContext db = new ControlAccesoContext();


        [HttpGet("[action]/{id}")]
        public IActionResult GetSedesxEmpresa(int id)
        {
            Response response = new Response();
            try
            {
                var query = (from emp in db.Empresas
                             join sed in db.Sedes on emp.Id equals sed.EmpresaId
                             where emp.Id==id
                             select new
                             {
                               sed.Id,
                               sed.EmpresaId,
                               EmpresaNombre= emp.Nombre,
                               sed.Nombre,
                               sed.Telefono,
                               sed.Direccion
                             }).ToList();

                List<Sedes> list = new List<Sedes>();
                if (query!=null)
                {
                    foreach(var item in query)
                    {
                        Sedes sed = new Sedes();
                        sed.Id = item.Id;
                        sed.EmpresaNombre = item.EmpresaNombre;
                        sed.Nombre = item.Nombre;
                        sed.Telefono = item.Telefono;
                        sed.Direccion = item.Direccion;
                        list.Add(sed);
                    }
                    response.IsSuccessful = true;
                    response.Data = list;
                }
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
                Sedes list = db.Sedes.Find(id);
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
        public IActionResult Add(Sedes model)
        {
            Response response = new Response();
            try
            {
                Sedes obj = new Sedes();
                obj.EmpresaId = model.EmpresaId;
                obj.Nombre = model.Nombre;
                obj.Telefono = model.Telefono;
                obj.Direccion = model.Direccion;
                db.Sedes.Add(obj);
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
        public IActionResult Edit(Sedes model)
        {
            Response response = new Response();
            try
            {
                Sedes obj = new Sedes();
                obj.Id = model.Id;
                obj.EmpresaId = model.EmpresaId;
                obj.Nombre = model.Nombre;
                obj.Telefono = model.Telefono;
                obj.Direccion = model.Direccion;
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
                Sedes obj = db.Sedes.Find(Id);
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
