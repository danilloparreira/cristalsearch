using CristalSearch.Domain.Cristais.Filtros;
using System.Collections.Generic;
using System.Linq;

namespace CristalSearch.Domain.Cristais.Repository
{
    public partial class CristalRepository : ICristalRepository
    {
        public void Manter(Cristal cristal)
        {
            if (cristal.Id > 0)
            {
                DomainInfra.FluentNHibernateHelper<Cristal>.Update(cristal);
            }
            else
            {
                var listaDeCristais = DomainInfra.FluentNHibernateHelper<Cristal>.QueryList<Cristal>();
                if (!listaDeCristais.Any())
                {
                    cristal.Id = 1;
                }
                else
                {
                    cristal.Id = ++listaDeCristais.LastOrDefault().Id;
                }

                DomainInfra.FluentNHibernateHelper<Cristal>.Save(cristal);
            }
        }

        public List<Cristal> ObterCristais() {
            var listaCristais = DomainInfra.FluentNHibernateHelper<Cristal>.QueryList<Cristal>();

            return listaCristais.ToList();
        }

        public List<Cristal> Filtrar(FiltroCristal filtro)
        {
            var listaDeCristais = DomainInfra.FluentNHibernateHelper<Cristal>.QueryList<Cristal>().ToList();

            listaDeCristais = FiltrarPorNome(listaDeCristais, filtro.Nome);
            listaDeCristais = FiltrarPorCor(listaDeCristais, filtro.Cor);

            return listaDeCristais;
        }

        public void Excluir(int id)
        {
            var cristal = DomainInfra.FluentNHibernateHelper<Cristal>.Load<Cristal>(id);

            DomainInfra.FluentNHibernateHelper<Cristal>.Delete(cristal);
        }


        private List<Cristal> FiltrarPorNome(List<Cristal> lista, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return lista;
            }

            var listaFiltrada = lista.Where(c => c.Nome.Contains(nome)).ToList();

            return listaFiltrada;
        }

        private List<Cristal> FiltrarPorCor(List<Cristal> lista, string cor)
        {
            if (string.IsNullOrWhiteSpace(cor))
            {
                return lista;
            }

            var listaFiltrada = lista.Where(c => c.Cor.Contains(cor)).ToList();

            return listaFiltrada;
        }
    }
}
