using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL
{
    /// <summary>
    /// GraphQL Endpoint
    /// </summary>
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        /// <summary>
        /// GetPlatforms
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Platforms;
        }
    }
}