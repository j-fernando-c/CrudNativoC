using CrudNativo.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNativo.Data
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
        //instanciamos el modelo libros 

        public DbSet<Libro> libro { get; set; }
    }


}
