using CrudNativo.Data;
using CrudNativo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudNativo.Controllers
{
    public class LibroController : Controller
    { 
        //Esto es para acceder a la base de datos
        private readonly AplicationDbContext _context; 

        //creamos el contructor

        public LibroController(AplicationDbContext context)
        {
            _context = context;
        }

        //Metodo Get index

        public IActionResult Index()
        {
            //creamos lista de datos IEnumerable
            IEnumerable<Libro> ListLibros = _context.libro;
            return View(ListLibros);//retornar la lista
        }

        //HTTP get create

        public IActionResult create() {
            return View();
        }

        [HttpPost]


        public IActionResult create(Libro libro) {
            if (ModelState.IsValid)
            {
                _context.libro.Add(libro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }
    }
}
