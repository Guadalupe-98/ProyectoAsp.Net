using Microsoft.AspNetCore.Mvc;
using Modelos;
using WebApi.Modelos;




namespace WebApi.Servicios.Interfaces

{
    public interface IProductoService
    {
        Producto RegistrarProducto(Producto producto);

        Producto GetProductoById(int id);

        IEnumerable<Producto> GetAll();

        Producto Delete(int id);

        Producto Edit(int id, Producto producto);

    }

}
