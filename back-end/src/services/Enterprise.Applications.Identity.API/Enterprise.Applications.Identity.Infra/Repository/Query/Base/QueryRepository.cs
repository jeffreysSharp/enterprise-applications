using Enterprise.Applications.Identity.Domain.Repositories.Query.Base;
using Enterprise.Applications.Identity.Infra.Data;
using Microsoft.Extensions.Configuration;

namespace Enterprise.Applications.Identity.Infra.Repository.Query.Base
{
    // Generic Query repository class
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
