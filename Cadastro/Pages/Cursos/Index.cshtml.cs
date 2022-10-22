using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Data;
using Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cadastro.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        //Conexao com banco de dados
        private readonly Contexto _contexto;
        public IndexModel(Contexto contexto)
        {
            _contexto = contexto;
        }
        //
        public IEnumerable<Curso> Cursos { get; set; }
        [TempData]
        public string Mensagem { get; set; } //para as notificações
        public async Task OnGet()
        {
            Cursos = await _contexto.Cursos.ToListAsync();
        }


        //BORRAR
        public async Task<IActionResult> OnPostDeletar( int id)
        {
           
                var curso = await _contexto.Cursos.FindAsync(id);
                if(curso == null)
                {
                    return NotFound();
                }
 
                _contexto.Cursos.Remove(curso);
                await _contexto.SaveChangesAsync();
                Mensagem = "Curso deletado com sucesso";
            return RedirectToPage("Index");
            
        }
    }
}