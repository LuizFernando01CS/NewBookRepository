﻿namespace NewBook.Domain.Request
{
    public class RequestLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; } = true;
    }
}