using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Data
{
    public class Contexto : DbContext
    {
        
       public Contexto(DbContextOptions<Contexto> options) : base(options)
       {
        
       }
       public DbSet<Curso> Cursos {get; set;}
    }
}