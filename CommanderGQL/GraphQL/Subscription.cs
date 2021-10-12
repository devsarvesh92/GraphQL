using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.Subscriptions
{


    public class Subscription
    {

        [Topic]
        [Subscribe]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }

}