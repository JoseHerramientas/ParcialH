using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iVentasRepository
    {
        Task<IEnumerable<ventas>> getVenta();
        Task<ventas> getVentaById(int id);
        Task<bool> insertVenta(ventas venta);
        Task<bool> updateVenta(ventas venta);
        Task<bool> deleteVenta(int id);
    }
}
