using Util.Notification.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace Base
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode statusCode, IReadOnlyCollection<MyNotification> notifications)
        {
            StatusCode = statusCode;
            TraceId = Activity.Current?.Id;

            if (notifications is null || !notifications.Any())
                return;

            var errors = (from key in notifications
                          select new
                          {
                              key.Key,
                              Values = (from value in notifications where value.Key.Equals(key.Key) select value.Value).ToArray()
                          }).ToDictionary(x => x.Key, x => x.Values);

            Errors = errors;
        }

        [JsonPropertyName("type")]
        public string Type => GetUrl();

        [JsonPropertyName("title")]
        public string Title => "One or more validation errors occurred.";

        [JsonPropertyName("status")]
        public HttpStatusCode StatusCode { get; }

        [JsonPropertyName("traceId")]
        public string TraceId { get; }

        [JsonPropertyName("errors")]
        public Dictionary<string, string[]> Errors { get; }

        private string GetUrl()
        {
            const string url = @"https:" + @"//tools.ietf.org/html/rfc7231#section-{0}";

            return StatusCode switch
            {
                HttpStatusCode.Continue => string.Format(url, "6.2.1"),
                HttpStatusCode.SwitchingProtocols => string.Format(url, "6.2.2"),

                HttpStatusCode.OK => string.Format(url, "6.3.1"),
                HttpStatusCode.Created => string.Format(url, "6.3.2"),
                HttpStatusCode.Accepted => string.Format(url, "6.3.3"),
                HttpStatusCode.NonAuthoritativeInformation => string.Format(url, "6.3.4"),
                HttpStatusCode.NoContent => string.Format(url, "6.3.5"),
                HttpStatusCode.ResetContent => string.Format(url, "6.3.6"),

                HttpStatusCode.MultipleChoices => string.Format(url, "6.4.1"),
                HttpStatusCode.MovedPermanently => string.Format(url, "6.4.2"),
                HttpStatusCode.Found => string.Format(url, "6.4.3"),
                HttpStatusCode.SeeOther => string.Format(url, "6.4.4"),
                HttpStatusCode.UseProxy => string.Format(url, "6.4.5"),
                HttpStatusCode.Unused => string.Format(url, "6.4.6"),
                HttpStatusCode.TemporaryRedirect => string.Format(url, "6.4.7"),

                HttpStatusCode.BadRequest => string.Format(url, "6.5.1"),
                HttpStatusCode.PaymentRequired => string.Format(url, "6.5.2"),
                HttpStatusCode.Forbidden => string.Format(url, "6.5.3"),
                HttpStatusCode.NotFound => string.Format(url, "6.5.4"),
                HttpStatusCode.MethodNotAllowed => string.Format(url, "6.5.5"),
                HttpStatusCode.NotAcceptable => string.Format(url, "6.5.6"),
                HttpStatusCode.RequestTimeout => string.Format(url, "6.5.7"),
                HttpStatusCode.Conflict => string.Format(url, "6.5.8"),
                HttpStatusCode.Gone => string.Format(url, "6.5.9"),
                HttpStatusCode.LengthRequired => string.Format(url, "6.5.10"),
                HttpStatusCode.RequestUriTooLong => string.Format(url, "6.5.12"),
                HttpStatusCode.UnsupportedMediaType => string.Format(url, "6.5.13"),
                HttpStatusCode.ExpectationFailed => string.Format(url, "6.5.14"),
                HttpStatusCode.UpgradeRequired => string.Format(url, "6.5.15"),

                HttpStatusCode.InternalServerError => string.Format(url, "6.6.1"),
                HttpStatusCode.NotImplemented => string.Format(url, "6.6.2"),
                HttpStatusCode.BadGateway => string.Format(url, "6.6.3"),
                HttpStatusCode.ServiceUnavailable => string.Format(url, "6.6.4"),
                HttpStatusCode.GatewayTimeout => string.Format(url, "6.6.5"),
                HttpStatusCode.HttpVersionNotSupported => string.Format(url, "6.6.6"),

                _ => string.Format(url, "6.5.1")
            };
        }
    }
}
