using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iTiposSegurosRepository
    {
        Task<IEnumerable<tiposSeguros>> getTipoSeguro();
        Task<tiposSeguros> getTipoSeguroById(int id);
        Task<bool> insertTipoSeguro(tiposSeguros tipoSeguro);
        Task<bool> updateTipoSeguro(tiposSeguros tipoSeguro);
        Task<bool> deleteTipoSeguro(int id);
    }
}
