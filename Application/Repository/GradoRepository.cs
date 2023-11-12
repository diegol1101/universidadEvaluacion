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
    public class GradoRepository : GenericRepository<Grado>, IGrado
    {
        protected readonly UniversidadEvaluacionContext _context;
        
        public GradoRepository(UniversidadEvaluacionContext context) : base (context)
        {
            _context = context;
        }
    
        public override async Task<IEnumerable<Grado>> GetAllAsync()
        {
            return await _context.Grados
                .ToListAsync();
        }
    
        public override async Task<Grado> GetByIdAsync(int id)
        {
            return await _context.Grados
            .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }
}