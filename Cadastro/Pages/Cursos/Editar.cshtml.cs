using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Data;
using Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Cadastro.Pages.Cursos
{
    public class Editar : PageModel
    {
           
        private readonly Contexto _contexto;
        public Editar(Contexto contexto)
        {
            _contexto = contexto;
        }
      
        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensagem { get; set; } 

        public async Task OnGet(int id) 
        {
            Curso = await _contexto.Cursos.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoBD = await _contexto.Cursos.FindAsync(Curso.Id);

                CursoBD.Nome = Curso.Nome;
                CursoBD.QuantidadeAulas = Curso.QuantidadeAulas;
                CursoBD.Preco = Curso.Preco;
                 
                await _contexto.SaveChangesAsync();
                Mensagem = "Curso editado correctamente";
                return RedirectToPage("Index");

            }
            
            return RedirectToPage();
        }
    }
}