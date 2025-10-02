using GamersCommunity.Core.Rabbit;
using Microsoft.Extensions.Options;
using Serilog;

namespace MainSite.Consumer
{
    /// <summary>
    /// Concrete RabbitMQ consumer for the MainSite microservice.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Inherits from <see cref="BasicServiceConsumer"/> and specifies the queue to consume from.
    /// </para>
    /// <para>
    /// This consumer will listen on the queue <c>"MainSite_queue"</c> and use the provided
    /// <see cref="TableRouter"/> to dispatch incoming messages to the appropriate table service.
    /// </para>
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MainSiteServiceConsumer"/> class.
    /// </remarks>
    /// <param name="otps">RabbitMQ settings injected from configuration.</param>
    /// <param name="tableRouter">Router responsible for message dispatch.</param>
    /// <param name="logger">Application logger (Serilog).</param>
    public class MainSiteServiceConsumer(IOptions<RabbitMQSettings> otps, TableRouter tableRouter, ILogger logger) : BasicServiceConsumer(otps, tableRouter, logger)
    {
        /// <summary>
        /// Gets or sets the queue name this consumer will listen on.
        /// Default value is <c>"mainsite_queue"</c>.
        /// </summary>
        public override string QUEUE { get; set; } = "mainsite_queue";
    }
}
