using System;
using System.Text.Json.Serialization;

namespace Base.Application.ViewModel
{
    public record BaseView
    {
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }
    }
}
