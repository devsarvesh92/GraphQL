using System;
using System.Collections.Generic;
using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.Platforms
{

    /// <summary>
    /// PlatformType
    /// </summary>
    public class PlatformType : ObjectType<Platform>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="descriptor"></param>
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents Platforms or services that has command line interface");
            descriptor.Field(p => p.LicenseKey).Ignore();

            descriptor.Field(p => p.Commands).
                       ResolveWith<Resolvers>(p => p.GetCommands(new Platform() { Id = 1 }, default!)).
                       UseDbContext<AppDbContext>().Description("Get Commands for Platfor").UseFiltering().UseSorting();
        }

        public class Resolvers
        {
            /// <summary>
            /// GetCommands
            /// </summary>
            /// <param name="platform"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
            {
                try
                {
                    return context.Commands.Where(p => p.PlatformId == platform.Id);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }

    }
}