using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Core.Model;

namespace Project.Repository
{
    public class CategoriaContext : DbContext
    {
        public CategoriaContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
