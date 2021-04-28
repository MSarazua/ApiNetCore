using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly ContactoContexto _context;

        public ContactosController(ContactoContexto contexto)
        {
            _context = contexto;
        }

        // Petición de tipo GET: api/contactos 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactoItems()
        {
            //El await nos permite trabajar asincronamente
            return await _context.ContactoItems.ToListAsync();
        }

        //Petición tipo get: un solo registro: api/contactos/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContactoItem(int id)
        {
            //Guarda en la variable contactoItem lo que encuentre accediendo al modelo y buscando por id
            var contactoItem = await _context.ContactoItems.FindAsync(id);

            //Validación si encuetra o no un registro
            if(contactoItem == null)
            {
                return NotFound();
            }
            return contactoItem;
        }

        //Inserción a la base de datos, petición tipo POST api/contactos
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContactoItem(Contacto item)
        {
            _context.ContactoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactoItem), new { id = item.Id }, item);
        }

        //Petición de tipo PUT: api/contactos/2
        //Con el patch puedo especificar que campos quiero actualizar 
        [HttpPut("{id}")]
        public async Task<ActionResult> PutContactoItem(int id, Contacto item)
        {
            if (id != item.Id)
            {
                //Petición inválida
                return BadRequest();
            }

            //Recibe el item que viene cuando ya valido que sí existe y cambia el State(Estado) a modificado 
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Petición delete para borrar: api/contactos/2
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactoItem(int id)
        {
            //Busca el registro
            var contactoItem = await _context.ContactoItems.FindAsync(id);
            if (contactoItem == null)
            {
                return NotFound();
            }

            _context.ContactoItems.Remove(contactoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    } 
}
