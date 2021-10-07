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
        [UseProjection]
        /// <summary>
        /// GetPlatforms
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        /// <summary>
        /// GetCommands
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Commands;
        }



    }
}