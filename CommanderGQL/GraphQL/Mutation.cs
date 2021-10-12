using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.Platforms;
using HotChocolate;
using HotChocolate.Data;
using CommanderGQL.Models;
using CommanderGQL.Commands;
using System;
using HotChocolate.Subscriptions;
using System.Threading;
using CommanderGQL.Subscriptions;

namespace CommanderGQL.GraphQL
{
    /// <summary>
    /// Mutation
    /// </summary>
    public class Mutation
    {

        /// <summary>
        /// AddPlatform
        /// </summary>
        /// <param name="appDbContext"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatform([ScopedService] AppDbContext appDbContext
                                                        , AddPlatformInput input,
                                                        [Service] ITopicEventSender eventSender,
                                                        CancellationToken cancellationToken)
        {
            var platform = new Platform()
            {
                Name = input.name
            };
            appDbContext.Platforms.Add(platform);

            await appDbContext.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);

        }


        /// <summary>
        /// AddCommandForPlatform
        /// </summary>
        /// <param name="appDbContext"></param>
        /// <param name="commandInput"></param>
        /// <returns></returns>
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandForPlatformAsync([ScopedService] AppDbContext appDbContext, AddCommandInput commandInput)
        {
            if (commandInput is null)
            {
                throw new ArgumentNullException(nameof(commandInput));
            }

            var command = new Command()
            {
                CommandLine = commandInput.CommandLine,
                HowTo = commandInput.HowTo,
                PlatformId = commandInput.PlatformId
            };

            appDbContext.Commands.Add(command);

            await appDbContext.SaveChangesAsync();

            return new AddCommandPayload(command);

        }

    }
}