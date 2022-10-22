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
    public class Criar : PageModel
    {
      
        private readonly Contexto _contexto;
        public Criar(Contexto contexto)
        {
            _contexto = contexto;
        }
         
        [BindProperty]
        public Curso Curso { get; set; }   
        [TempData]
        public string Mensagem { get; set; }  

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            Curso.DataCriacao = DateTime.Now;

            _contexto.Add(Curso);
            await _contexto.SaveChangesAsync();
            Mensagem = "Curso criado com sucesso";

            return RedirectToPage("Index");
        }
        

    }
}