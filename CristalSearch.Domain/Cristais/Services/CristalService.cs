using CristalSearch.Domain.Cristais.DTO;
using CristalSearch.Domain.Cristais.Filtros;
using System.Collections.Generic;
using System.Linq;

namespace CristalSearch.Domain.Cristais.Services
{
    public class CristalService : ICristalService
    {
        public void SalvarCristal(CristalDTO cristalDTO, out bool cristalJaExiste)
        {
            var cristaisExistentes = Domain.Cristal.CristalRepository.ObterCristais();
            if (cristaisExistentes.Any(c => c.Nome == cristalDTO.Nome && c.Id != cristalDTO.Id))
            {
                cristalJaExiste = true;
                return;
            }
            cristalJaExiste = false;

            var cristal = new Cristal
            {
                Id = cristalDTO.Id,
                Nome = cristalDTO.Nome,
                Cor = cristalDTO.Cor,
                Planeta = cristalDTO.Planeta,
                Significado = cristalDTO.Significado
            };

            Domain.Cristal.CristalRepository.Manter(cristal);
        }

        public List<CristalDTO> ObterCristais()
        {
            var cristais = Domain.Cristal.CristalRepository.ObterCristais();
            var listaDeCristais = cristais.Select(c => new CristalDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Cor = c.Cor,
                Planeta = c.Planeta,
                Significado = c.Significado
            }).ToList();

            return listaDeCristais;
        }

        public List<CristalDTO> Filtar(FiltroCristal filtro)
        {
            var listaFiltrada = Domain.Cristal.CristalRepository.Filtrar(filtro);
            var listaDTO = listaFiltrada.Select(c => new CristalDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Cor = c.Cor,
                Planeta = c.Planeta,
                Significado = c.Significado
            }).OrderBy(c => c.Nome).ToList();

            return listaDTO;
        }

        public void Excluir(int id)
        {
            Domain.Cristal.CristalRepository.Excluir(id);
        }


    }
}
