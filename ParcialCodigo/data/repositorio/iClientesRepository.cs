using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iClientesRepository
    {
        Task<IEnumerable<clientes>> getClientes();
        Task<clientes> getClienteById(int id);
        Task<bool> insertCliente(clientes cliente);
        Task<bool> updateCliente(clientes cliente);
        Task<bool> deleteCliente(int id);
    }
}
