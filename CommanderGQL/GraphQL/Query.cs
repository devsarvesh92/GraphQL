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
        [UseFiltering]
        [UseSorting]
        /// <summary>
        /// GetPlatforms
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext dbContext)
        {
            return dbContext.Platforms;
        }


        /// <summary>
        /// Gets the queryable <see cref="Command"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Command"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}