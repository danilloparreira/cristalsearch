using CristalSearch.Domain.Cristais.DTO;
using CristalSearch.Web.Models;

namespace CristalSearch.Web.Extends
{
    public static class CristalModelExtend
    {
        public static CristalDTO ToDTO(this CristalModel cristalModel)
        {
            var cristalDTO = new CristalDTO
            {
                Id = !int.TryParse(cristalModel.Id, out int valor) ? 0 : valor,
                Nome = cristalModel.Nome,
                Cor = cristalModel.Cor,
                Planeta = cristalModel.Planeta,
                Significado = cristalModel.Significado
            };

            return cristalDTO;
        }
    }
}