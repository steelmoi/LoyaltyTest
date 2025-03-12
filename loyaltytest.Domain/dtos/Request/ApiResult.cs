using Newtonsoft.Json;

namespace loyaltytest.Domain.dtos.Request
{
    public class ApiResult
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("data")]
        public object? Data { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
