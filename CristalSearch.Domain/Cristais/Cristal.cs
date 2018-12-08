namespace CristalSearch.Domain.Cristais
{
    public class Cristal
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cor { get; set; }
        public virtual string Planeta { get; set; }
        public virtual string Significado { get; set; }
    }
}
