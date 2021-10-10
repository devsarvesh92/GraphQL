using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.Platforms;
using HotChocolate;
using HotChocolate.Data;
using CommanderGQL.Models;
using CommanderGQL.Commands;
using System;

namespace CommanderGQL.GraphQL
{
    /// <summary>
    /// Mutation
    /// </summary>
    public class Mutation
    {

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatform([ScopedService] AppDbContext appDbContext, AddPlatformInput input)
        {
            var platform = new Platform()
            {
                Name = input.name
            };
            appDbContext.Platforms.Add(platform);

            await appDbContext.SaveChangesAsync();
            return new AddPlatformPayload(platform);

        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandForPlatformAsync([ScopedService] AppDbContext appDbContext, AddCommandInput commandInput)
        {
            if (commandInput is null)
            {
                throw new ArgumentNullException(nameof(commandInput));
            }

            var command = new Command()
            {
                CommandLine=commandInput.CommandLine,
                HowTo = commandInput.HowTo,
                PlatformId = commandInput.PlatformId
            };
            appDbContext.Commands.Add(command);

            await appDbContext.SaveChangesAsync();

            return new AddCommandPayload(command);

        }

    }
}