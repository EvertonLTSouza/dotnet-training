using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        void AddCategoria(Categoria categoria);
        void DelCategoria(Categoria categoria);
        void AttCategoria(Categoria categoria);
        Categoria GetCategoriaById(Guid Id);
        List<Categoria> GetCategorias();
        List<Categoria> GetCategoriasByDescricao(string descricao);
    }
}
