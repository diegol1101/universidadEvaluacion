using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository
{
    public class Curso_EscolarRepository : GenericRepository<Curso_Escolar>, ICurso_Escolar
    {
        protected readonly UniversidadEvaluacionContext _context;
        
        public Curso_EscolarRepository(UniversidadEvaluacionContext context) : base (context)
        {
            _context = context;
        }
    
        public override async Task<IEnumerable<Curso_Escolar>> GetAllAsync()
        {
            return await _context.Curso_Escolares
                .ToListAsync();
        }
    
        public override async Task<Curso_Escolar> GetByIdAsync(int id)
        {
            return await _context.Curso_Escolares
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
}