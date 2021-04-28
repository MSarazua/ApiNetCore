using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebApi.Data
{
    public class ContactoContexto : DbContext
    {
        public ContactoContexto(DbContextOptions<ContactoContexto> options):base(options)
        {

        }
        //Crear dbset, va a llamar a nuestro modelo Contacto
        public DbSet<Contacto> ContactoItems { get; set; }
    }
}
