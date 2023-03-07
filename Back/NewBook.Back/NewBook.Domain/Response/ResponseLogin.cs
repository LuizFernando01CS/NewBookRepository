using System.ComponentModel;

namespace NewBook.Domain.Response
{
    public class ResponseLogin
    {
        [Description("kind")]
        public string kind { get; set; }

        [Description("localId")]
        public string localId { get; set; }

        [Description("email")]
        public string email { get; set; }

        [Description("displayName")]
        public string displayName { get; set; }

        [Description("idToken")]
        public string idToken { get; set; }

        [Description("registered")]
        public bool registered { get; set; }

        [Description("refreshToken")]
        public string refreshToken { get; set; }

        [Description("expiresIn")]
        public string expiresIn { get; set; }

        [Description("error")]
        public ErrorLogin error { get; set; }
    }

    public class ErrorLogin
    {
        [Description("code")]
        public int code { get; set; }

        [Description("message")]
        public string message { get; set; }

        [Description("errors")]
        public List<ErrorsLogin> errors { get; set; }
    }

    public class ErrorsLogin
    {
        [Description("message")]
        public string message { get; set; }

        [Description("domain")]
        public string domain { get; set; }

        [Description("reason")]
        public string reason { get; set; }
    }
}