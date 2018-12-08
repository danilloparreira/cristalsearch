using CristalSearch.Domain.Cristais.Filtros;
using System.Collections.Generic;

namespace CristalSearch.Domain.Cristais.Repository
{
    public partial interface ICristalRepository
    {
        void Excluir(int id);
        void Manter(Cristal cristal);
        List<Cristal> ObterCristais();
        List<Cristal> Filtrar(FiltroCristal filtro);
    }
}
