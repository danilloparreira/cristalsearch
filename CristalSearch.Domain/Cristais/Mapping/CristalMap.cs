using FluentNHibernate.Mapping;

namespace CristalSearch.Domain.Cristais.Mapping
{
    public class CristalMap : ClassMap<Cristal>
    {
        public CristalMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Nome);
            Map(x => x.Cor);
            Map(x => x.Planeta);
            Map(x => x.Significado);

            Table("dbo.Cristal");
        }
    }
}
