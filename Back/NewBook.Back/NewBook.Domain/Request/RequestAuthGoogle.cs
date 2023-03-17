using System.Text.Json.Serialization;

namespace NewBook.Domain.Request
{
    public class RequestAuthGoogle
    {
        public bool isNewUser { get; set; }

        public string? email { get; set; }

        public string? family_name { get; set; }

        public string? given_name { get; set; }

        public string? name { get; set; }

        public string? idFirebase { get; set; }

        public string? locale { get; set; }

        public string? image { get; set; }

        public string? accessToken { get; set; }

        public bool verified_email { get; set; }

        public string? idToken { get; set; }

        public string? providerId { get; set; }

        public string? SignInMethod { get; set; }

        public string? phoneNumber { get; set; }

        public string? creationTime { get; set; }

        public string? lastSignInTime { get; set; }
    }
}