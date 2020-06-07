using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Core.Interfaces;
using Project.Core.Model;

namespace Project.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CategoriaContext _context;
        public CategoriaRepository(CategoriaContext context)
        {
            _context = context;
        }

        public void AddCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void AttCategoria(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void DelCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

        public Categoria GetCategoriaById(Guid Id)
        {
            var result = _context.Categorias.Find(Id);
            return result;
        }

        public List<Categoria> GetCategorias()
        {
            var result = _context.Categorias.ToList();
            return result;
        }

        public List<Categoria> GetCategoriasByDescricao(string descricao)
        {
            var result = _context.Categorias.Where(c => c.Descricao == descricao).ToList();
            return result;
        }
    }
}
