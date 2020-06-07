using Project.Core.Interfaces;
using Project.Core.Model;
using System;
using System.Collections.Generic;

namespace Project.Business
{
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaBusiness(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public void AddCategoria(Categoria categoria)
        {
            if(categoria.Codigo.Length == 4)
            {
                _repository.AddCategoria(categoria);
            }
        }

        public void AttCategoria(Categoria categoria)
        {
            _repository.AttCategoria(categoria);
        }

        public void DelCategoria(Categoria categoria)
        {
            _repository.DelCategoria(categoria);
        }

        public Categoria GetCategoriaById(Guid Id)
        {
            var result = _repository.GetCategoriaById(Id);
            return result;
        }

        public List<Categoria> GetCategorias()
        {
            var result = _repository.GetCategorias();
            return result;
        }

        public List<Categoria> GetCategoriasByDescricao(string descricao)
        {
            var result = _repository.GetCategoriasByDescricao(descricao);
            return result;
        }
    }
}
