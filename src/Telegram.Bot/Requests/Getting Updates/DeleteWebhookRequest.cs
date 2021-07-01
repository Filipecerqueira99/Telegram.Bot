// ReSharper disable once CheckNamespace
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests
{
    /// <summary>
    /// Use this method to remove webhook integration if you decide to switch back to <see cref="GetUpdatesRequest"/>. Returns True on success.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class DeleteWebhookRequest : ParameterlessRequest<bool>
    {
        /// <summary>
        /// Pass True to drop all pending updates
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? DropPendingUpdates { get; set; }

        /// <summary>
        /// Initializes a new request
        /// </summary>
        public DeleteWebhookRequest()
            : base("deleteWebhook")
        { }
    }
}
