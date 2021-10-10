using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.Commands
{

    /// <summary>
    /// Represents Command Type
    /// </summary>
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Field(p => p.Platform).
                       ResolveWith<PlatoformResolver>(p => p.GetPlatform(default!, default!)).UseDbContext<AppDbContext>();
        }
    }

    /// <summary>
    /// PlatoformResolver
    /// </summary>
    class PlatoformResolver
    {

        /// <summary>
        /// GetPlatform of Command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="appDbContext"></param>
        /// <returns></returns>
        public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext appDbContext)
        {
            return appDbContext.Platforms.Where(p => p.Id == command.PlatformId).FirstOrDefault();
        }

    }
}