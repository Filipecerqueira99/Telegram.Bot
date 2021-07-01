using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests
{
    /// <summary>
    /// se this method to send invoices. On success, the sent <see cref="Message"/> is returned.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendInvoiceRequest : RequestBase<Message>,
                                      INotifiableMessage,
                                      IReplyMessage,
                                      IInlineReplyMarkupMessage
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format <c>@channelusername</c>)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long ChatId { get; }

        /// <summary>
        /// Product name, 1-32 characters
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Title { get; }

        /// <summary>
        /// Product description, 1-255 characters
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Description { get; }

        /// <summary>
        /// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Payload { get; }

        /// <summary>
        /// Payments provider token, obtained via <see href="https://t.me/botfather">@Botfather</see>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string ProviderToken { get; }

        /// <summary>
        /// Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Currency { get; }

        /// <summary>
        /// Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<LabeledPrice> Prices { get; }

        /// <summary>
        /// The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double). For example, for a maximum tip of <c>US$ 1.45</c> pass <c><see cref="MaxTipAmount"/> = 145</c>. See the <i>exp</i> parameter in <see href="https://core.telegram.org/bots/payments/currencies.json">currencies.json</see>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies). Defaults to 0
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? MaxTipAmount { get; set; }

        /// <summary>
        /// An array of suggested amounts of tips in the <i>smallest units</i> of the currency (integer, <b>not</b> float/double). At most 4 suggested tip amounts can be specified. The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <see cref="MaxTipAmount"/>
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<int>? SuggestedTipAmounts { get; set; }

        /// <summary>
        /// Unique deep-linking parameter. If left empty, <b>forwarded copies</b> of the sent message will have a <i>Pay</i> button, allowing multiple users to pay directly from the forwarded message, using the same invoice. If non-empty, forwarded copies of the sent message will have a <i>URL</i> button with a deep link to the bot (instead of a <i>Pay</i> button), with the value used as the start parameter
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? StartParameter { get; set; }

        /// <summary>
        /// A JSON-serialized data about the invoice, which will be shared with the payment provider. A detailed description of required fields should be provided by the payment provider.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ProviderData { get; set; }

        /// <summary>
        /// URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. People like it better when they see what they are paying for.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? PhotoUrl { get; set; }

        /// <summary>
        /// Photo size
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PhotoSize { get; set; }

        /// <summary>
        /// Photo width
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PhotoWidth { get; set; }

        /// <summary>
        /// Photo height
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PhotoHeight { get; set; }

        /// <summary>
        /// Pass True, if you require the user's full name to complete the order
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? NeedName { get; set; }

        /// <summary>
        /// Pass True, if you require the user's phone number to complete the order
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? NeedPhoneNumber { get; set; }

        /// <summary>
        /// Pass True, if you require the user's email to complete the order
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? NeedEmail { get; set; }

        /// <summary>
        /// Pass True, if you require the user's shipping address to complete the order
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? NeedShippingAddress { get; set; }

        /// <summary>
        /// Pass True, if user's phone number should be sent to provider
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? SendPhoneNumberToProvider { get; set; }

        /// <summary>
        ///Pass True, if user's email address should be sent to provider
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? SendEmailToProvider { get; set; }

        /// <summary>
        /// Pass True, if the final price depends on the shipping method
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsFlexible { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? DisableNotification { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ReplyToMessageId { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? AllowSendingWithoutReply { get; set; }

        /// <summary>
        /// A JSON-serialized object for an inline keyboard. If empty, one 'Pay total price' button will be shown. If not empty, the first button must be a Pay button.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InlineKeyboardMarkup? ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new request with chatId, title, description, payload, providerToken, currency and an array of <see cref="LabeledPrice"/>
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel (in the format <c>@channelusername</c>)</param>
        /// <param name="title">Product name, 1-32 characters</param>
        /// <param name="description">Product description, 1-255 characters</param>
        /// <param name="payload">Bot-defined invoice payload, 1-128 bytes</param>
        /// <param name="providerToken">Payments provider token, obtained via <see href="https://t.me/botfather">@Botfather</see></param>
        /// <param name="currency">Three-letter ISO 4217 currency code, see <see href="https://core.telegram.org/bots/payments#supported-currencies">more on currencies</see></param>
        /// <param name="prices">Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)</param>
        public SendInvoiceRequest(long chatId,
                                  string title,
                                  string description,
                                  string payload,
                                  string providerToken,
                                  string currency,
                                  IEnumerable<LabeledPrice> prices)
            : base("sendInvoice")
        {
            ChatId = chatId;
            Title = title;
            Description = description;
            Payload = payload;
            ProviderToken = providerToken;
            Currency = currency;
            Prices = prices;
        }
    }
}
