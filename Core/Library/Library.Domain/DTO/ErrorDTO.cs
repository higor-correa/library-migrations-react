namespace Library.Domain.DTO
{
    public class ErrorDTO
    {
        public string Message { get; set; }
        public string RealException { get; set; }
        public object Errors { get; set; }
    }
}
