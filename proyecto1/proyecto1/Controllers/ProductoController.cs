using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApi.Modelos;
using WebApi.Servicios.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = _productoService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;

        }

        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return NotFound();
            }
            _productoService.RegistrarProducto(producto);
            return producto;
        }

        [HttpPut]
        public ActionResult<Producto> Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.id)
            {
                return BadRequest();

            }
            _productoService.Edit(id, producto);
            return producto;
        }

        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var producto = _productoService.Delete(id);
            if(producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpGet]
        public ActionResult<List<Producto>> GetAll()
        {
            var listProductos = _productoService.GetAll();
            if(listProductos == null)
            {
                return NotFound();
            }
            return listProductos.ToList();

        }
    }
}
