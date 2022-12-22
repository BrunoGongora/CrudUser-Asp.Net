using Crud_Asp.Net.Context;
using Crud_Asp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Crud_Asp.Net.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger; Esto no es necesario por el context
        public readonly ApliccationDbContext _context;


        public HomeController(ApliccationDbContext context)
        {
            //_logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Esto sirve para prevenir ataques xxs, se usa solo para los post
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid) //Esto vaida que todos los campos de el formulario esten debidamente diligenciados
            {
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); //Esto sirve para indicarle a donde debe redirigir una vez envie los datos. 
            }

            return View(); //Esto retorna la vista en casi de que hayan campos vacios y la vista que devuelve es el mismo formulario. 
        }


        //Este metodo es para el boton de editar
        [HttpGet]
        public IActionResult Editar(int? id) //Este simbolo de ? indica que puede ser null el valor
        {
            if(id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contacto.Find(id);
            if(contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        //Este metodo envia la informacion editada a la base de datos

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid) 
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        //Este metodo mostrara el detalle de cada usuario
        [HttpGet]
        public IActionResult Detalle(int? id) //Este simbolo de ? indica que puede ser null el valor
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        //Este metodo es para traer por id el archivo que se va a eliminar 
        [HttpGet]
        public IActionResult Eliminar(int? id) //Este simbolo de ? indica que puede ser null el valor
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        //Este metodo envia por post el registro que se va a elimianr 
        [HttpPost, ActionName("Eliminar")] //El action name se usa para poder usar otro  nombre en el metodo sin que afecte la vista, se usa cuando hay dos metodos con el mismo nombre
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarUsuario(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if(contacto == null)
            {
                return View();
            }

            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}