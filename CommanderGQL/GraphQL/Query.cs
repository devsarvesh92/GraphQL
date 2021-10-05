using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL
{
    /// <summary>
    /// GraphQL Endpoint
    /// </summary>
    public class Query
    {

        /// <summary>
        /// GetPlatforms
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public IQueryable<Platform> GetPlatforms([Service] AppDbContext dbContext)
        {
            return dbContext.Platforms;
        }
    }
}