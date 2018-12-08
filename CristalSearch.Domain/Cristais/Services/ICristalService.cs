using CristalSearch.Domain.Cristais.DTO;
using CristalSearch.Domain.Cristais.Filtros;
using System.Collections.Generic;

namespace CristalSearch.Domain.Cristais.Services
{
    public interface ICristalService
    {
        void Excluir(int id);
        void SalvarCristal(CristalDTO cristal, out bool nomeDoCristalJaExiste);
        List<CristalDTO> ObterCristais();
        List<CristalDTO> Filtar(FiltroCristal filtro);
    }
}
