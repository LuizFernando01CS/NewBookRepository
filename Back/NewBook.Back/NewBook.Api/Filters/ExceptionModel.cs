namespace NewBook.Api.Filters
{
    public struct ExceptionModel
    {
        public string message { get; set; }
        public string detail { get; set; }
        public int code { get; set; }
        public bool error { get; set; }
    }
}