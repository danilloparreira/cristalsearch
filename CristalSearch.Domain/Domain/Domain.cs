using CristalSearch.Domain.Cristais.Repository;
using CristalSearch.Domain.Cristais.Services;

namespace CristalSearch.Domain
{
    public static class Domain
    {
        public static class Cristal
        {
            public static ICristalRepository CristalRepository
            {
                get
                {
                    return new CristalRepository();
                }
                private set { }
            }

            public static ICristalService CristalService
            {
                get
                {
                    return new CristalService();
                }
                private set { }
            }
        }
    }
}
