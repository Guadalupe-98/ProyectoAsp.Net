using Microsoft.EntityFrameworkCore;
using WebApi.Modelos;
using WebApi.Servicios.Context;
using WebApi.Servicios.Interfaces;

namespace WebApi.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDBContext _context;
        public ProductoService(ApplicationDBContext context)
        {
            _context = context;
        }

        public Producto Delete(int id)
        {
            var producto = _context.Producto.FirstOrDefault<Producto>(x=>x.id==id);
            if (producto == null)
            {
                return null;
            }
            _context.Producto.Remove(producto);
            return producto;
        }

        public Producto Edit(int id, Producto producto)
        {
            if (producto.id != id) {
                return null;
            }
            _context.Entry(producto).State = EntityState.Modified;
            _context.SaveChanges();

            return producto;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _context.Producto.ToList();
        }

        public Producto GetProductoById(int id)
        {
            var producto = _context.Producto.FirstOrDefault(x=>x.id==id);
            if (producto == null)
            {
                return null;
            }
            return producto;
        }

        public Producto RegistrarProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            _context.SaveChanges();
            return producto;
        }
    }
}
