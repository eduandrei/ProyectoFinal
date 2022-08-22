using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTO;
using ProyectoFinal.MODEL;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            try
            {
                return VentaHandler.GetVentas();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Venta>();
            }

        }

        [HttpDelete]
        public bool EliminarVenta([FromBody] int id)
        {
            try
            {
                return VentaHandler.EliminarVenta(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        [HttpPost]
        public bool CrearVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.CrearVenta(new Venta
                {
                    Comentarios = venta.Comentarios
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        [HttpPut]
        public bool ModificarVenta([FromBody] PutVenta venta)
        {
            try
            {
                return VentaHandler.ModificarVenta(new Venta
                {
                    Id = venta.Id,
                    Comentarios = venta.Comentarios
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
