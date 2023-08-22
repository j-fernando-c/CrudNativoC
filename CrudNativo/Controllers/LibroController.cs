using CrudNativo.Data;
using CrudNativo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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



        //Editar

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro

            var libro = _context.libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }


        //post editar

        [HttpPost]

        [ValidateAntiForgeryToken]  //seguridad de la base da datos

        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.libro.Update(libro);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            return View();


        }


        //eliminar

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro

            var libro = _context.libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }


        //post editar

        [HttpPost]

        [ValidateAntiForgeryToken]  //seguridad de la base da datos

        public IActionResult Delete(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.libro.Remove(libro);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            return View();


        }
    }

}
